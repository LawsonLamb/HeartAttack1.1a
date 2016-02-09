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
	static List<GameObject> magicLoadList = new List<GameObject> ();
	float mTimer = 5f;
	public static int mLoads = 3;

	public GameObject healthLoad;
	public static GameObject staticHealthLoad;
	public GameObject healthArea;
	public static GameObject staticHealthArea;
	static List<GameObject> healthLoadList = new List<GameObject> ();
	public static int hLoads = 3;

	public static float dmg = 7f;
	public static float mDmg = 10f;
	public static float def = 1.0f;
	public static float speed = .05f;

	public static int points = 30;
	public GameObject statbox;
	bool On = false;

	// Use this for initialization
	void Start () {

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

		/*Will later be under a enemy hitting your, but how your Health loads 
		 * will decrease.*/
		TakeDamage ();

		/*Will later be under health item for picking up, but how your health 
		 * will restore itself*/
		PickUpHealth ();

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
				//Attacks.UseSpecialAtt (mDmg);
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
				/*Once you press the arrow key then you will lose a bit of mana [the Magic 
				 *load will change to green for 1/2 full and White for empty]. You will 
				 *then shoot your Regular Skill, as well as restart the time for the magic restoration.*/
				for (int i = 0; i < mLoads; i++) {
					if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
						mTimer = 5f;
						return;
					} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
						mTimer = 5f;
						return;
					}
				}
				//Attacks.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana [the Magic 
				 *load will change to green for 1/2 full and White for empty]. You will 
				 *then shoot your Regular Skill, as well as restart the time for the magic restoration.*/
				for (int i = 0; i < mLoads; i++) {
					if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
						mTimer = 5f;
						return;
					} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
						mTimer = 5f;
						return;
					}
				}
				//Attacks.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana [the Magic 
				 *load will change to green for 1/2 full and White for empty]. You will 
				 *then shoot your Regular Skill, as well as restart the time for the magic restoration.*/
				for (int i = 0; i < mLoads; i++) {
					if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
						mTimer = 5f;
						return;
					} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
						mTimer = 5f;
						return;
					}
				}
				//Attacks.UseRegAtt (dmg);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				/*Once you press the arrow key then you will lose a bit of mana [the Magic 
				 *load will change to green for 1/2 full and White for empty]. You will 
				 *then shoot your Regular Skill, as well as restart the time for the magic restoration.*/
				for (int i = 0; i < mLoads; i++) {
					if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.blue) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.green;
						mTimer = 5f;
						return;
					} else if (magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color == Color.green) {
						magicLoadList [(mLoads - 1) - i].GetComponent<Image> ().color = Color.white;
						mTimer = 5f;
						return;
					}
				}
				//Attacks.UseRegAtt (dmg);
			} else {
				/*If you are out of magic [The last Mana Load, the one furthest to the 
				left, is white], then nothing will happen.*/
			}
		}

		//Calling the fuction for restoring your magic.
		RestoreMana ();
	}

	void TakeDamage () {

		/*If your health isn't at zero, [your last Health Load, the one furthest to the 
		 *left, isn't black] then you can take damage.*/
		if (healthLoadList [0].GetComponent<Image> ().color != Color.black) {
			/*Until theirs an enemy to put this under you can press 1 on the key board 
			 *to simulate taking damage.*/
			/*Once you press the 1 key then you will lose a bit of health [the Health 
			*Load will change to gray for 1/2 full and black for empty].*/
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				for (int i = 0; i < hLoads; i++) {
					if (healthLoadList [(hLoads - 1) - i].GetComponent<Image> ().color == Color.red) {
						healthLoadList [(hLoads - 1) - i].GetComponent<Image> ().color = Color.gray;
						return;
					} else if (healthLoadList [(hLoads - 1) - i].GetComponent<Image> ().color == Color.gray) {
						healthLoadList [(hLoads - 1) - i].GetComponent<Image> ().color = Color.black;
						return;
					}
				}
			}
		} else {
			/*If you are out of health [the last Health load, the one furthest to the 
			 *left, isn't black] then you are dead.*/
			print ("You Have Died");
		}
	}

	void PickUpHealth () {

		/*Until theirs an item put this under you can press 2 on the key board 
		*to simulate picking up health.*/
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
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
							return;
						} else if (healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
							healthLoadList [i].GetComponent<Image> ().color = Color.red;
							return;
						}
					}
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
							return;
						} else if (healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
							healthLoadList [i].GetComponent<Image> ().color = Color.red;
							return;
						}
					}
				}
			}
		}

	}

	void RestoreMana () {

		/*If you have increased your magic into a full magic box [the Magic 
		 *Load is default blue for every 4 points into your magic stats] you will 
		 *restore magic starting from the left most. It will only work if your 
		 *magic isn't full [the right most Magic Load isn't blue]. Magic will 
		 *restore to green 1/2 Magic and blue full Magic*/
		if (Points.skill % 4 == 0) {
			if (magicLoadList [mLoads - 1].GetComponent<Image> ().color != Color.blue) {
				mTimer -= 0.05f;
				if (mTimer <= 0) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [i].GetComponent<Image> ().color == Color.white) {
							magicLoadList [i].GetComponent<Image> ().color = Color.green;
							mTimer = 5f;
							return;
						} else if (magicLoadList [i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [i].GetComponent<Image> ().color = Color.blue;
							mTimer = 5f;
							return;
						}
					}	
				}
			}
		} else {
			/*If you haven't increased your magic into a full magic box [the Magic 
			 *Load is default green for every 2 points into your magic stats] you will 
			 *restore magic starting from the left most. It will only work if your 
			 *magic isn't full [the right most Magic Load isn't green]. Magic will 
			 *restore to green 1/2 Magic and blue full Magich*/
			if (magicLoadList [mLoads - 1].GetComponent<Image> ().color != Color.green) {
				mTimer -= 0.05f;
				if (mTimer <= 0) {
					for (int i = 0; i < mLoads; i++) {
						if (magicLoadList [i].GetComponent<Image> ().color == Color.white) {
							magicLoadList [i].GetComponent<Image> ().color = Color.green;
							mTimer = 5f;
							return;
						} else if (magicLoadList [i].GetComponent<Image> ().color == Color.green) {
							magicLoadList [i].GetComponent<Image> ().color = Color.blue;
							mTimer = 5f;
							return;
						}
					}	
				}
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

	public static void AddHealthIcon (int x) {

		/*If the coresponding x is divisable by two it will make all the Health Loads red.*/
		if (x % 2 == 0) {
			healthLoadList [hLoads - 1].GetComponent<Image> ().color = Color.red;
			for (int i = 0; i < hLoads; i++) {
				if (i < (hLoads - 1)) {
					healthLoadList [i].GetComponent<Image> ().color = Color.red;
				}
			}

		} else {
			/*If the coresponding x is not divisable by two it makes a new Health Load. 
			 *As well as increase the number of of Health Loads the system knows so it 
			 *can manage decreasing. It then turns the other loads red & repositions all 
			 *the loads to fit the new Health Load.*/
			hLoads += 1;
			GameObject newHLoad = Instantiate (staticHealthLoad);
			newHLoad.name = staticHealthLoad.name + (hLoads - 1);
			newHLoad.transform.SetParent (staticHealthArea.transform);
			newHLoad.GetComponent<Image> ().color = Color.gray;
			healthLoadList.Add (newHLoad);

			for(int i = 0; i < hLoads; i++){

				if (i < (hLoads - 1)) {
					healthLoadList [i].GetComponent<Image> ().color = Color.red;
				}

				healthLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 30, 0, 0);
			}
		} 
	
	}
	public static void AddManaIcon (int x) {

		/*If the coresponding x is divisable by two it will make all the Magic Loads 
		 *blue.*/
		if (x % 2 == 0) {
			magicLoadList [mLoads - 1].GetComponent<Image> ().color = Color.blue;
			for (int i = 0; i < mLoads; i++) {
				if (i < (mLoads - 1)) {
					magicLoadList [i].GetComponent<Image> ().color = Color.blue;
				}
			}

		} else {
			/*If the coresponding x is not divisable by two it makes a new Magic Load. 
			 *As well as increase the number of of Magic Loads the system knows so it 
			 *can manage decreasing. It then turns the other loads blue & repositions all 
			 *the loads to fit the new Magic Load.*/
			mLoads += 1;
			GameObject newMLoad = Instantiate (staticMagicLoad);
			newMLoad.name =	staticMagicLoad.name + (mLoads - 1);
			newMLoad.transform.SetParent (staticMagicArea.transform);
			newMLoad.GetComponent<Image> ().color = Color.green;
			magicLoadList.Add (newMLoad);

			for (int i = 0; i < mLoads; i++) {
				if (i < (mLoads - 1)) {
					magicLoadList [i].GetComponent<Image> ().color = Color.blue;
				}
				magicLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 30, -40, 0);
			}
		}

	}

}
