using UnityEngine;

public class Gun : WeaponItem
{
	void Start ()
	{
	    Damage = 10;
	    Sprite = Resources.Load<Sprite>("Sprites/Weapons/Gun");
	}
}
