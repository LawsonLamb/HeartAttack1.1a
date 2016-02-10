using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterBalloons : MonoBehaviour {

	GameObject database;
	ItemData itemData;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (itemData.item [8].openIt == true) {
			itemData.item [8].itemDuration -= 0.05f;
			WaterBallons (itemData.item [8]);
		}

	}

	void WaterBallons (Items item) {

		if (item.itemDuration >= 0) {
		} else {
			print (item.itemsChange);
			//If player is in radius
			HUD.TakeDamage ();
			print ("Used Waterballoon");
			item.itemDuration = 5.0f;
			HUD.DisplayUpdate ();
			item.openIt = false;
			Destroy (this.gameObject);
		}
	}

}
