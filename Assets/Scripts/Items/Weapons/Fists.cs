using System.Collections.Generic;
using UnityEngine;

public class Fists : WeaponItem
{
    protected override List<GameObject> CreateProjectiles(Vector3 playerPos, Vector3 projectileDirection)
    {
        var fist = Instantiate(Projectile,
            playerPos + projectileDirection * 0.6f,
            Quaternion.identity);
        fist.GetComponent<Fist>().Damage = Damage;
        CanShoot = false;
        return new List<GameObject> { fist };
    }
}

