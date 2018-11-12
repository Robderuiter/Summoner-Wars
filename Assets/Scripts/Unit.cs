using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Actor {

	public new void Start(){
		base.Start ();

		//infantry always just starts off walking
		isWalking = true;
	}

	public new void Update(){
		base.Update ();

		//walk forward when bool is on
		if (isWalking) {
			WalkForward ();
		}

		//look at target if you have one
		if (target) {
			LookAt (target.transform.position);
		}

		//attack target when distance is close enough
		if (target && Vector2.Distance(transform.position, target.transform.position) < stats.attackRange) {
			if (Time.frameCount - lastAttackFrame > stats.attsp) {
				Attack ();
				lastAttackFrame = Time.frameCount;
			}
		}
	}

	//same for each class, CheckIfViableTarget are the conditions to check for for each ai type/class
	public void FindNewTarget(){
		foreach(Actor possibleTarget in targetsInRange){
			if (CheckIfViableTarget (possibleTarget) == true) {
				target = possibleTarget;
			}
		}
	}

	public virtual bool CheckIfViableTarget (Actor possibleTarget){
		//every function needs a return path:P this base doesnt get overwritten bij Melee or Ranged (yet?)
		return(true);
	}

}
