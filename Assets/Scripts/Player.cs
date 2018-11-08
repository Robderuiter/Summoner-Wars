using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

	GameObject targetPrefab;
	Vector2 size;

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 100;
		stats.hp = stats.maxHP;
		stats.dodge = 0.1f;
		stats.block = 0.3f;
		stats.pDef = 5;
		stats.mDef = 3;
		stats.brace = 0;
		stats.speed = 2f;

		//offensive stats
		stats.range = 1f;
		stats.attsp = 1;
		stats.patt = 5;
		stats.matt = 0;
		stats.charge = 0;

		//swordsman prefab
		targetPrefab = (GameObject) Resources.Load("Swordsman");

		//Debug.Log ("Unit " + gameObject.name + " size is " + spriteR.size);
	}

	new void Update(){
		if (GetComponent<Rigidbody2D> () != null) {
			//player walks on user input (wasd)
			PlayerWalk();

			//player just looks at mouse all the time
			Vector2 mouseScrPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			LookAt (mouseScrPos);
		} else {
			Debug.Log ("Unit " + gameObject.name + " does not have a RigidBody2D attached to it.");
		}

		if (Input.GetMouseButtonDown (0)) {
			Spawn (targetPrefab, this.gameObject);//prefabToSpawn, creatorGameObject
		}
	}
		
	public void PlayerWalk(){
		Vector2 p =	GetBaseInput();
		p = p * stats.speed;
		p = p * Time.deltaTime;
		transform.Translate (p);
	}

	//move up/down/left/right
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
}
