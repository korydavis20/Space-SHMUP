using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[Header("Set in Inspector: Enemy")]
	public float speed = 10f; // the Speed in m/s
	public float fireRate = 0.3f; //Seconds/shot (unused)
	public float health = 10;
	public int score = 100; // points earned for destroying this

	private BoundsCheck bndCheck;

	//this is a property: a method that acts like a field
	public Vector3 pos{
		get{
			return(this.transform.position);
		}
		set{
			this.transform.position = value;
		}
	}

	void Awake(){
		bndCheck = GetComponent<BoundsCheck> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

		if(bndCheck != null && bndCheck.offDown){
				//we're off the bottom so destroy this GameObject
			Destroy(gameObject);
		}
	}

	public virtual void Move(){
		Vector3 tempPos = pos;
		tempPos.y -= speed * Time.deltaTime;
		pos = tempPos;
	}

	void OnCollisionEnter(Collision coll){
		GameObject otherGo = coll.gameObject;

		if (otherGo.tag == "ProjectileHero") {
			Destroy (otherGo);
			Destroy (gameObject);
		} else {
			print ("Enemy hit by non-ProjectileHero: " + otherGo.name);
		}
	}
}
