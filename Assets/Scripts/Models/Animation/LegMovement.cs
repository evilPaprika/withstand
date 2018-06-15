using UnityEngine;

public class LegMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

	protected void Start ()
	{
        animator = GetComponent<Animator>();
	    rb = GetComponentInParent<Rigidbody2D>();
	}
	
	protected void Update ()
	{
        animator.SetFloat("Speed", rb.velocity.magnitude);
	}
}
