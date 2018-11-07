using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	//defensive stats
	public int hp; //hit points
	public float dodge; //% to negate all dmg
	public float block; //% to negate physical dmg
	public int pDef; //physical defense
	public int mDef; //magic defense
	public int brace; //if charged: negate enemy charge bonus, gain bonus dmg
	public float speed;

	//offensive stats
	public float range; //multiplier to trigger size on init, might need to only have this on weapon :-x
	public float attsp; //attack speed
	public int patt; //physical Attack
	public int matt; //magical attack
	public int charge; //dmg bonus first few rounds of combat

	//physics
	public Rigidbody2D rb;

	public virtual void Walk (){

	}

	public virtual void LookAt(Vector2 target){
		Vector2 direction = (target - (Vector2) transform.position).normalized;
		transform.up = direction;
	}

	public void Awake(){
		//check if there is a rigidbody attached
		if (GetComponent<Rigidbody2D> () != null) {
			rb = GetComponent<Rigidbody2D> ();
		} else {
			Debug.Log ("Unit " + gameObject.name + " does not have a RigidBody2D attached to it.");
		}

		//default: set sprite to black
		if (GetComponent<Rigidbody2D> () != null) {
			SpriteRenderer spriteR = GetComponent<SpriteRenderer> ();
			spriteR.color = new Color(0f,0f,0f,1f);		
		} else {
			Debug.Log ("Unit " + gameObject.name + " does not have a SpriteRenderer attached to it.");
		}
	}
}
