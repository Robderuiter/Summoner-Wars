using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

	//spawn stuff
	GameObject chosenPrefab;
	GameObject prefabChoice1;
	GameObject prefabChoice2;
	GameObject prefabChoice3;
	GameObject prefabChoice4;
	GameObject prefabChoice5;

	new void Awake(){
		base.Awake ();

		//defensive stats
		stats.maxHP = 100;
		stats.hp = stats.maxHP;
		stats.dodge = 0.1f;
		stats.block = 0.3f;
		stats.pDef = 5;
		stats.mDef = 3;
		stats.brace = 0;
		stats.speed = 2f;

		//offensive stats
		stats.triggerRange = 1f;
		stats.attackRange = 1f;
		stats.attsp = 1;
		stats.patt = 5;
		stats.matt = 0;
		stats.charge = 0;

		//swordsman prefab
		chosenPrefab = (GameObject) Resources.Load("Sword");

		prefabChoice1 = (GameObject) Resources.Load("Sword");
		prefabChoice2 = (GameObject) Resources.Load("Archer");
		prefabChoice3 = (GameObject) Resources.Load("Mage");
		prefabChoice4 = (GameObject) Resources.Load("Priest");
		prefabChoice5 = (GameObject) Resources.Load("Shield");
	}

	new void Update(){
		if (GetComponent<Rigidbody2D> () != null) {
			//player walks on user input (wasd)
			PlayerWalk();

			//player just looks at mouse all the time
			Vector2 mouseScrPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			LookAt (mouseScrPos);
		} 

		if (Input.GetMouseButtonDown (0)) {
			Spawn (chosenPrefab, this.gameObject);//prefabToSpawn, creatorGameObject
		}

		//switch chosenPrefab to Spawn() based on keyboard 1-9 input
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			chosenPrefab = prefabChoice1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			chosenPrefab = prefabChoice2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			chosenPrefab = prefabChoice3;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			chosenPrefab = prefabChoice4;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)){
			chosenPrefab = prefabChoice5;
		}
	}
		
	public void PlayerWalk(){
		Vector2 p =	GetBaseInput();
		p = p * stats.speed;
		p = p * Time.deltaTime;
		transform.Translate (p);
	}

	//move up/down/left/right
	private Vector2 GetBaseInput() {
		Vector2 p_Velocity = new Vector2();
		if (Input.GetKey (KeyCode.W)){
			p_Velocity += new Vector2(0, 1);
		}
		if (Input.GetKey (KeyCode.S)){
			p_Velocity += new Vector2(0, -1);
		}
		if (Input.GetKey (KeyCode.A)){
			p_Velocity += new Vector2(-1, 0);
		}
		if (Input.GetKey (KeyCode.D)){
			p_Velocity += new Vector2(1, 0);
		}
		return p_Velocity;
	}
}
