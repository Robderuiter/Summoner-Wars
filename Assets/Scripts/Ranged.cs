using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Unit {

	public GameObject projectile;

	//set target for aggro if collider doesn't have the same tag as you and you don't already have a target for aggro
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && aggroTarget == null && attackTarget == null) {
			aggroTarget = col.gameObject.transform;
			attackTarget = col.gameObject.GetComponent<Actor>();
			isWalking = false;
		}
	}

	//remove aggro target when it leaves trigger range
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && aggroTarget != null && attackTarget != null) {
			isWalking = true;
			attackTarget = null;
			aggroTarget = null;
		}
	}
}
