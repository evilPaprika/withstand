using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DropsOnDying : NetworkBehaviour
{
    public GameObject WhoIsDead;

    public List<ItemPickUp> Items;
    public List<int> Chances;

    public void ChoiceItem()
    {
        var index = Random.Range(0, Items.Count);
        var chosenItem = Items[index];
        if (!(chosenItem == null || Random.Range(0, 100) > Chances[index])) 
            CmdSpawnItem(chosenItem.gameObject);
        NetworkServer.Destroy(WhoIsDead);
    }

    [Command]
    public void CmdSpawnItem(GameObject item)
    {
        var droppedItem = Instantiate(item, WhoIsDead.transform.position, Quaternion.identity);
        NetworkServer.Spawn(droppedItem);
    }
}
