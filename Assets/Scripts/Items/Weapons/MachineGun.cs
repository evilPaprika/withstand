using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponItem
{
    private float delay = 0.1f;
    
    protected override List<GameObject> CreateProjectiles(Vector3 playerPos, Vector3 bulletDirection)
    {
        var bullet = Instantiate(Projectile,
            playerPos + bulletDirection * 0.5f,
            Quaternion.identity);
        bullet.GetComponentInChildren<Bullet>().Damage = Damage;
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * 10;
        CanShoot = false;
        Invoke("EnableShooting", delay);
        return new List<GameObject> { bullet };
    }

    private void EnableShooting()
    {
        CanShoot = true;
    }
}
