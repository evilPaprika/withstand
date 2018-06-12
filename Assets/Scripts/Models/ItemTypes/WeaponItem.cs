using UnityEngine;

public class WeaponItem : Item
{
    public int Damage;
    public GameObject Projectile;

    public override void BeUsed()
    {
        // здесь получить урон игрока
        // GetComponent<Player>().Damage += Damage;
    }
}