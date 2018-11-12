using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile {

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.speed = 3f;

		//used to change collider on Start(), 1x own size
		stats.triggerRange = 1f;
	}
}
