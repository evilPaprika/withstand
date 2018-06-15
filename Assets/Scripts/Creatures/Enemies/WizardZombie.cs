using UnityEngine;
using UnityEngine.Networking;

public class WizardZombie : Enemy
{
    public GameObject FireBall;

    protected new virtual void Update()
    {
        base.Update();
        if (!isServer) return;

        Fire(GetDirection());
    }

    private void Fire(Vector2 direction)
    {
        if (!canDamage || lostPlayer) return;
        var fireBall = Instantiate(FireBall, (Vector2)transform.position + direction, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().velocity = direction * 6.0f;
        Destroy(fireBall, 2);
        canDamage = false;
        Invoke("EnableNewAttack", AttackDelay);
        NetworkServer.Spawn(fireBall);
    }

    void EnableNewAttack()
    {
        canDamage = true;
    }
}
