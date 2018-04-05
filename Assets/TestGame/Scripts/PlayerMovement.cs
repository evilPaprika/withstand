using System.Collections;
using System.Collections.Generic;
using Completed;
using UnityEngine;

public class PlayerMovement : MovingObject
{

    public float moveSpeed;


	// Use this for initialization
	void Start ()
	{

	}

    protected override void OnCantMove<T>(T component)
    {
        Debug.Log("OnCantMove called");
    }

    // Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") , 0f).normalized * Time.deltaTime * moveSpeed);
	}
}
