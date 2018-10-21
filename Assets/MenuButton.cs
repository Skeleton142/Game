using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public PlayerStuff player;
    public float leftX;
    public float rightX;
    public float length;

	// Use this for initialization
	void Start () {
        length = gameObject.GetComponent<BoxCollider2D>().size.x * transform.localScale.x;
        leftX = gameObject.transform.position.x - length / 2.0f;
        rightX = gameObject.transform.position.x + length / 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
