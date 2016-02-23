using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenRandom : MonoBehaviour {

	public static GameObject database;
	public static ItemData itemData;

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static  void CreateShop (string name) {

		for (int i = 0; i < 3; i++) {
			int j = itemData.item[Random.Range(0,23)].itemID;
			itemData.item [j].CreateGameObject (name, i);
		}
			
	}

	void CreateRandomItem (string name) {

		for (int i = 0; i < 1; i++) {
			int j = itemData.item[Random.Range(0,23)].itemID;
			itemData.item [j].CreateGameObject (name, i);
		}
	}

	public static void LoveBoothItems (string name) {

		for (int i = 0; i < 1; i++) {
			int j = itemData.item[Random.Range(0,10)].itemID;
			itemData.item [j].CreateGameObject (name, i);
		}
		itemData.item [7].itemStock -= 1;
		HUD.DisplayUpdate ();
	}
}
