using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GenRandom : MonoBehaviour {

	GameObject database;
	ItemData itemData;
	GameObject displays;
	List <int> itemIDs = new List<int>();
	// Use this for initialization
	void Start () {

		AddIDS ();
		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void AddIDS() {
		itemIDs.Add (2);
		itemIDs.Add (7);
		itemIDs.Add (8);
		itemIDs.Add (12);
		itemIDs.Add (13);
		itemIDs.Add (14);
		itemIDs.Add (15);
		itemIDs.Add (16);
		itemIDs.Add (17);
	}

	public void CreateShop (string name) {

	}

	public void CreateRandomItem (string name) {

	}

	public void GuantletGen (string name) {

		for (int i = 0; i < 1; i++) {
			int j = Random.Range (0, 9);
			int k = itemIDs [j];
			itemData.item [k].CreateGameObject (name, i, k);
		}
	}

	public void LoveBoothItems (string name) {

		itemData.item [7].Stock -= 1;
		displays.GetComponent<UIScripts>().SackUpdate ();
	}
}
