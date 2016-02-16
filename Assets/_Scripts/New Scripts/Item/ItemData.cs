using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {

	public List <Items> item = new List<Items> ();

	// Use this for initialization
	void Start () {
		//item.Add (new Items (string name, int id, int price, int stock, float duration, float change, bool open, Sprite icon, ItemType type))

		item.Add (new Items ("Key", 0, 5, 0, 0.0f, 0.0f, false, Items.ItemType.Key));
		item.Add (new Items ("Heart Key", 1, 25, 0, 0.0f, 0.0f, false, Items.ItemType.Key));

		item.Add (new Items ("Blood", 2, 10, 0, 0.0f, 0.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Speed Pill", 3, 0, 0, 10.0f, 0.10f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Defense Pill", 4, 0, 0, 10.0f, 1.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Damage Pill", 5, 0, 0, 10.0f, 10.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("M.Damage Pill", 6, 0, 0, 10.0f, 10.0f, false, Items.ItemType.Consumable));

		item.Add (new Items ("Coin", 7, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Waterballoon", 8, 15, 1, 10.0f, 50f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Discounter", 9, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Map", 10, 25, 10, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Hidden Passage", 11, 20, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));

		item.Add (new Items ("Reg Att 0_1", 12, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Reg Att 1_1", 13, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Reg Att 2_1", 14, 50, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 0_1", 15, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 1_1", 16, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 2_1", 17, 50, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));

		//Permit Perks
		//After 10 hits (under change float) you restore 1 health
		item.Add (new Items ("Transfusion", 18, 50, 0, 0, 10.0f, false, Items.ItemType.Pickup));

		//Increases Speed
		item.Add (new Items ("Adrenalin", 19, 50, 0, 0, 0.25f, false, Items.ItemType.Pickup));

		//Increases Defesne
		item.Add (new Items ("Pace Maker", 20, 50, 0, 0, 2.5f, false, Items.ItemType.Pickup));

		//Increases Damage
		item.Add (new Items ("Defibrillator", 21, 50, 0, 0, 25.0f, false, Items.ItemType.Pickup));

		//Increases M.Damage
		item.Add (new Items ("Aloe Vera", 22, 50, 0, 0, 25.0f, false, Items.ItemType.Pickup));

		FindSprites ();
	}
		
	public void FindSprites() {
		
		for (int i = 0; i < item.Count; i++) {
			if (item[i].itemID == i) {
				item[i].itemIcon = Resources.Load <Sprite> ("Icons/Items/Item_" + i); 
			}
		}
	}

	public Items GetItemByID(int id){

		for(int i =0; i< item.Count;i++){
			if(item[i].itemID == id)
				return item[i];

		}
		return null;

	}

	public Items GetItemByName(string name){

		for (int i =0; i < item.Count; i++) {
			if(item[i].itemName == name)
				return item[i];
		}
		return null;
	}
}
