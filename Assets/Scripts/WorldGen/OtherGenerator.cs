using System.Collections.Generic;
using UnityEngine;

public class OtherGenerator : Generator
{
    public List<GameObject> Loot;
    public List<int> LootChances;

    public List<GameObject> Boxes;
    public List<int> BoxChances;
    public GameObject pistolPickUp;
    public GameObject shotgunPickUp;
    public GameObject machineGunPickUp;

    void Start()
    {
        NetworkGenerate(pistolPickUp, new Vector2(2, 3));
        NetworkGenerate(shotgunPickUp, new Vector2(0, 3));
        NetworkGenerate(machineGunPickUp, new Vector2(-2, 3));
    }

    public override void TryGenerate(Vector2 position)
    {
        var index = Random.Range(0, Loot.Count);
        var item = Loot[index];
        if (item != null && Random.Range(0, 1000) <= LootChances[index]) // chance = 0.00x
            Generate(item, position, Quaternion.identity);
        else
        {
            var i = Random.Range(0, Boxes.Count);
            var box = Boxes[i];
            if (box != null && Random.Range(0, 1000) <= BoxChances[i]) // chance = 0.00x
                NetworkGenerate(box, position, Quaternion.identity);
        }
    }
}
