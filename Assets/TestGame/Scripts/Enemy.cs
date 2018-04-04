using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float seeDistance = 2f; // seeing area
    private float attackDistance = 2f; // attacking area 
    private float speed = 6;
    public Transform target; // player or tower


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Is enemy seeing player?
        if (Vector2.Distance(transform.position, target.transform.position) < seeDistance)
        {
            // Can enemy attack player?
            if (Vector2.Distance(transform.position, target.transform.position) > attackDistance)
            {
                // following to player
                transform.right = target.transform.position - transform.position;
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                // to hit player or building and "-n" count HP
            
            }
        }
    }
}
