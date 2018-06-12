using UnityEngine;

public class Player : Creature
{
//    public int CurrentSatiety { get {return GUISystem.GetComponentInChildren<SliderHandler>().CurrentPoint; } }
//    public int CurrentThirst { get { return GUISystem.GetComponentInChildren<SliderHandler>().CurrentPoint; } }

    public GameObject LocalCanvas;
    public GameObject Enemy1; // for testing
    public GameObject Enemy2; // for testing
    public GameObject ActiveWeapon;

    internal WeaponItem weapon;
    internal readonly Vector2 respawn = new Vector2(0, 0); // for testing
    internal Rigidbody2D rb;
    internal CustomNetworkManager nwm;

    //private Inventory inventory;

    protected void Start()
    {
        nwm = FindObjectOfType<CustomNetworkManager>();
        nwm.players.Add(this);
        rb = GetComponent<Rigidbody2D>();

        if (!isLocalPlayer)
            return;

//        LocalCanvas = Instantiate(LocalCanvas);
//        LocalCanvas.transform.parent = transform;

        //inventory = GetComponent<Inventory>();

//        StartCoroutine(ChangeSatietyLevel());
//        StartCoroutine(ChangeThirstLevel());
    }

    protected void Update()
    {
        if (!isLocalPlayer)
            return;

        if (IsDead())
        {
            Debug.Log("Dead!");
            Destroy(gameObject, 0.2f);
            OnNetworkDestroy();
        }
    }

    public override bool IsDead()
    {
        return false;
//        return Health <= 0 || CurrentSatiety <= 0 || CurrentThirst <= 0;
    }

    public override void OnNetworkDestroy()
    {
        nwm.players.Remove(this);
        base.OnNetworkDestroy();
    }

//    private IEnumerator ChangeSatietyLevel()
//    {
//        while (true)
//        {
//            if (nwm.players.Count == 0) break;
//            GUISystem.GetComponentInChildren<SliderHandler>().Decrease(1);
//            Debug.Log("Satiety amount: " + CurrentSatiety);
//            yield return new WaitForSeconds(7f);
//        }
//    }
//
//    private IEnumerator ChangeThirstLevel()
//    {
//        while (true)
//        {
//            if (nwm.players.Count == 0) break;
//            GUISystem.GetComponentInChildren<SliderHandler>().Decrease(1);
//            Debug.Log("Thirst amount: " + CurrentThirst);
//            yield return new WaitForSeconds(10f);
//        }
//    }
}