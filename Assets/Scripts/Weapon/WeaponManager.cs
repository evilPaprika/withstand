using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour
{
    public float BulletSpeed = 6;
    public GameObject ActiveWeapon;
    WeaponItem weapon;

    private Rigidbody2D rb;
    
	void Start ()
	{
	    weapon = ActiveWeapon.GetComponent<WeaponItem>();
	    GetComponent<SpriteRenderer>().sprite = weapon.Sprite;
	    rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
	{
        //тут всё очень косо работает, но я уже устала:с
        rb.rotation = transform.GetComponentInParent<Player>().GetComponent<Rigidbody2D>().rotation;
        
        Debug.Log(rb.rotation);
	    if (Input.GetMouseButtonDown(0))
	    {
            var bullet = Instantiate(weapon.Projectile, rb.position, transform.GetComponentInParent<Player>().transform.rotation);

            bullet.GetComponent<Rigidbody2D>().velocity = 
                (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * BulletSpeed;
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
	        Destroy(bullet, 2);
        }
    }


    //пробовала сделать это с NetworkBehavior, чтобы работало в мультиплеере, но всё поломалось
    //
    //[Command]
    //void CmdFire()
    //{
    //    var bullet = Instantiate(weapon.Projectile, transform.position, transform.rotation);
    //    bullet.GetComponent<Rigidbody2D>().velocity =
    //        (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 6;
    //    Destroy(bullet, 2);
    //}
}