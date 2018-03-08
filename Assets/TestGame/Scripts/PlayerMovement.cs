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
		transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed,
            Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed, 0f);
	}
}
