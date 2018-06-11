using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour
{

    private Player player;

	void Start ()
	{
	    player = GetComponent<Player>();
	}
	
	void Update () {
	    if (!isLocalPlayer)
	        return;

        player.rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * player.MoveSpeed;

	    if (Input.GetKeyDown(KeyCode.Space)) // for testing
	        CmdSpawnZombie(player.respawn);
	    if (Input.GetMouseButtonDown(0) && player.ActiveWeapon != null)
	        CmdFire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    [Command]
    void CmdFire(Vector2 mousePosition)
    {
        //Debug.Log(ActiveWeapon);
        var diff = (mousePosition - (Vector2)transform.position).normalized;
        var bullet = Instantiate(player.ActiveWeapon.GetComponentInChildren<WeaponItem>().Projectile,
            (Vector2)transform.position + diff,
            Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = diff * 6;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }

    [Command] // for testing
    void CmdSpawnZombie(Vector3 pos)
    {
        var item1 = Instantiate(player.Enemy1, pos, Quaternion.identity);
        NetworkServer.Spawn(item1);
        var item2 = Instantiate(player.Enemy2, pos + new Vector3(1, 1), Quaternion.identity);
        NetworkServer.Spawn(item2);
    }
}
