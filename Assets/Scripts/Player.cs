using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit {

	GameObject targetPrefab;

	void Awake(){
		base.Awake ();

		//defensive stats
		hp = 100;
		dodge = 0.1f;
		block = 0.3f;
		pDef = 5;
		mDef = 3;
		brace = 0;
		speed = 3f;

		//offensive stats
		range = 1f;
		attsp = 1f;
		patt = 5;
		matt = 0;
		charge = 0;

		//temp, swordsman prefab
		targetPrefab = (GameObject) Resources.Load("Swordsman");
	}

	void Update(){
		if (GetComponent<Rigidbody2D> () != null) {
			//player walks on user input (wasd)
			Walk();

			//player just looks at mouse all the time
			Vector2 mouseScrPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			LookAt (mouseScrPos);
		} else {
			Debug.Log ("Unit " + gameObject.name + " does not have a RigidBody2D attached to it.");
		}

		if (Input.GetMouseButtonDown (0)) {
			Spawn ();
		}
	}
		
	public override void Walk(){
		Vector2 p =	GetBaseInput();
		p = p * speed;
		p = p * Time.deltaTime;
		transform.Translate (p);
	}

	//move cam up/down/left/right
	private Vector2 GetBaseInput() {
		Vector2 p_Velocity = new Vector2();
		if (Input.GetKey (KeyCode.W)){
			p_Velocity += new Vector2(0, 1);
		}
		if (Input.GetKey (KeyCode.S)){
			p_Velocity += new Vector2(0, -1);
		}
		if (Input.GetKey (KeyCode.A)){
			p_Velocity += new Vector2(-1, 0);
		}
		if (Input.GetKey (KeyCode.D)){
			p_Velocity += new Vector2(1, 0);
		}
		return p_Velocity;
	}

	void Spawn(){
		GameObject clone = GameObject.Instantiate(targetPrefab, transform.position, transform.localRotation);
	}
}
