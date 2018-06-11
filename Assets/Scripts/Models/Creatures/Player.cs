using System;
using System.Collections;
using UnityEngine;

public class Player : Creature
{
    public const int MaxSatiety = 100;
    public int CurrentSatiety { get; private set; }
    public const int MaxThirst = 100;
    public int CurrentThirst { get; private set; }
    
    public GameObject GUISystem;
    public GameObject Enemy1; // for testing
    public GameObject Enemy2; // for testing
    public GameObject ActiveWeapon;

    internal WeaponItem weapon;
    internal readonly Vector2 respawn = new Vector2(0, 0); // for testing
    internal Rigidbody2D rb;
    internal CustomNetworkManager nwm;

    //private Inventory inventory;

    void Start()
    {
        nwm = FindObjectOfType<CustomNetworkManager>();
        nwm.players.Add(this);
        rb = GetComponent<Rigidbody2D>();

        if (!isLocalPlayer)
            return;

        GUISystem = Instantiate(GUISystem);
        GUISystem.transform.parent = transform;

        //inventory = GetComponent<Inventory>();
        CurrentSatiety = MaxSatiety;
        CurrentThirst = MaxThirst;

        StartCoroutine(ChangeSatietyLevel());
        StartCoroutine(ChangeThirstLevel());
        weapon = ActiveWeapon.GetComponentInChildren<WeaponItem>();
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (IsDead())
        {
            Debug.Log("Dead!");
            //Destroy(this, 0.2f);
            Destroy(gameObject, 0.2f);
            OnNetworkDestroy();
        }
    }

    public override bool IsDead()
    {
        return Health <= 0 || CurrentSatiety <= 0;
    }

    public override void OnNetworkDestroy()
    {
        nwm.players.Remove(this);
        base.OnNetworkDestroy();
    }

    private IEnumerator ChangeSatietyLevel()
    {
        while (true)
        {
            if (nwm.players.Count == 0) break;
            CurrentSatiety--;
            //Debug.Log("Satiety amount: " + CurrentSatiety);
            yield return new WaitForSeconds(7f);
        }
    }

    private IEnumerator ChangeThirstLevel()
    {
        while (true)
        {
            if (nwm.players.Count == 0) break;
            CurrentThirst--;
            //Debug.Log("Thirst amount: " + CurrentThirst);
            yield return new WaitForSeconds(10f);
        }
    }
}