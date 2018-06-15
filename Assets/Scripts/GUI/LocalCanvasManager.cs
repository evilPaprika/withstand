using UnityEngine;

public class LocalCanvasManager : MonoBehaviour
{
    protected void Start()
    {
        var player = GetComponentInParent<Player>();
        if (!player.isLocalPlayer)
            Destroy(gameObject);
    }
}
