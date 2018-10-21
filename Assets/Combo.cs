using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using System;


public class Combo : MonoBehaviour {

	public PlayerStuff guy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnMouseDown() {
		if (guy.gameActive && guy.combo >= 5) {
			guy.useCombo ();
		}
	}
}
