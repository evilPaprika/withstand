using UnityEngine;
using UnityEngine.Networking;

public abstract class ItemPickUp : NetworkBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<Controller>().TriggeredItem = gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<Controller>().GetComponent<Controller>().TriggeredItem = null;
    }

    public abstract void PickUp(Player player);
}
