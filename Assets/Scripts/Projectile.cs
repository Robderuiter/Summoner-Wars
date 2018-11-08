using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Actor {

	float dist;
	Vector2 startPos;
	float startHeight = 0.6f;
	float maxHeight = 0.6f;

	public new void Start(){
		base.Start ();

		dist = Vector2.Distance (attackTarget.transform.position, transform.position);
		startPos = transform.position;
	}

	// Update is called once per frame
	public new void Update () {
		base.Update ();

		WalkForward ();
		FakeHeight ();
	}

	//set target for aggro if collider doesn't have the same tag as you and you don't already have a target for aggro
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag != gameObject.tag && !col.isTrigger) {
			attackTarget = col.gameObject.GetComponent<Actor>();
			attackTarget.GetDamage (stats.patt);
			Destroy (this.gameObject);
		}
	}

	//change localscale to create the illusion of height in projectiles
	void FakeHeight(){
		float distTravelled = Vector2.Distance(startPos,transform.position);
		float height = (1 - 4 * Mathf.Pow (distTravelled / dist - 0.5f, 2f)) * (maxHeight) + startHeight;
		if (height > 0) {
			transform.localScale = new Vector3 (height, height, 0f);
		}
	}
}
