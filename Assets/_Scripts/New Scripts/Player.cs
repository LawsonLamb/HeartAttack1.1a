using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject specialLoad;
	public GameObject specialArea;
	public GameObject miniSpecialLoad;
	List<GameObject> speicalLoadList = new List<GameObject> ();
	float energy = 90;
	float energyDec;
	float sTimer = 20f;
	public static float reSTimer;
	public static float preCoolDown = 10f;
	int sLoads = 5;
	bool specialCoolDown;
	bool preSpecialCoolDown;

	public GameObject magicLoad;
	public GameObject magicArea;
	public GameObject miniMagicLoad;
	public GameObject miniMagicArea;

	public static GameObject staticMagicLoad;
	public static GameObject staticMagicArea;
	public static GameObject miniStaticMagicLoad;
	public static GameObject miniStaticMagicArea;

	public static List<GameObject> magicLoadList = new List<GameObject> ();
	public static List<GameObject> miniMagicLoadList = new List<GameObject> ();
	public static float mTimer = 5f;
	public static float reMTimer;
	public static int mLoads = 3;

	public GameObject healthLoad;
	public GameObject healthArea;
	public GameObject miniHealthLoad;
	public GameObject miniHealthArea;

	public static GameObject staticHealthLoad;
	public static GameObject staticHealthArea;
	public static GameObject miniStaticHealthLoad;
	public static GameObject miniStaticHealthArea;

	public static List<GameObject> healthLoadList = new List<GameObject> ();
	public static List<GameObject> miniHealthLoadList = new List<GameObject> ();
	public static int hLoads = 3;

	public static float dmg = 7f;
	public static float defib = 0f;

	public static float mDmg = 10f;
	public static float aVera = 0f;

	public static float def = 1.0f;
	public static float pMaker = 0f;

	public static float speed = .05f;
	public static float adren = 0f;

	public static int points = 30;
	public GameObject statbox;
	public static bool On = false;

	GameObject database;
	ItemData item;
	AttackDatabase attData;

	Vector3 pos;

	public static Items buff = new Items ();
	public static float bTimer;
	public static float saveBTimer;

	public GameObject statText;
	public static Transform firePoint;

	public static int enemyKillCount = 0;
	// Use this for initialization
	void Start () {

		//Find the Databases
		database = GameObject.FindGameObjectWithTag ("Database");
		item = database.GetComponent<ItemData> ();
		attData = database.GetComponent<AttackDatabase> ();

		//Creates all the Special Skill Load Boxes.
		for (int s = 0; s < sLoads; s++){
			GameObject newSLoad = Instantiate (specialLoad);
			newSLoad.name = specialLoad.name + s;
			newSLoad.transform.SetParent (specialArea.transform);
			newSLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (0, ((-80) +(s*20)), 0);
			speicalLoadList.Add (newSLoad);
		}

		//Lets the Mini Specail Load bar have something to use for decreasing.
		energyDec = energy / sLoads;

		//So you can access the Magic Load Boxes. 
		staticMagicLoad = magicLoad;
		staticMagicArea = magicArea;
		miniStaticMagicLoad = miniMagicLoad;
		miniStaticMagicArea = miniMagicArea;

		//Creates the inital Magic Load Boxes.
		for (int m = 0; m < mLoads; m++) {
			GameObject newMLoad = Instantiate (magicLoad);
			newMLoad.name = magicLoad.name + m;
			newMLoad.transform.SetParent (magicArea.transform);
			newMLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (m * 30, -40 , 0);
			newMLoad.GetComponent<Image> ().color = Color.blue;
			magicLoadList.Add (newMLoad);

			GameObject newMMLoad = Instantiate (miniMagicLoad);
			newMMLoad.name = miniMagicLoad.name + m;
			newMMLoad.transform.SetParent (miniMagicArea.transform);
			newMMLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (m * 20, 0 , 0);
			newMMLoad.GetComponent<Image> ().color = Color.blue;
			miniMagicLoadList.Add (newMMLoad);
		}

		//So you can access the Health Load Boxes.
		staticHealthLoad = healthLoad;
		staticHealthArea = healthArea;
		miniStaticHealthLoad = miniHealthLoad;
		miniStaticHealthArea = miniHealthArea;

		//Creates the inital Health Load Boxes.
		for (int h = 0; h < hLoads; h++) {
			GameObject newHLoad = Instantiate (healthLoad);
			newHLoad.name = healthLoad.name + h;
			newHLoad.transform.SetParent (healthArea.transform);
			newHLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (h * 30, 0, 0);
			newHLoad.GetComponent<Image> ().color = Color.red;
			healthLoadList.Add (newHLoad);

			GameObject newMHLoad = Instantiate (miniHealthLoad);
			newMHLoad.name = miniHealthLoad.name + h;
			newMHLoad.transform.SetParent (miniHealthArea.transform);
			newMHLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (h * 20, 0, 0);
			newMHLoad.GetComponent<Image> ().color = Color.red;
			miniHealthLoadList.Add (newMHLoad);
		}

		//Makes sure when you start that you can use your Special Skill.
		specialCoolDown = false;
		preSpecialCoolDown = false;
		reMTimer = mTimer;
		reSTimer = sTimer;

		//Used to allow the player to move around on the screen.
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//Turn on and off your stat box (Will later be controlled by a NPC).
		statbox.SetActive (On);

		//Using Regualr and Special skills also has restoring your magic inside.
		PlayerAttType ();

		//How the player will move around the screen.
		PlayerMovement ();

		//Any Buff items that were picked up, so they can be cooled down.
		if (buff.openIt == true) {
			bTimer -= 0.05f;
			CoolDownBuff ();
		}

		//If you picked up the Transfusion Perm Item.
		if (item.item [18].openIt == true) {
			Transfusion ();
		}

		//Just a display so I can check status stuff.
		statText.GetComponent<Text> ().text = "Your Current Stats are: " + "\n M.Dmg: " + mDmg  + "\n Dmg: " + dmg
			+ "\n Defense: " + def  + "\n Speed: " + speed;


	}

	void PlayerAttType () {
	
		Special ();

		/*If you arent compeletly out of magic to use [the last Magic Load, the farthest
		 *to the left, isn't white], then You can use any of the arrow keys to shoot 
		 *your Regular Skill.*/
		if (magicLoadList [0].GetComponent<Image> ().color != Color.white) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = reMTimer;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = reMTimer;
							i = mLoads;
						}
					}
				}
				/*Finds the point in with the ability will come out of. Sends that as well 
				 *as the direction (so the item knows if its going up, down, left, or right) 
				 *to the attack manager.*/
				firePoint = gameObject.transform.GetChild (0).gameObject.transform;
				AttackManager.UseRegAtt (0, firePoint);
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = reMTimer;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = reMTimer;
							i = mLoads;
						}
					}
				}
				/*Finds the point in with the ability will come out of. Sends that as well 
				 *as the direction (so the item knows if its going up, down, left, or right) 
				 *to the attack manager.*/
				firePoint = gameObject.transform.GetChild (2).gameObject.transform;
				AttackManager.UseRegAtt (1, firePoint);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = reMTimer;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = reMTimer;
							i = mLoads;
						}
					}
				}
				/*Finds the point in with the ability will come out of. Sends that as well 
				 *as the direction (so the item knows if its going up, down, left, or right) 
				 *to the attack manager.*/
				firePoint = gameObject.transform.GetChild (1).gameObject.transform;
				AttackManager.UseRegAtt (2, firePoint);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = reMTimer;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							miniMagicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = reMTimer;
							i = mLoads;
						}
					}
				}
				/*Finds the point in with the ability will come out of. Sends that as well 
				 *as the direction (so the item knows if its going up, down, left, or right) 
				 *to the attack manager.*/
				firePoint = gameObject.transform.GetChild (3).gameObject.transform;
				AttackManager.UseRegAtt (3, firePoint);
			} else {
				/*If you are out of magic [The last Mana Load, the one furthest to the 
				left, is white], then nothing will happen.*/
			}
		}

		//Calling the fuction for restoring your magic.
		HUD.RestoreMana ();

		/*If you press Space and you happen to have a bomb in stock it will create the 
		 *GameObject for it and decrease your bomb stock, else it will do nothing*/
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (item.item [8].itemStock > 0) {

				CreateWaterBallons (item.item[8]);
				item.item [8].itemStock -= 1;
				HUD.DisplayUpdate ();
			} else {
				print ("You are out of Waterballoons");
			}
		}
	}

	void Special() {

		/*If you aren't waiting for your Special Skill to cool down then when 
		 *you press Q you will turn alll the Special Skill Loads to yellow. As
		 *well as use your Specail Skill, the players current magic damage will 
		 *also be sent, and the Special Skill begin to cool down.*/
		if ((preSpecialCoolDown == false) && (specialCoolDown == false)) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				for(int i = 0; i< sLoads; i++){
					speicalLoadList [i].GetComponent<Image> ().color = Color.yellow;
				}
				firePoint = gameObject.transform.GetChild (4).gameObject.transform;
				AttackManager.UseSpecialAtt (4, firePoint);
				sTimer = reSTimer;
				energy = 0;
				miniSpecialLoad.transform.localScale = new Vector3 (energy, 1, 1);
				preSpecialCoolDown = true;
			}
		} 

		if(preSpecialCoolDown == true) {
			print (preCoolDown);
			preCoolDown -= .05f;
			if (preCoolDown <= 0) {
				if ((AttackManager.currSpecAtt.attID >= 5) && (AttackManager.currSpecAtt.attID <= 9)) {
					if (AttackManager.currSpecAtt.attID == 5) {
						Player.dmg -= 10f;
						Player.mDmg -= 5f;
						Player.def -= 5.0f;
						Player.speed -= .25f;
						GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
					} else if (AttackManager.currSpecAtt.attID == 6) {
						Player.dmg -= 15f;
						Player.mDmg -= 10f;
						Player.def -= 5.5f;
						Player.speed -= .5f;
						GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
					} else if (AttackManager.currSpecAtt.attID == 7) {
						Player.dmg -= 20f;
						Player.mDmg -= 15f;
						Player.def -= 6.0f;
						Player.speed -= .75f;
						GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
					} else if (AttackManager.currSpecAtt.attID == 8) {
						Player.dmg -= 25f;
						Player.mDmg -= 20f;
						Player.def -= 6.5f;
						Player.speed -= 1.0f;
						GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
					}  else {
						Player.dmg -= 30f;
						Player.mDmg -= 25f;
						Player.def -= 7.0f;
						Player.speed -= 1.25f;
						GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
					}
					print ("Your stats are unbuffed.");
				} else if ((AttackManager.currSpecAtt.attID >= 15) && (AttackManager.currSpecAtt.attID <= 19)) {
				} else if ((AttackManager.currSpecAtt.attID >= 25) && (AttackManager.currSpecAtt.attID <= 29)) {
					print ("Cupid Will be destoryed.");
					Destroy (GameObject.Find ("Cupid_Follower"));
				}
				specialCoolDown = true;
				preCoolDown += 10f;
				preSpecialCoolDown = false;
			}
		}

		if (specialCoolDown == true) {
			/*The Specail Skill is being cool down so a timer will decrease and it 
			 *will slowly change the Specail Skill Loads from Yellow back to white. 
			 *Starting from the bottom, once the load on top has been turned white 
			 *the cool down will be deactivated.*/
			sTimer -= .05f;
			if (sTimer <= 0) {
				for (int i = 0; i < sLoads; i++) {
					if (speicalLoadList [i].GetComponent<Image> ().color == Color.yellow) {
						energy += energyDec;
						miniSpecialLoad.transform.localScale = new Vector3 (energy/90, 1, 1);
						speicalLoadList [i].GetComponent<Image> ().color = Color.white;
						if (speicalLoadList [4].GetComponent<Image> ().color == Color.white) {
							specialCoolDown = false;
						}
						sTimer = reSTimer;
						return;
					}
				}
			}
		}
	}

	public static void UpdateStatus (int x, int y, int z, int k) {

		//Takes the coresponding x (attack), y (heart), z (skill), and k(speed) and Updates the player stats when called.
		dmg =  (7 + defib) + (x * 3f);

		def = (1.0f + pMaker) + (y * 0.5f);

		reMTimer = 5f - (z * 0.5f);
		mDmg = (10 + aVera) + (z * 5f);

		speed = (0.05f + adren) + (k * 0.05f);
		reSTimer = 10f - (k * 0.625f);

	}

	void CreateWaterBallons (Items item) {
		/*Makes the bomb active and creates a new gameobject and names it Dropped Bomb*/
		item.openIt = true;
		item.item = new GameObject();
		item.item.gameObject.name = "Dropped " + item.itemName;
		item.item.AddComponent<SpriteRenderer> ().sprite = item.itemIcon;
		item.item.AddComponent<BoxCollider2D> ();
		item.item.AddComponent<Rigidbody2D> ();
		item.item.AddComponent<WaterBalloons> ();
		item.item.transform.localScale = new Vector3 (5, 5, 1);
		firePoint = gameObject.transform.GetChild (3).gameObject.transform;
		item.item.transform.localPosition = firePoint.position;
	}

	void PlayerMovement () {

		//Just a basic way for the player to move around the screen.
		if (Input.GetKey (KeyCode.W)) {
			pos.y += speed;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= speed;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += speed;
		} else {
		}

		gameObject.transform.position = pos;

	}

	void CoolDownBuff () {
	

		if (bTimer >= 0) {
			//If cool down was called but you still have time in your timer nothing will happen
		} else {
			/*Once the timer hits zero it will check with buff was activated and return your 
			 *stats back to how they should be without the buff. It will also rest the buff 
			 *items information.*/
			if (buff.itemID == 3) {
				Player.speed -= buff.itemsChange;
			} else if (buff.itemID == 4) {
				Player.def -= buff.itemsChange;
			} else if (buff.itemID == 5) {
				Player.dmg -= buff.itemsChange;
			} else {
				Player.mDmg -= buff.itemsChange;
			}
			buff.openIt = false;
			buff.itemDuration = saveBTimer;
		}

	}

	void Transfusion () {
		/*Once you pick this up after 10 enemy kills you will restore half health.*/
		if (enemyKillCount == 10) {
		/*If you have increased your health into a full health box [the Health 
		 *Load is default red for every 4 points into your heart stats] you will 
		 *restore health starting from the left most. It will only work if your 
		 *health isn't full [the right most Health Load isn't red]. Health will 
		 *restore to gray 1/2 Health and red full health*/
			if (Points.heart % 4 == 0) {
				if (healthLoadList [hLoads - 1].GetComponent<Image> ().color != Color.red) {
					for (int i = 0; i < hLoads; i++) {
						if (healthLoadList [i].GetComponent<Image> ().color == Color.black) {
							healthLoadList [i].GetComponent<Image> ().color = Color.gray;
							miniHealthLoadList [i].GetComponent<Image> ().color = Color.gray;
							i = hLoads;
						} else if (healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
							healthLoadList [i].GetComponent<Image> ().color = Color.red;
							miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
							i = hLoads;
						}
					}
				} else {
				}

			} else {
				/*If you haven't increased your health into a full health box [the Health 
			 *Load is default gray for every 2 points into your heart stats] you will 
			 *restore health starting from the left most. It will only work if your 
			 *health isn't full [the right most Health Load isn't gray]. Health will 
			 *restore to gray 1/2 Health and red full health*/
				if (healthLoadList [hLoads - 1].GetComponent<Image> ().color != Color.gray) {
					for (int i = 0; i < hLoads; i++) {
						if (healthLoadList [i].GetComponent<Image> ().color == Color.black) {
							healthLoadList [i].GetComponent<Image> ().color = Color.gray;
							miniHealthLoadList [i].GetComponent<Image> ().color = Color.gray;
							i = hLoads;
						} else if (healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
							healthLoadList [i].GetComponent<Image> ().color = Color.red;
							miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
							i = hLoads;
						}
					}
				} else {
				}
			}
			enemyKillCount = 0;
		}
		print ("I Can steal love");
		print (enemyKillCount);
	}
		
}
