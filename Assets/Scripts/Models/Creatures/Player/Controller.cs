using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour
{
    //sprites - заготовка, по нему будут отрисовываться спрайты персонажа с нужным оружием
    // так как пока спрайтов нет, то когда ты подбираешь пистолет, то становишься пистолетом))0)
    private Dictionary<string, Sprite> sprites; 
    private Player player;
    public GameObject TriggeredItem;

    void Start()
    {
        player = GetComponent<Player>();
        player.ActiveWeapon = null;
        sprites = new Dictionary<string, Sprite>
        {
            {"Empty", Resources.Load<Sprite>("Sprites/Player_green_0") },
            {"Gun", Resources.Load<Sprite>("Sprites/Weapons/Gun") }
        };
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        player.rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * player.MoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) // for testing
            CmdSpawnZombie(player.respawn);
        if (Input.GetMouseButtonDown(0) && player.weapon != null)
            CmdFire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonDown(1) && player.weapon != null)
            CmdDropWeapon();
        if (Input.GetKeyDown(KeyCode.F) && TriggeredItem != null)
        {
            UpdateWeapon(TriggeredItem.GetComponentInChildren<WeaponPickUp>().WeaponHere);
            Destroy(TriggeredItem);
        }
    }

    [Command]
    void CmdFire(Vector2 mousePosition)
    {
        var diff = (mousePosition - (Vector2)transform.position).normalized;
        var bullet = Instantiate(player.weapon.Projectile,
            (Vector2)transform.position + diff,
            Quaternion.identity);
        bullet.GetComponentInChildren<Bullet>().Damage = player.weapon.Damage;
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

    public void UpdateWeapon(GameObject newWeapon)
    {
        player.ActiveWeapon = newWeapon;
        player.weapon = newWeapon.GetComponentInChildren<WeaponItem>();
        player.transform.Find("Graphics/Body").GetComponent<SpriteRenderer>().sprite 
            = sprites[newWeapon.name];
    }

    [Command]
    void CmdDropWeapon()
    {
        var weaponPickUp = Resources.Load("Prefabs/WeaponPickUp") as GameObject;
        weaponPickUp.GetComponentInChildren<WeaponPickUp>().WeaponHere = player.ActiveWeapon;
        player.ActiveWeapon = null;
        player.weapon = null;
        var playerPos = player.transform.position;
        var droppedWeapon = Instantiate(weaponPickUp, new Vector3(playerPos.x + 1, playerPos.y),
            Quaternion.identity);
        NetworkServer.Spawn(droppedWeapon);
        player.transform.Find("Graphics/Body").GetComponent<SpriteRenderer>().sprite = sprites["Empty"];
    }


    void OnGUI()
    {
        if (TriggeredItem == null || !isLocalPlayer) return;
        var style = new GUIStyle
        {
            fontSize = 20,
            normal = {textColor = Color.white}
        };
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height/2 + 50, 200, 30), "Press F to pick up", style);
    }
}
