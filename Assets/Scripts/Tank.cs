using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Unit {

	public override bool CheckIfViableTarget (Actor possibleTarget){
		if (possibleTarget.target != this){ // && !possibleTarget.isBeingTaunted){
			return(true);
		}
		else {
			return(false);
		}
	}

	//aggro on first thing in range that isnt you
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile>() == null){
			Actor colActor = col.gameObject.GetComponent<Actor> ();

			if (!targetsInRange.Contains (colActor)) {
				targetsInRange.Add(colActor);
			}
			if (target == null) {
				target = colActor;
			}
		}
	}

	//remove aggro target when it leaves trigger range
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && col.gameObject.GetComponent<Projectile> () == null) {
			Actor colActor = col.gameObject.GetComponent<Actor> ();

			if (targetsInRange.Contains (colActor)) {
				targetsInRange.Remove (colActor);
			}

			if (target == colActor) {
				target = null;
			}
		}
	}
}
