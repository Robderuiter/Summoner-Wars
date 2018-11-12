using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Unit {

	public override bool CheckIfViableTarget (Actor possibleTarget){
		if (possibleTarget.stats.hp < possibleTarget.stats.maxHP && !possibleTarget.isBeingHealed){
			return(true);
		}
		else {
			return(false);
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == gameObject.tag && col.gameObject.GetComponent<Projectile>() == null) {
			Actor colActor = col.gameObject.GetComponent<Actor>();

			//check to see if it isnt already in target list (it shouldnt be, but never hurts to prevent future bugs:P), then add
			if (!targetsInRange.Contains (colActor)) {
				targetsInRange.Add (col.gameObject.GetComponent<Actor> ());
			}

			if (target == null) {
				target = colActor;
				isWalking = false;
				//isAttacking = true;
			}
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == gameObject.tag && col.gameObject.GetComponent<Projectile> () == null) {
			Actor colActor = col.gameObject.GetComponent<Actor>();

			//check to see if it is already in target list (it should be, but never hurts to prevent future bugs:P), then remove
			if (targetsInRange.Contains (colActor)) {
				targetsInRange.Remove (colActor);
			}

			if (colActor == target) {
				//isAttacking = false;
				isWalking = true;
				target = null;
			}
		}
	}
}
