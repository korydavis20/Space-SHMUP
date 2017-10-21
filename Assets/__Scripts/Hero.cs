using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : MonoBehaviour {
	static public Hero S;

	[Header ("Set in Inspector")]
	//these fields control the movement of the ship
	public float speed = 30;
	public float rollMult = 45;
	public float pitchMult = 30;

	[Header ("Set Dynamically")]
	public float shieldLevel = 1;

	void Awake(){
		if (S == null) {
			S = this; //set singleton
		} else {
			Debug.LogError("Hero.Awake() - Attempted to assign a second Hero.S!");
		}
	}

	void Update(){
		//Pull in information from the input class
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		//Change transform.position based on the axes

		Vector3 pos = transform.position;
		pos.x += xAxis * speed * Time.deltaTime;
		pos.y += yAxis * speed * Time.deltaTime;
		transform.position = pos;

		//rotate the ship to make it feel more dynamic
		transform.rotation = Quaternion.Euler(yAxis*pitchMult, xAxis*rollMult, 0);
	}

}