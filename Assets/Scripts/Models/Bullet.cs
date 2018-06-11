using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.tag == "Enemy")
            hit.GetComponent<Enemy>().GetDamage(10);
        Destroy(gameObject);
    }
}
