using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//needed for the Inspector to show these when called by another class
[System.Serializable]

public class Stats {
	//defensive stats
	public int hp; //hit points
	public int maxHP;
	public float dodge; //% to negate all dmg
	public float block; //% to negate physical dmg
	public int pDef; //physical defense
	public int mDef; //magic defense
	public int brace; //if charged: negate enemy charge bonus, gain bonus dmg
	public float speed;

	//offensive stats
	public float range; //multiplier to trigger size on init, might need to only have this on weapon :-x
	public int attsp; //attack speed
	public int patt; //physical Attack
	public int matt; //magical attack
	public int charge; //dmg bonus first few rounds of combat
}
