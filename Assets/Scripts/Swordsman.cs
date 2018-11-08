using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Infantry {

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
		stats.range = 2f;
		stats.attsp = 20; //currently the amount of frames between each attack
		stats.patt = 10;
		stats.matt = 0;
		stats.charge = 0;
	}

	public override void Attack (){
		attackTarget.GetDamage (stats.patt);
	}
}
