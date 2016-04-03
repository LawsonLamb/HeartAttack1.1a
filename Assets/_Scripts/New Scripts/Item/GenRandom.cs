using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenRandom : MonoBehaviour {

	GameObject database;
	ItemData itemData;
	GameObject displays;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CreateShop (string name) {

		for (int i = 0; i < 3; i++) {
			int j = itemData.item[Random.Range(0,23)].ID;
			itemData.item [j].CreateGameObject (name, i);
		}
			
	}

	public void CreateRandomItem (string name) {

		for (int i = 0; i < 1; i++) {
			int j = itemData.item[Random.Range(0,23)].ID;
			itemData.item [j].CreateGameObject (name, i);
		}
	}

	public void LoveBoothItems (string name) {

		for (int i = 0; i < 1; i++) {
			int j = itemData.item[Random.Range(0,10)].ID;
			itemData.item [j].CreateGameObject (name, i);
		}
		itemData.item [7].Stock -= 1;
		displays.GetComponent<UIScripts>().SackUpdate ();
	}
}
