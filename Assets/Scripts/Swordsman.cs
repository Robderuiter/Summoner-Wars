using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Unit {

	void Awake(){
		base.Awake ();

		//defensive stats
		hp = 100;
		dodge = 0.1f;
		block = 0.3f;
		pDef = 5;
		mDef = 3;
		brace = 0;
		speed = 3f;

		//offensive stats
		range = 1f;
		attsp = 1f;
		patt = 5;
		matt = 0;
		charge = 0;
	}

	// Update is called once per frame
	void Update () {
		Walk();
	}

	public override void Walk(){
		Vector2 p = new Vector2(0,speed * Time.deltaTime);
		transform.Translate (p);
	}
}
