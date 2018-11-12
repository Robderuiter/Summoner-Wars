using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Tank {
	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 100;
		stats.hp = stats.maxHP;
		stats.dodge = 0.1f;
		stats.block = 0.5f;
		stats.pDef = 10;
		stats.mDef = 10;
		stats.brace = 10;
		stats.speed = 1f;

		//offensive stats
		stats.triggerRange = 4f;
		stats.attackRange = 4f;
		stats.attsp = 100; //currently the amount of frames between each attack
		stats.patt = 0;
		stats.matt = 0;
		stats.charge = 0;
	}

	public override void Attack (){
		if (target.target != this){// && !target.isBeingTaunted) {
			target.target = this;
			target.isBeingTaunted = true;
		} else {
			target.isBeingTaunted = false;
			FindNewTarget ();
		}

	}
}
