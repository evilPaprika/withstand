using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponItem
{
    protected override List<GameObject> CreateProjectiles(Vector3 playerPos, Vector3 bulletDirection)
    {
        var bullet = Instantiate(Projectile,
            playerPos + bulletDirection * 0.5f,
            Quaternion.identity);
        bullet.GetComponentInChildren<Bullet>().Damage = Damage;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * 15;
        CanShoot = false;
        return new List<GameObject>{bullet};
    }
}
