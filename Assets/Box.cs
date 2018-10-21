using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {


	bool active;

	public int boxType;
	public float enemyBoxSpeed;
	public float reverseSpeed;

	public PlayerStuff player;
	public GameObject bar;

	public float leftX;
	public float rightX;
	public float length;

	// Use this for initialization
	void Start () {

		//this.active = true;
		float value = (Random.Range (5, 13)) / 10.0f;
		transform.localScale = new Vector3(value, 3.5f, 0);

		length = gameObject.GetComponent<BoxCollider2D> ().size.x * transform.localScale.x;
		leftX = gameObject.transform.position.x - length/2.0f;
		rightX = gameObject.transform.position.x + length/2.0f;

	}
	
	// Update is called once per frame
	void Update () {
		if (player.click == true && player.gameActive)
			Do ();
		
		if (bar.transform.position.x > leftX && bar.transform.position.x < rightX) {
			player.can = true;
			if (boxType==2)
				player.onNormalBox = true;
			
		}

		if (boxType==2)
		{
			leftX = gameObject.transform.position.x - length/2.0f;
			rightX = gameObject.transform.position.x + length/2.0f;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-enemyBoxSpeed, 0, 0);
			if (gameObject.transform.position.x <= -7.5f && gameObject.transform.position.x > -10) {
				player.takeDamage ();
				Destroy (gameObject);
			}
			if (player.reverse==true)
				enemyBoxSpeed = -player.combo;
			if (player.reverse == false)
				enemyBoxSpeed = 2;
			if (gameObject.transform.position.x > 7.1f)
				Destroy (gameObject);

		}
	}



		void Do()
		{
			StartCoroutine (delay ());
			if (bar.transform.position.x > leftX && bar.transform.position.x < rightX) {
				player.attack ();
				player.boxCount--;
				if (player.boxCount == 6)
					player.thin ();
				Destroy (gameObject);
			} 
		}
	

//	void  OnTriggerEnter2D (Collider2D col){
//		//Destroy (this);
//		print ("this");
//		if(col.tag == ("bar"))
//		player.canAttack = true;
//
//
//
//	}
//
//	void  OnTriggerExit2D (Collider2D col){
//		print ("exit");
//		if(col.tag == ("bar"))
//		player.canAttack = false;
//	}

	IEnumerator delay()
	{
		yield return 0;
		player.click = false;
	}







}
