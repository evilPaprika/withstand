using UnityEngine;
using UnityEngine.Networking;

public abstract class Item : NetworkBehaviour
{
    public Sprite Sprite;
    public string Name;

    public virtual void BeUsed() { }
}
