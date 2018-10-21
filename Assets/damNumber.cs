using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damNumber : MonoBehaviour {

	public float timeActive;
	public Vector3 velocity;
	public Rigidbody2D self;
	public float x;
	public float y;


	// Use this for initialization
	void Start () {
		x = Random.Range (-3, 3);
		y = Random.Range (3,5);
		velocity = new Vector3 (x, y, 0);
		self.velocity = velocity;
		StartCoroutine (thing());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator thing()
	{
		yield return new WaitForSeconds (timeActive);
		Destroy (gameObject);
	}
}
