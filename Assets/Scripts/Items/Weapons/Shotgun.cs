using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponItem
{
    protected override List<GameObject> CreateProjectiles(Vector3 playerPos, Vector3 bulletDirection)
    {
        var bullets = new List<GameObject>();
        for (var i = -1; i < 2; i++)
        {
            var direction = Quaternion.Euler(0, 0, 10 * i) * bulletDirection;
            var bullet = Instantiate(Projectile, playerPos + direction * 0.7f, Quaternion.identity);
            bullet.GetComponentInChildren<Bullet>().Damage = Damage;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 15;
            bullets.Add(bullet);
        }
        CanShoot = false;
        return bullets;
    }
}
