using UnityEngine;
using System.Collections;

public class Physical : MonoBehaviour {

	/*All that is missing now is the movement for the enemy. Speed is already set depending on the foe.
	This is a base Script since all enemeies will have a physcail script to them.*/
	GameObject database;
	FoeDatabase foeData;
	Foes foe;
	public static float health;
	public static int id;
	float speed;
	int dmg;

	public GameObject miniFoeHUD;
	public GameObject miniFoeHealthBar;
	public GameObject foeHUD;
	public GameObject foeHealthBar;
	public static GameObject statMiniFoeHUD;
	public static GameObject statMiniFoeHealthBar;
	public static GameObject statFoeHUD;
	public static GameObject statFoeHealthBar;

	public static float healthBarAmount;
	int hudCase = 0;
	bool mainHUDopen = true;
	bool bossIsAlive = false;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		foeData = database.GetComponent<FoeDatabase> ();
		foe = foeData.GetFoeByName (this.gameObject.name);
		statMiniFoeHUD = miniFoeHUD;
		statMiniFoeHealthBar = miniFoeHealthBar;

		statFoeHUD = foeHUD;
		statFoeHealthBar = foeHealthBar;
		SetFoeStats (foe);


	}
	
	// Update is called once per frame
	void Update () {

		if (bossIsAlive == true) {
			if (Input.GetKeyDown (KeyCode.T)) {
				if (hudCase == 0) {
					hudCase = 1;
				} else if (hudCase == 1) {
					hudCase = 2;
				} else {
					hudCase = 0;
				}
				SwitchHUD ();
			}
		}
	}

	void SetFoeStats (Foes foe) {
		health = foe.foeHealth;
		if ((foe.foeID >= 8) && (foe.foeID <= 10)) {
			healthBarAmount = health / 100;
			miniFoeHUD.SetActive (mainHUDopen);
			foeHUD.SetActive (!mainHUDopen);
			bossIsAlive = true;
			Boss.SetHUD (statFoeHUD, statMiniFoeHUD, statFoeHealthBar, statMiniFoeHealthBar, healthBarAmount, foe);
		}
		speed = foe.foeSpeed;
		dmg = foe.foeDmg;
		id = foe.foeID;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			HUD.TakeDamage (dmg);
		} else if (col.gameObject.tag == "Bullet") {
			health -= Player.dmg;
			if ((foe.foeID >= 8) && (foe.foeID <= 10)) {
				Boss.LoseHealth (healthBarAmount, health);
			}
			if (health <= 0) {
				Player.enemyKillCount += 1;
				if ((foe.foeID >= 8) && (foe.foeID <= 10)) {
					LevelManager.IncandCheckExp (50);
				} else {
					LevelManager.IncandCheckExp (5);
				} 
				if ((foe.foeID >= 5) && (foe.foeID <= 7)) {

				//	Spliter.SplitUp (id);

					//Spliter.SplitUp (id);

				}
				GenRandom.CreateRandomItem (gameObject.tag);
				miniFoeHUD.SetActive (!mainHUDopen);
				foeHUD.SetActive (!mainHUDopen);
				bossIsAlive = false;
				Destroy (gameObject);
			}
		}
	}
	public void SwitchHUD () {

		switch (hudCase) {
		case 0:
			miniFoeHUD.SetActive (mainHUDopen);
			foeHUD.SetActive (!mainHUDopen);
			break;
		case 1:
			miniFoeHUD.SetActive (!mainHUDopen);
			foeHUD.SetActive (mainHUDopen);
			break;
		case 2:
			miniFoeHUD.SetActive (!mainHUDopen);
			foeHUD.SetActive (!mainHUDopen);
			break;
		}
	}
}
