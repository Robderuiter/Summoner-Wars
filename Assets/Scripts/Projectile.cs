using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Actor {

	float distToTravel;
	float distTravelled;
	Vector2 startPos;
	float startHeight = 0.6f;
	float maxHeight = 0.6f;

	//temp
	Vector2 newTargetTransform;

	public new void Start(){
		base.Start ();

		newTargetTransform = target.transform.position + target.transform.up * target.stats.speed;
		LookAt (newTargetTransform);

		//determine distance to target and save startpos
		distToTravel = Vector2.Distance (newTargetTransform, transform.position);
		startPos = transform.position;

		//set size to startHeight
		transform.localScale = new Vector3 (startHeight, startHeight, 0f);

		col.enabled = false;
	}

	// Update is called once per frame
	public new void Update () {
		base.Update ();

		WalkForward ();
		distTravelled = Vector2.Distance(startPos,transform.position);
		FakeHeight ();

		if (distTravelled > 0.95 * distToTravel) {
			col.enabled = true;
		}
	}

	//set target for aggro if collider doesn't have the same tag as you and you don't already have a target for aggro
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && !col.isTrigger) {
			target = col.gameObject.GetComponent<Actor>();
			target.GetDamage (stats.patt, stats.matt);
			Destroy (this.gameObject);
		}
	}

	//change localscale to create the illusion of height in projectiles
	void FakeHeight(){
		float height = (1 - 4 * Mathf.Pow (distTravelled / distToTravel - 0.5f, 2f)) * (maxHeight) + startHeight;
		if (height > 0) {
			transform.localScale = new Vector3 (height, height, 0f);
		}
	}
}
