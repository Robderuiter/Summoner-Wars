using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Unit {

	//set target for aggro if collider doesn't have the same tag as you and you don't already have a target for aggro
	void OnTriggerEnter2D (Collider2D col){
		//check if col has another tag than you and you don't already have a target, also ignore projectiles, let em do their thang
		if (col.gameObject.tag != gameObject.tag && aggroTarget == null && col.gameObject.GetComponent<Projectile>() == null) {
			aggroTarget = col.gameObject.transform;
		}
	}

	//remove aggro target when it leaves trigger range
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && aggroTarget != null && col.gameObject.GetComponent<Projectile>() == null) {
			aggroTarget = null;
		}
	}

	//when you collide with a non-allied unit, stop walking, start attacking
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile>() == null) {
			isWalking = false;
			attackTarget = col.gameObject.GetComponent<Actor>();
		}
	}

	//if collider exits, walk forward again
	void OnCollisionExit2D(Collision2D col){
		//check if col has another tag than you
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile>() == null) {
			isWalking = true;
			attackTarget = null;
		}
	}
}
