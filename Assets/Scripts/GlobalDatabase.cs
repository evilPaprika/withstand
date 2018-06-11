using System.Collections.Generic;
using UnityEngine.Networking;

public class GlobalDatabase : NetworkBehaviour
{
    public int Money;
    //public List<GameObject> objects = new List<GameObject>();
    public static Dictionary<string, Item> ItemTypes = new Dictionary<string, Item>
    {
        { "Food", new FoodItem{ FoodAmount = 50 }},
        { "Weapon", new WeaponItem{ Damage = 10 }},
        { "Armor", new ArmorItem{ Armor = 1 }}
    };

    void Start()
    {

    }

    void Update()
    {

    }

    void ActivateTrigger2D()
    {
        //objects.ForEach(obj => obj.GetComponent<BoxCollider2D>().isTrigger = true);
    }

    void DeactivateTrigger2D()
    {
        //objects.ForEach(obj => obj.GetComponent<BoxCollider2D>().isTrigger = false);
    }
}
