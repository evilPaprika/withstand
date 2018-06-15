using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Tower : NetworkBehaviour
{
    //public float AttackDistance = 10;
    public int Cost;
    public int Damage;
    public int Armor;
    public float AttackDelay;

    public int Health { get; set; }
    public Effect Effect { get; set; }
    
    private Enemy[] targets;
    private Enemy currentTarget;
    private Rigidbody2D rb;
    private bool canDamage = true;

    protected void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StopAttack());
    }
	
	protected void Update ()
	{
        if (currentTarget != null)
	    {
            if (canDamage)
            {
                currentTarget.GetDamage(Damage);
                canDamage = false;
            }
        }
        else
            currentTarget = GetCurrentTarget();
	}

    //void OnColliderStay2D(Collider2D collider) // нужно как-то реализовать, используя CircleCollider в Unity (я создал)
    //{
    //    
    //}

    private IEnumerator StopAttack()
    {
        while (true)
        {
            if (gameObject == null) break;
            yield return new WaitForSeconds(AttackDelay);
            canDamage = true;
        }
    }


    private Enemy GetCurrentTarget()
    {
        targets = FindObjectsOfType<Enemy>();
        if (targets.Length == 0) return null;

        return targets.Aggregate((min, x) => 
            Vector2.Distance(rb.position, x.GetComponent<Rigidbody2D>().position) < 
            Vector2.Distance(rb.position, min.GetComponent<Rigidbody2D>().position) ? x : min);
    }
}

public enum Effect
{
    Burn,
    Frostbite,
    Bleeding
}