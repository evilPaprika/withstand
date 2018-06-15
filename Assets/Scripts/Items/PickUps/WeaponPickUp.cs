using UnityEngine;

public class WeaponPickUp : ItemPickUp
{
    public GameObject WeaponHere;

    public void SetNewWeapon(GameObject weapon)
    {
        WeaponHere = weapon;
        GetComponent<SpriteRenderer>().sprite = weapon.GetComponent<WeaponItem>().Sprite;
    }

    public override void PickUp(Player player)
    {
        player.GetComponent<WeaponHandler>().CmdUpdateWeapon(gameObject);
    }
}