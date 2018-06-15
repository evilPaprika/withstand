using UnityEngine;
using UnityEngine.Networking;

public class CameraMovement : NetworkBehaviour
{
    public float DampTime = 0.15f;
    public float MouseFactor = 7;
    public float ZoomSpeed = 7;
    public float SmoothSpeed = 7.0f;
    public float MinOrtho = 1.0f;
    public float MaxOrtho = 20.0f;

    private Vector3 velocity = Vector3.zero;
    private float targetOrtho;

    protected void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    protected void Update()
    {
        if (!isLocalPlayer)
            return;

        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * ZoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, MinOrtho, MaxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize,
            targetOrtho, SmoothSpeed * Time.deltaTime);
        var mouseRelative = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        var position = transform.position + mouseRelative.normalized * MouseFactor;
        
        var point = Camera.main.WorldToViewportPoint(position);
        var delta = position - Camera.main
                            .ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));

        var destination = Camera.main.transform.position + delta;
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, destination, ref velocity, DampTime);
    }
}
