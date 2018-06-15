using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponItem : Item
{
    public int Id;
    public int Damage;
    public GameObject Projectile;
    public bool CanShoot = true;
    
    public List<GameObject> GetProjectiles(Vector3 playerPos, Vector3 projectileDirection)
    {
        return CreateProjectiles(playerPos, projectileDirection);
    }

    protected abstract List<GameObject> CreateProjectiles(Vector3 playerPos, Vector3 projectileDirection);
}