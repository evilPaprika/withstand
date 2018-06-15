using UnityEngine;

public class Crosshair : MonoBehaviour
{
    protected void Start()
    {
        Cursor.visible = false;
    }

    protected void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
