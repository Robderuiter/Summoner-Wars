using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Unit {

	//set target for aggro if collider doesn't have the same tag as you and you don't already have a target for aggro
	void OnTriggerEnter2D (Collider2D col){
		//check if col has another tag than you and you don't already have a target, also ignore projectiles, let em do their thang
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile>() == null) {
			Actor colActor = col.gameObject.GetComponent<Actor>();

			if (!targetsInRange.Contains (colActor)) {
				targetsInRange.Add (colActor);
			}

			if (target == null){
				target = colActor;
			}
		}
	}

	//remove aggro target when it leaves trigger range
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile>() == null) {
			Actor colActor = col.gameObject.GetComponent<Actor>();

			if (targetsInRange.Contains (colActor)) {
				targetsInRange.Remove (colActor);
			}

			if (target == colActor) {
				target = null;
			}
		}
	}
}
