using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraMovement : NetworkBehaviour
{
    public float dampTime = 0.15f;
    public float mouseFactor = 7;
    public float zoomSpeed = 7;
    public float smoothSpeed = 7.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    private Vector3 velocity = Vector3.zero;
    private float targetOrtho;

    void Start()
    {
        targetOrtho = Camera.main.orthographicSize;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize,
            targetOrtho, smoothSpeed * Time.deltaTime);
        var mouseRelative = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        ;
        var position = transform.position + mouseRelative.normalized * mouseFactor;
        
        Vector3 point = Camera.main.WorldToViewportPoint(position);
        Vector3 delta = position - Camera.main
                            .ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));

        Vector3 destination = Camera.main.transform.position + delta;
        Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, destination, ref velocity, dampTime);
    }
}
