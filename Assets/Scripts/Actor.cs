using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

	//stats
	public Stats stats;

	//physics
	public Rigidbody2D rb;
	public CircleCollider2D trigger;
	public BoxCollider2D col;

	//ai control stuff
	public bool isWalking;
	public bool isBeingTaunted = false;
	public int lastAttackFrame = 0;
	public Actor target;
	public List<Actor> targetsInRange = new List<Actor> ();

	//animation/looks
	public SpriteRenderer spriteR;

	public void Awake(){
		//make new stats
		stats = new Stats ();

		if (GetComponent<Rigidbody2D> () != null) {
			rb = GetComponent<Rigidbody2D> ();
		}
			
		if (GetComponent<SpriteRenderer> () != null) {
			spriteR = GetComponent<SpriteRenderer> ();

			//set starting color (depending on team in later versions, black for now)
			spriteR.color = new Color(0.01f,0.01f,0.01f,1f);		
		} 

		if (GetComponent<CircleCollider2D> () != null) {
			trigger = GetComponent<CircleCollider2D> ();
		} 

		if (GetComponent<BoxCollider2D> () != null) {
			col = GetComponent<BoxCollider2D> ();
		} 
	}

	public void Start(){
		//modify trigger size by multiplying with range
		if (trigger) {
			trigger.radius = stats.triggerRange;
		}
	}

	//unity...
	public void Update(){
		//unity...
		if (rb && rb.IsSleeping ()) {
			rb.WakeUp ();
		}
	}

	public void WalkForward (){
		Vector2 p = new Vector2(0,stats.speed * Time.deltaTime);
		transform.Translate (p);
	}

	public void LookAt(Vector2 targetToLookAt){
		Vector2 direction = (targetToLookAt - (Vector2) transform.position).normalized;
		transform.up = direction;
	}

	public virtual void Attack(){
		
	}

	//same for each class, CheckIfViableTarget are the conditions to check for for each ai type/class
	public void FindNewTarget(){
		foreach(Actor possibleTarget in targetsInRange){
			if (CheckIfViableTarget (possibleTarget) == true) {
				target = possibleTarget;
			}
		}
	}

	public virtual bool CheckIfViableTarget (Actor possibleTarget){
		return(false);
	}

	public Actor Spawn(GameObject targetPrefab, GameObject creator){
		Vector2 spawnPos = transform.position + transform.up * spriteR.size.y; //@@ can change to x on purpose: its wider, to avoid collider triggering
		GameObject clone = GameObject.Instantiate(targetPrefab, spawnPos, transform.rotation);
		clone.tag = creator.tag;
		return (clone.GetComponent<Actor>());
	}

	public void GetDamage(int attackerPatt, int attackerMatt){
		//need to allow dodge first
		if (Random.Range (0f, 1f) > stats.dodge) {
			//check if attack has physical att, check for block chance, then do physical damage
			if (attackerPatt > 0 && Random.Range (0f, 1f) > stats.block) {
				stats.hp -= Mathf.RoundToInt ((float)attackerPatt * 0.1f + ((float)attackerPatt - stats.pDef) * 0.9f);
			} 
			if (attackerPatt < 0) {
				stats.hp -= Mathf.RoundToInt ((float)attackerPatt * 0.1f + ((float)attackerPatt + stats.pDef) * 0.9f);
			}
			//check if attack has magical att, then do magical damage
			if (attackerMatt > 0) {
				stats.hp -= Mathf.RoundToInt ((float)attackerMatt * 0.1f + ((float)attackerMatt - stats.mDef) * 0.9f);
			}
			if (attackerMatt < 0) {
				stats.hp -= Mathf.RoundToInt ((float)attackerMatt * 0.1f + ((float)attackerMatt + stats.mDef) * 0.9f);
			}

			//recolor sprite based on new hp
			Recolor ();
		}

		//Debug.Log ("attackerpatt = " + attackerPatt + ", attackermatt = " + attackerMatt);
		//Debug.Log (gameObject.name + " only has " + stats.hp + " out of " + stats.maxHP + " left!");

		//clamp at max hp
		if (stats.hp > stats.maxHP) {
			stats.hp = stats.maxHP;
		}

		//destroy object if hp <= 0
		if (stats.hp <= 0) {
			Destroy (gameObject);
		}
	}

	//used to recolor sprites based on dmg taken, called in Attack()
	public void Recolor (){
		Color ogColor = spriteR.color;
		float hpPercent = (float)stats.hp / stats.maxHP;
		//float red = (1 - hpPercent);
		//float green = ogColor.g * hpPercent;
		//float blue = ogColor.b * hpPercent;

		//Debug.Log ("color before: r=" + red + " g=" + green + " b=" + blue);
		//spriteR.color = new Color (red,green,blue,1f);
		spriteR.color = new Color (ogColor.r,ogColor.g,ogColor.b,(0.4f + hpPercent)/1.4f);
		//Debug.Log ("color after: r=" + red + " g=" + green + " b=" + blue);
	}

	void OnDestroy(){
		//Debug.Log (gameObject.name + " has been destroyed, oh noes!");
	}
}
