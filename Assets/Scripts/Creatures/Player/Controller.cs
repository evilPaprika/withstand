using UnityEngine;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour
{
    public GameObject TriggeredItem;

    private Player player;
    private WeaponHandler weaponHandler;

    protected void Start()
    {
        player = GetComponent<Player>();
        weaponHandler = GetComponent<WeaponHandler>();
    }

    protected void Update()
    {
        if (!isLocalPlayer)
            return;

        player.rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * player.MoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)) // for testing
            CmdSpawnZombie(player.respawn);
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && player.Weapon.CanShoot)
            weaponHandler.CmdSpawnProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetMouseButtonUp(0) && player.Weapon != null)
            weaponHandler.CmdSetCanShoot(true);
        if (Input.GetMouseButtonDown(1) && !(player.Weapon is Fists))
            weaponHandler.CmdDropWeapon();
        if (Input.GetKeyDown(KeyCode.F) && TriggeredItem != null)
            TriggeredItem.GetComponent<ItemPickUp>().PickUp(player);
    }



    [Command] // for testing
    void CmdSpawnZombie(Vector3 pos)
    {
        var item1 = Instantiate(player.Enemy1, pos, Quaternion.identity);
        NetworkServer.Spawn(item1);
        var item2 = Instantiate(player.Enemy2, pos + new Vector3(1, 1), Quaternion.identity);
        NetworkServer.Spawn(item2);
    }

    [Command]
    public void CmdTakeFood()
    {
        RpcTakeFood(30);
    }

    [ClientRpc]
    public void RpcTakeFood(int amount)
    {
        player.AddSatiety(amount);
        NetworkServer.Destroy(TriggeredItem);

    }

    [Command]
    public void CmdTakeDrink()
    {
        RpcTakeDrink(30);
    }

    [ClientRpc]
    public void RpcTakeDrink(int amount)
    {
        player.AddThirst(amount);
        NetworkServer.Destroy(TriggeredItem);
    }

    [Command]
    public void CmdPickUpBandages()
    {
        RpcAddHealth(30);
    }

    [ClientRpc]
    public void RpcAddHealth(int amount)
    {
        player.AddHealth(amount);
        NetworkServer.Destroy(TriggeredItem);
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
