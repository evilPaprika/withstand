using UnityEngine;

public class FireBall : Projectile
{
    public override void Hit(GameObject other)
    {
        if (other.tag == "Player")
            other.GetComponent<Player>().GetDamage(Damage);
    }
}
