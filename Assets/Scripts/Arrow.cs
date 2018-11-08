using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile {
	
	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.speed = 4f;

		//offensive stats
		stats.range = 1f;
	}
}
