using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject[] Weapons;
    public GameObject WeaponHere;
    private bool onTrigger;
    private Controller playerController;
    
	void Start ()
	{
	    WeaponHere = Weapons[Random.Range(0, Weapons.Length)];
	    GetComponent<SpriteRenderer>().sprite = WeaponHere.GetComponent<SpriteRenderer>().sprite;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        other.GetComponentInChildren<Controller>().TriggeredItem = gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player") return;
        other.GetComponentInChildren<Controller>().TriggeredItem = null;
    }
}
