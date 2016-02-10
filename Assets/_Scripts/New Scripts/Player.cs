using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public GameObject specialLoad;
	public GameObject specialArea;
	List<GameObject> speicalLoadList = new List<GameObject> ();
	float sTimer = 10f;
	int sLoads = 5;
	bool specialCoolDown;

	public GameObject magicLoad;
	public static GameObject staticMagicLoad;
	public GameObject magicArea;
	public static GameObject staticMagicArea;
	public static List<GameObject> magicLoadList = new List<GameObject> ();
	public static float mTimer = 5f;
	public static int mLoads = 3;

	public GameObject healthLoad;
	public static GameObject staticHealthLoad;
	public GameObject healthArea;
	public static GameObject staticHealthArea;
	public static List<GameObject> healthLoadList = new List<GameObject> ();
	public static int hLoads = 3;

	public static float dmg = 7f;
	public static float mDmg = 10f;
	public static float def = 1.0f;
	public static float speed = .05f;

	public static int points = 30;
	public GameObject statbox;
	bool On = false;

	GameObject database;
	ItemData item;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		item = database.GetComponent<ItemData> ();

		//Creates all the Special Skill Load Boxes.
		for (int s = 0; s < sLoads; s++){
			GameObject newSLoad = Instantiate (specialLoad);
			newSLoad.name = specialLoad.name + s;
			newSLoad.transform.SetParent (specialArea.transform);
			newSLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (0, ((-80) +(s*20)), 0);
			speicalLoadList.Add (newSLoad);
		}

		//So you can access the Magic Load Boxes. 
		staticMagicLoad = magicLoad;
		staticMagicArea = magicArea;

		//Creates the inital Magic Load Boxes.
		for (int m = 0; m < mLoads; m++) {
			GameObject newMLoad = Instantiate (magicLoad);
			newMLoad.name = magicLoad.name + m;
			newMLoad.transform.SetParent (magicArea.transform);
			newMLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (m*30, -40 , 0);
			newMLoad.GetComponent<Image> ().color = Color.blue;
			magicLoadList.Add (newMLoad);
		}

		//So you can access the Health Load Boxes.
		staticHealthLoad = healthLoad;
		staticHealthArea = healthArea;

		//Creates the inital Health Load Boxes.
		for (int h = 0; h < hLoads; h++) {
			GameObject newHLoad = Instantiate (healthLoad);
			newHLoad.name = healthLoad.name + h;
			newHLoad.transform.SetParent (healthArea.transform);
			newHLoad.GetComponent<RectTransform> ().localPosition = new Vector3 (h * 30, 0, 0);
			newHLoad.GetComponent<Image> ().color = Color.red;
			healthLoadList.Add (newHLoad);
		}

		//Makes sure when you start that you can use your Special Skill.
		specialCoolDown = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Turn on and off your stat box (Will later be controlled by a NPC).
		if (Input.GetKeyDown (KeyCode.S)) {
			On = !On;
			statbox.SetActive (On);
		}

		//Using Regualr and Special skills also has restoring your magic inside
		PlayerAttType ();


	}

	void PlayerAttType () {
	
		/*If you aren't waiting for your Special Skill to cool down then when 
		 *you press Q you will turn alll the Special Skill Loads to yellow. As
		 *well as use your Specail Skill, the players current magic damage will 
		 *also be sent, and the Special Skill begin to cool down.*/
		if (specialCoolDown == false) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				for(int i = 0; i< sLoads; i++){
					speicalLoadList [i].GetComponent<Image> ().color = Color.yellow;
				}
				AttackManager.UseSpecialAtt (mDmg);
				specialCoolDown = true;
			}
		} else {
			/*The Specail Skill is being cool down so a timer will decrease and it 
			 *will slowly change the Specail Skill Loads from Yellow back to white. 
			 *Starting from the bottom, once the load on top has been turned white 
			 *the cool down will be deactivated.*/
			sTimer -= .05f;
			if (sTimer <= 0) {
				for (int i = 0; i < sLoads; i++) {
					if (speicalLoadList [i].GetComponent<Image> ().color == Color.yellow) {
						speicalLoadList [i].GetComponent<Image> ().color = Color.white;
						if (speicalLoadList [4].GetComponent<Image> ().color == Color.white) {
							specialCoolDown = false;
						}
						sTimer = 10f;
						return;
					}
				}
			}
		}

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
							mTimer = 5f;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = 5f;
							i = mLoads;
						}
					}
				}
				AttackManager.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = 5f;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = 5f;
							i = mLoads;
						}
					}
				}
				AttackManager.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = 5f;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = 5f;
							i = mLoads;
						}
					}
				}
				AttackManager.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana, depending 
				 *on the currRegAtt, [the Magic load will change to green for 1/2 full and 
				 *White for empty]. You will then shoot your Regular Skill, as well as 
				 *restart the time for the magic restoration.*/
				for (int j = 0; j < AttackManager.currRegAtt.manaUse; j++) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
							mTimer = 5f;
							i = mLoads;
						} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
							mTimer = 5f;
							i = mLoads;
						}
					}
				}
				AttackManager.UseRegAtt (dmg);
			} else {
				/*If you are out of magic [The last Mana Load, the one furthest to the 
				left, is white], then nothing will happen.*/
			}
		}

		//Calling the fuction for restoring your magic.
		HUD.RestoreMana ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (item.item [8].itemStock > 0) {

				CreateWaterBallons (item.item[8]);
				item.item [8].itemStock -= 1;
			} else {
				print ("You are out of Waterballoons");
			}
		}
	}

	public static void UpdateStatus (int x, int y, int z, int k) {

		//Takes the coresponding x, y, z, and k and Updates the player stats when called.
		dmg =  7 + (x * 3f);
		mDmg = 10 + (y * 5f);
		def = 1.0f + (z * 0.5f);
		speed = 0.05f + (k * 0.05f);

	}

	void CreateWaterBallons (Items item) {
		item.openIt = true;
		GameObject wb = new GameObject ();
		wb.gameObject.name = "Dropped " + item.itemName;
		wb.AddComponent<WaterBalloons> ();
	}

}
