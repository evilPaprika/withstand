using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    private Player parentPlayer;

    protected void Start()
    {
        parentPlayer = GetComponentInParent<Player>();
    }

    protected void Update()
    {
        if (!parentPlayer.isLocalPlayer) return;

        LookAtMouse();
    }

    private void LookAtMouse()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        var rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
