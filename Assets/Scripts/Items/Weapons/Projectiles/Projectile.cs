using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int Damage;
    public float DestroyTime;

    protected void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Hit(collision.gameObject);
        Destroy(gameObject);
    }

    public abstract void Hit(GameObject other);
}
