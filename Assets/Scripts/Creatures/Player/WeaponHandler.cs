using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponHandler : NetworkBehaviour
{
    public GameObject Fists;
    public GameObject WeaponPickup;
    public GameObject[] WeaponPickups;

    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
        player.Weapon = Fists.GetComponent<WeaponItem>();
    }

    [Command]
    public void CmdSpawnProjectile(Vector2 mousePosition)
    {
        if (!player.Weapon.CanShoot)
            return;
        var diff = (mousePosition - (Vector2)transform.position).normalized;
        var projectiles = player.Weapon.GetProjectiles(transform.position, diff);
        foreach (var projectile in projectiles)
            NetworkServer.Spawn(projectile);
        RpcSetIsShooting();
    }

    [ClientRpc]
    public void RpcSetIsShooting()
    {
        player.IsShooting = true;
        Invoke("SetIsShootingFalse", 0.3f);
    }
    private void SetIsShootingFalse()
    {
        player.IsShooting = false;
    }

    [Command]
    public void CmdSetCanShoot(bool value)
    {
        player.Weapon.CanShoot = value;
    }

    [Command]
    public void CmdUpdateWeapon(GameObject weaponPickUp)
    {
        if (!(player.Weapon is Fists))
            CmdDropWeapon();
        RpcUpdateWeapon(weaponPickUp);
    }

    [ClientRpc]
    public void RpcUpdateWeapon(GameObject weaponPickUp)
    {
        player.Weapon = weaponPickUp.GetComponent<WeaponPickUp>()
            .WeaponHere.GetComponent<WeaponItem>();
        NetworkServer.Destroy(weaponPickUp);
    }

    [Command]
    public void CmdDropWeapon()
    {
        var wpu = WeaponPickups[player.Weapon.Id - 1];
        var playerPos = player.transform.position;
        var droppedWeaponPickup = Instantiate(wpu, playerPos + new Vector3(1, 0),
            Quaternion.identity);
        NetworkServer.Spawn(droppedWeaponPickup);
        RpcDropWeapon();
    }

    [ClientRpc]
    public void RpcDropWeapon()
    {
          player.Weapon = Fists.GetComponent<WeaponItem>();
    }
}