using UnityEngine;

public class LegMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

	void Start ()
	{
        animator = GetComponent<Animator>();
	    // брать Rigidbody у parent? это ок?
	    rb = GetComponentInParent<Rigidbody2D>();
	}
	
	void Update ()
	{
        animator.SetFloat("Speed", rb.velocity.magnitude);
	}
}
