using System.Collections;
using System.Linq;
using UnityEngine;

public abstract class Enemy : Creature
{
    public float AttackDistance; // attacking area

    public int Cost { get; set; }
    
    private Rigidbody2D rb;
    private CustomNetworkManager nwm;
    protected bool canDamage = true;
    private Vector2 changedVelocity;

    protected void Start()
    {
        Debug.Log("I have started");
        rb = GetComponent<Rigidbody2D>();
        nwm = FindObjectOfType<CustomNetworkManager>();
        StartCoroutine(FindPath());
    }

    protected void Update()
    {
        ChangeVelocity();
        //Debug.Log("Health points: " + Health);

        if (IsDead())
            DestroyObject();
    }

    private void ChangeVelocity()
    {
        rb.velocity = changedVelocity;
    }

    private void DestroyObject()
    {
        Debug.Log("Dead!");
        Destroy(this, 0.2f); // death of script
        Destroy(gameObject); // death of gameObject
    }

    IEnumerator OnCollisionStay2D(Collision2D collision)
    {
        if (canDamage)
        {
            if (collision.gameObject.tag == "Player")
            {
                TakeDamage(Damage, collision.gameObject.GetComponent<Player>());

                canDamage = false;
                yield return new WaitForSeconds(AttackDelay);
                canDamage = true;
            }
        }
    }

    private Vector2 GetDirection()
    {
        var players = FindObjectsOfType<Player>();
        return players
                .Select(x => x.GetComponent<Rigidbody2D>().position - rb.position)
                .Aggregate((min, x) => x.sqrMagnitude < min.sqrMagnitude ? x : min);
    }

    private IEnumerator FindPath()
    {
        while (true)
        {
            Debug.Log("Find path");
            if (nwm.players.Count == 0) break;
            changedVelocity = GetDirection().normalized * MoveSpeed;
            yield return new WaitForSeconds(0.8f);
        }
    }
}
