using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterBalloons : MonoBehaviour {

	GameObject database;
	ItemData itemData;
	GameObject displays;
	GameObject player;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		player = GameObject.FindGameObjectWithTag ("Player");
		displays = GameObject.FindGameObjectWithTag ("Background");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

		//If there is a bomb that is active it will count down till explosion
		if (itemData.item [8].openIt == true) {
			itemData.item [8].Duration -= 0.05f;
			WaterBallons (itemData.item [8]);
		}

	}

	void WaterBallons (Item item) {

		/*Once the timer has hit 0 or less it will cause damage to anything in 
		 *it's range and then reset the count. It will also update your HUD and 
		 *turn the bomb active off and destory the object.*/
		if (item.Duration >= 0) {
		} else {
			//If player is in radius
			displays.GetComponent<UIScripts>().TakeDamage (25f);
			item.Duration = 5.0f;
			item.openIt = false;
			Destroy (this.gameObject);
		}
	}

}
