using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCanvasManager : MonoBehaviour {

	void Start ()
	{
	    var player = GetComponentInParent<Player>();
	    if (!player.isLocalPlayer)
	        Destroy(gameObject);
	}
}
