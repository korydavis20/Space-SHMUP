﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : MonoBehaviour {
	[Header ("Set in Inspector")]
	public float rotationsPerSecond = 0.1f;

	[Header ("Set Dynamically")]
	public int levelShown = 0;

	//This non-public variable will not appear in the Inspector
	Material mat;

	void Start(){
		mat = GetComponent<Renderer> ().material;
	}

	void Update (){
		//Read the current shield level from the Hero Singleton
		int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
		//if this is different from levelShown...
		if (levelShown != currLevel) {
			levelShown = currLevel;
			//Adjust the texture offset to show different shield level
			mat.mainTextureOffset = new Vector2( 0.2f*levelShown, 0 );
		}
		//rotate the shield a bit every fram in a time-based way
		float rZ = -(rotationsPerSecond * Time.time * 3600) % 360f;
		transform.rotation = Quaternion.Euler (0, 0, rZ);
	}

}
