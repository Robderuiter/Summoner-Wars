using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Ranged {

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 20;
		stats.hp = stats.maxHP;
		stats.dodge = 0.1f;
		stats.block = 0.3f;
		stats.pDef = 1;
		stats.mDef = 1;
		stats.brace = 0;
		stats.speed = 1f;

		//offensive stats
		stats.triggerRange = 16f;
		stats.attackRange = 16f;
		stats.attsp = 400; //currently the amount of frames between each attack
		stats.patt = 0;
		stats.matt = 50;
		stats.charge = 0;

		//get arrow gameobject
		projectile = (GameObject)Resources.Load("Fireball");
	}

	public override void Attack (){
		Actor clone = Spawn (projectile, this.gameObject); //prefabToSpawn, creatorGameObject
		clone.GetComponent<Projectile>().stats.matt = stats.matt;
		clone.GetComponent<Projectile>().target = target;
	}

}
