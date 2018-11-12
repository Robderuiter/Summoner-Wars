using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Healer {

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 200;
		stats.hp = 200;
		stats.dodge = 0.1f;
		stats.block = 0.3f;
		stats.pDef = 1;
		stats.mDef = 5;
		stats.brace = 0;
		stats.speed = 1f;

		//offensive stats
		stats.triggerRange = 8f;
		stats.attackRange = 8f;
		stats.attsp = 100; //currently the amount of frames between each attack
		stats.patt = 0;
		stats.matt = -20; //negative damage = +health
		stats.charge = 0;
	}

	public override void Attack (){
		target.GetDamage (stats.patt, stats.matt);
		target.isBeingHealed = true;

		if (target.stats.hp >= target.stats.maxHP) {
			target.stats.hp = target.stats.maxHP;
			target.isBeingHealed = false;
			FindNewTarget ();
		} 
	}
}
