using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	//public GameObject map;
	public GameObject coinDisplay;
	public GameObject miniCoinDisplay;
	public static GameObject staticCoinDisplay;
	public static GameObject miniStaticCoinDisplay;
	public static Items coin;

	public GameObject wbDisplay;
	public GameObject miniWBDisplay;
	public static GameObject staticWBDisplay;
	public static GameObject miniStaticWBDisplay;
	public static Items waterballon;

	public GameObject keyDisplay;
	public static GameObject staticKeyDisplay;
	public static Items key;

	public GameObject hkeyDisplay;
	public static GameObject staticHKeyDisplay;
	public static Items hkey;

	GameObject database;
	static ItemData itemData;

	public GameObject mainHUD;
	public GameObject miniHUD;
	bool mainHUDopen = true;

	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
		staticCoinDisplay = coinDisplay;
		staticWBDisplay = wbDisplay;
		miniStaticCoinDisplay = miniCoinDisplay;
		miniStaticWBDisplay = miniWBDisplay;
		staticKeyDisplay = keyDisplay;
		staticHKeyDisplay = hkeyDisplay;

		mainHUD.SetActive (mainHUDopen);
		miniHUD.SetActive (!mainHUDopen);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T)) {
			mainHUDopen = !mainHUDopen;
			mainHUD.SetActive (mainHUDopen);
			miniHUD.SetActive (!mainHUDopen);
		}
	}

	public static void DisplayUpdate(){

		/*Takes the Display for each item and updates them according to the 
		amount they have in stock. Also formats it in a x### mannor.*/
		coin = itemData.GetItemByID (7);
		staticCoinDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", coin.itemStock);
		miniStaticCoinDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", coin.itemStock);

		waterballon = itemData.GetItemByID (8);
		staticWBDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", waterballon.itemStock);
		miniStaticWBDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", waterballon.itemStock);

		key = itemData.GetItemByID (0);
		staticKeyDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", key.itemStock);

		hkey = itemData.GetItemByID (1);
		staticHKeyDisplay.transform.GetChild (0).GetComponent<Text> ().text = string.Format("{0:x00#}", hkey.itemStock);
	}

	public static void TakeDamage (float healthLoss) {

		/*If your health isn't at zero, [your last Health Load, the one furthest to the 
		 *left, isn't black] then you can take damage.*/
		if (Player.healthLoadList [0].GetComponent<Image> ().color != Color.black) {
			/*Once you press the 1 key then you will lose a bit of health [the Health 
			*Load will change to gray for 1/2 full and black for empty].*/
			for (int j = 0; j < healthLoss; j++) {
				for (int i = 0; i < Player.hLoads; i++) {
					if (Player.healthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color == Color.red) {
						Player.healthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color = Color.gray;
						Player.miniHealthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color = Color.gray;
						i = Player.hLoads;
					} else if (Player.healthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color == Color.gray) {
						Player.healthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color = Color.black;
						Player.miniHealthLoadList [(Player.hLoads - 1) - i].GetComponent<Image> ().color = Color.black;
						i = Player.hLoads;
					}
				}
			}
		} else {
			/*If you are out of health [the last Health load, the one furthest to the 
			 *left, isn't black] then you are dead.*/
			print ("You Have Died");
		}
	}

	public static void RestoreMana () {

		/*If you have increased your magic into a full magic box [the Magic 
		 *Load is default blue for every 4 points into your magic stats] you will 
		 *restore magic starting from the left most. It will only work if your 
		 *magic isn't full [the right most Magic Load isn't blue]. Magic will 
		 *restore to green 1/2 Magic and blue full Magic*/
		if ((Points.skill == 0) || (Points.skill == 1) || (Points.skill == 4) || (Points.skill == 5) || (Points.skill == 8)) {
			if (Player.magicLoadList [Player.mLoads - 1].GetComponent<Image> ().color != Color.blue) {
				Player.mTimer -= 0.05f;
				if (Player.mTimer <= 0) {
					for (int i = 0; i < Player.mLoads; i++) {
						if (Player.magicLoadList [i].GetComponent<Image> ().color == Color.white) {
							Player.magicLoadList [i].GetComponent<Image> ().color = Color.green;
							Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.green;
							Player.mTimer = Player.reMTimer;
							i = Player.mLoads;
						} else if (Player.magicLoadList [i].GetComponent<Image> ().color == Color.green) {
							Player.magicLoadList [i].GetComponent<Image> ().color = Color.blue;
							Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.blue;
							Player.mTimer = Player.reMTimer;
							i = Player.mLoads;
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
			if (Player.magicLoadList [Player.mLoads - 1].GetComponent<Image> ().color != Color.green) {
				Player.mTimer -= 0.05f;
				if (Player.mTimer <= 0) {
					for (int i = 0; i < Player.mLoads; i++) {
						if (Player.magicLoadList [i].GetComponent<Image> ().color == Color.white) {
							Player.magicLoadList [i].GetComponent<Image> ().color = Color.green;
							Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.green;
							Player.mTimer = Player.reMTimer;
							i =Player.mLoads;
						} else if (Player.magicLoadList [i].GetComponent<Image> ().color == Color.green) {
							Player.magicLoadList [i].GetComponent<Image> ().color = Color.blue;
							Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.blue;
							Player.mTimer = Player.reMTimer;
							i = Player.mLoads;
						}
					}	
				}
			}
		}
	}

	public static void AddHealthIcon (int x) {

		/*If the coresponding x is divisable by two it will make all the Health Loads red.*/
		if (x % 2 == 0) {
			Player.healthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.red;
			Player.miniHealthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.red;
			for (int i = 0; i < Player.hLoads; i++) {
				if (i < (Player.hLoads - 1)) {
					Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
					Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
				}
			}

		} else {
			/*If the coresponding x is not divisable by two it makes a new Health Load. 
			 *As well as increase the number of of Health Loads the system knows so it 
			 *can manage decreasing. It then turns the other loads red & repositions all 
			 *the loads to fit the new Health Load.*/
			Player.hLoads += 1;
			GameObject newHLoad = Instantiate (Player.staticHealthLoad);
			newHLoad.name = Player.staticHealthLoad.name + (Player.hLoads - 1);
			newHLoad.transform.SetParent (Player.staticHealthArea.transform);
			newHLoad.GetComponent<Image> ().color = Color.gray;
			Player.healthLoadList.Add (newHLoad);

			GameObject newMHLoad = Instantiate (Player.miniStaticHealthLoad);
			newMHLoad.name = Player.miniStaticHealthLoad.name + (Player.hLoads - 1);
			newMHLoad.transform.SetParent (Player.miniStaticHealthArea.transform);
			newMHLoad.GetComponent<Image> ().color = Color.gray;
			Player.miniHealthLoadList.Add (newMHLoad);

			for(int i = 0; i < Player.hLoads; i++){

				if (i < (Player.hLoads - 1)) {
					Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
					Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
				}

				Player.healthLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 30, 0, 0);
				Player.miniHealthLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 20, 0, 0);
			}
		} 

	}

	public static void AddManaIcon (int x) {

		/*If the coresponding x is divisable by two it will make all the Magic Loads 
		 *blue.*/
		if (x % 2 == 0) {
			Player.magicLoadList [Player.mLoads - 1].GetComponent<Image> ().color = Color.blue;
			Player.miniMagicLoadList [Player.mLoads - 1].GetComponent<Image> ().color = Color.blue;
			for (int i = 0; i < Player.mLoads; i++) {
				if (i < (Player.mLoads - 1)) {
					Player.magicLoadList [i].GetComponent<Image> ().color = Color.blue;
					Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.blue;
				}
			}

		} else {
			/*If the coresponding x is not divisable by two it makes a new Magic Load. 
			 *As well as increase the number of of Magic Loads the system knows so it 
			 *can manage decreasing. It then turns the other loads blue & repositions all 
			 *the loads to fit the new Magic Load.*/
			Player.mLoads += 1;
			GameObject newMLoad = Instantiate (Player.staticMagicLoad);
			newMLoad.name =	Player.staticMagicLoad.name + (Player.mLoads - 1);
			newMLoad.transform.SetParent (Player.staticMagicArea.transform);
			newMLoad.GetComponent<Image> ().color = Color.green;
			Player.magicLoadList.Add (newMLoad);

			GameObject newMMLoad = Instantiate (Player.miniStaticMagicLoad);
			newMMLoad.name =	Player.miniStaticMagicLoad.name + (Player.mLoads - 1);
			newMMLoad.transform.SetParent (Player.miniStaticMagicArea.transform);
			newMMLoad.GetComponent<Image> ().color = Color.green;
			Player.miniMagicLoadList.Add (newMMLoad);

			for (int i = 0; i < Player.mLoads; i++) {
				if (i < (Player.mLoads - 1)) {
					Player.magicLoadList [i].GetComponent<Image> ().color = Color.blue;
					Player.miniMagicLoadList [i].GetComponent<Image> ().color = Color.blue;
				}
				Player.magicLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 30, -40, 0);
				Player.miniMagicLoadList [i].GetComponent<RectTransform> ().localPosition = new Vector3 (i * 20, 0, 0);
			}
		}

	}

	public static void AddPermIcon (Items item) {

		GameObject parent = GameObject.Find ("Icon_Area");
		item.item = new GameObject ();
		item.item.gameObject.transform.SetParent (parent.gameObject.transform);
		item.item.transform.localPosition = new Vector3 (0, ((parent.transform.childCount-1) * -40), 0);
		item.item.AddComponent<Image> ().sprite = item.itemIcon;
		item.item.name = item.itemName;
		item.item.GetComponent<RectTransform> ().sizeDelta = new Vector2(35, 35);
	}
		
}
