using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System;


public class red : MonoBehaviour {

	public bool x = false;
	public GameObject self;
	public float speed;

	public PlayerStuff player;

	public bool started;

	public Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
		moveLeft ();
	}

	void Update () {


		if (self.transform.position.x > 7)
			moveLeft ();
		if (self.transform.position.x < -7)
			moveRight ();
		
	}

	public void moveRight()
	{
		myRigidBody.velocity = new Vector3 (speed, 0, 0);
	}

	public void moveLeft()
	{
		myRigidBody.velocity = new Vector3 (-speed, 0, 0);
	}






}

