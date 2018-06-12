using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "Enemy")
            hit.GetComponent<Enemy>().GetDamage(Damage);
        Destroy(gameObject);
    }
}
