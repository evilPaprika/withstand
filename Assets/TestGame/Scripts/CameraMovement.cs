using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float dampTime = 0.15f; 
    public Transform target;
    public float mouseFactor = 7;
    public float zoomSpeed = 1;
    private float targetOrtho;
    public float smoothSpeed = 2.0f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
        targetOrtho = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f)
            {
                targetOrtho -= scroll * zoomSpeed;
                targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
            }

            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);

            var mouseRelative = Camera.main.ScreenToWorldPoint(Input.mousePosition) - target.position; ;
            print(mouseRelative);
            var position = target.position + mouseRelative.normalized * mouseFactor;
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(position);
            Vector3 delta = position - GetComponent<Camera>()
                .ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); 
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
