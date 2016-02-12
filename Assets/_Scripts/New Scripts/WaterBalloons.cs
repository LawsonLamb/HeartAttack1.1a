﻿using UnityEngine;
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

		//If there is a bomb that is active it will count down till explosion
		if (itemData.item [8].openIt == true) {
			itemData.item [8].itemDuration -= 0.05f;
			WaterBallons (itemData.item [8]);
		}

	}

	void WaterBallons (Items item) {

		/*Once the timer has hit 0 or less it will cause damage to anything in 
		 *it's range and then reset the count. It will also update your HUD and 
		 *turn the bomb active off and destory the object.*/
		if (item.itemDuration >= 0) {
		} else {
			print (item.itemsChange);
			//If player is in radius
			HUD.TakeDamage (1f);
			print ("Used Waterballoon");
			item.itemDuration = 5.0f;
			item.openIt = false;
			Destroy (this.gameObject);
		}
	}

}
