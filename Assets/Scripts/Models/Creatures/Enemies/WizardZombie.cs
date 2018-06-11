using System.Linq;
using UnityEngine;

public class WizardZombie : Enemy
{
    public GameObject FireBall;

    protected new virtual void Start()
    {
        Cost = 12;
        Damage = 20;
        Armor = 0;
        MoveSpeed = 1;
        AttackDelay = 5f;
        AttackDistance = 5f;
        base.Start();
    }

    protected new virtual void Update()
    {
        var playersToAttack = FindObjectsOfType<Player>()
            .Where(p => Vector3.Distance(p.transform.position, transform.position) <= AttackDistance)
            .OrderBy(p => Vector3.Distance(p.transform.position, transform.position))
            .ToArray();
        if (playersToAttack.Any())
            Fire(playersToAttack[0].transform.position);
        else
            base.Update();
    }

    void Fire(Vector3 playerPosition)
    {
        if (!canDamage) return;
        Debug.Log("Fire");
        var direction = (playerPosition - transform.position).normalized;
        var fireBall = Instantiate(FireBall, transform.position + direction, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().velocity = direction * 6.0f;
        Destroy(fireBall, 2);
        canDamage = false;
        Invoke("EnableNewAttack", AttackDelay);
    }

    void EnableNewAttack()
    {
        canDamage = true;
    }
}
