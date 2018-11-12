using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Melee {

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 100;
		stats.hp = stats.maxHP;
		stats.dodge = 0.1f;
		stats.block = 0.3f;
		stats.pDef = 4;
		stats.mDef = 3;
		stats.brace = 0;
		stats.speed = 1f;

		//offensive stats
		stats.triggerRange = 4f;
		stats.attackRange = 1.1f;
		stats.attsp = 20; //currently the amount of frames between each attack
		stats.patt = 15;
		stats.matt = 0;
		stats.charge = 0;
	}

	public override void Attack (){
		target.GetDamage (stats.patt, stats.matt);

	}
}
