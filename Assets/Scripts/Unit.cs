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
		if (aggroTarget) {
			LookAt (aggroTarget.position);
		}

		//attack target when something enters enters collider
		if (attackTarget) {
			if (Time.frameCount - lastAttackFrame > stats.attsp) {
				Attack ();
				lastAttackFrame = Time.frameCount;
			}
		}
	}
}
