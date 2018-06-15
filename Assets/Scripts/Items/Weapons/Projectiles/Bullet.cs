using UnityEngine;

public class Bullet : Projectile
{
    public override void Hit(GameObject other)
    {
        switch (other.tag)
        {
            case "Enemy":
                other.GetComponent<Enemy>().GetDamage(Damage);
                break;
            case "Box":
                other.GetComponent<Box>().GetDamage(Damage);
                break;
        }
    }
}
