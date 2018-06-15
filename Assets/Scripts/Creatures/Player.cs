using UnityEngine;
using UnityEngine.Networking;

public class Player : Creature
{
    public int CurrentSatiety { get {return GetComponentInChildren<Satiety>().CurrentValue; } }
    public int CurrentThirst { get { return GetComponentInChildren<Thirst>().CurrentValue; } }

    public GameObject Enemy1; // for testing
    public GameObject Enemy2; // for testing

    internal bool IsShooting = false;
    public WeaponItem Weapon;
    internal readonly Vector2 respawn = new Vector2(0, 0); // for testing
    internal Rigidbody2D rb;

    protected void Start()
    {
        if (!isLocalPlayer)
            return;
        
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (!isLocalPlayer)
            return;

        if (IsDead())
            CmdRespawn();
    }

    public override bool IsDead()
    {
        return Health <= 0 || CurrentSatiety <= 0 || CurrentThirst <= 0;
    }

    public void AddSatiety(int amount)
    {
        GetComponent<Satiety>().IncreaseLevel(amount);
    }

    public void AddThirst(int amount)
    {
        GetComponent<Thirst>().IncreaseLevel(amount);
    }

    [Command]
    void CmdRespawn()
    {      
        RpcRespawn();
        transform.position = new Vector3(0, 0);
        Invoke("CmdAppearAfterRespawn", 10);
    }

    [ClientRpc]
    void RpcRespawn()
    {
        SetFullHealth();
        GetComponentInChildren<Thirst>().SetFull();       
        GetComponentInChildren<Satiety>().SetFull();
        Weapon = GetComponent<WeaponHandler>().Fists.GetComponent<WeaponItem>();
        transform.position = new Vector3(0, 0);
        gameObject.SetActive(false);
    }

    [Command]
    void CmdAppearAfterRespawn()
    {
        gameObject.SetActive(true);
        RpcAppearAfterRespawn();       
    }

    [ClientRpc]
    void RpcAppearAfterRespawn()
    {
        gameObject.SetActive(true);
    }
}