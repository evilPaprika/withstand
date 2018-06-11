using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    private Player parentPlayer;

    void Start()
    {
        parentPlayer = GetComponentInParent<Player>();
    }

    void Update()
    {
        if (!parentPlayer.isLocalPlayer) return;

        LookAtMouse();
    }

    private void LookAtMouse()
    {
        var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        var rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
