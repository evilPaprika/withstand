using UnityEngine;
using UnityEngine.Networking;

public abstract class Generator : NetworkBehaviour
{
    public GameObject World;

    protected const int BoundWidth = 20;

    public virtual void TryGenerate(Vector2 position) { }

    protected void Generate(GameObject obj, Vector2 position,
        Quaternion quaternion = default(Quaternion), bool force = false)
    {
        var instance = Instantiate(obj, position, quaternion);
        instance.transform.SetParent(this.transform);
    }

    protected void NetworkGenerate(GameObject obj, Vector2 position,
        Quaternion quaternion = default(Quaternion), bool force = false)
    {
        if (World.GetComponent<World>().isServer)
        {
            var instance = Instantiate(obj, position, quaternion);
            instance.transform.SetParent(this.transform);
            NetworkServer.Spawn(instance);
        }
    }
}
