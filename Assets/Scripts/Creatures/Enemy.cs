using System.Collections;
using System.Linq;
using UnityEngine;

public abstract class Enemy : Creature
{
    public float VeiwRadius;

    protected bool canDamage = true;

    private Rigidbody2D rb;
    private DropsOnDying dropChoice;
    private Vector2 targetLastSeenDirection;
    private Vector2 direction;
    protected bool lostPlayer = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dropChoice = GetComponent<DropsOnDying>();
        StartCoroutine(SetDirection());
    }

    protected void Update()
    {
        if (!isServer) return;

        ChangeVelocity();

        if (IsDead())
            DestroyObject();
    }

    private void ChangeVelocity()
    {
        rb.velocity = GetDirection() * MoveSpeed;
    }

    private void DestroyObject()
    {
        dropChoice.ChoiceItem();
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

    public Vector2 GetDirection()
    {
        return direction;
    }

    private IEnumerator SetDirection()
    {
        while (true)
        {
            var players = FindObjectsOfType<Player>();
            if (players == null || players.Length == 0)
            {
                lostPlayer = true;
                direction = Random.insideUnitCircle;
            }
            else
            {
                var minDirection = players.Select(x => x.GetComponent<Rigidbody2D>().position - rb.position)
                    .Aggregate((min, x) => x.sqrMagnitude < min.sqrMagnitude ? x : min);
                if (minDirection.magnitude < VeiwRadius)
                {
                    lostPlayer = false;
                    direction = minDirection.normalized;
                }
                else
                {
                    lostPlayer = true;
                    direction = Random.insideUnitCircle;
                }
            }
            yield return new WaitForSeconds(0.8f);
        }
    }
}
