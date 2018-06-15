using UnityEngine;

public class Body : MonoBehaviour
{
    private Animator animator;
    private Player player;

    protected void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    protected void Update()
    {
        animator.SetInteger("WeaponType", player.Weapon.Id);
        animator.SetBool("Shooted", player.Weapon != null && player.IsShooting);
    }
}