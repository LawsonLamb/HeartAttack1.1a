using UnityEngine;
using System.Collections;

public class GenRandom : MonoBehaviour {

	GameObject database;
	ItemData itemData;

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			CreateRandomItem ();
		}
	}

	void CreateRandomItem () {

		for (int i = 0; i < 3; i++) {
			int j = itemData.item[Random.Range(18,23)].itemID;
			itemData.item [j].CreateGameObject ();
		}
	}
}
