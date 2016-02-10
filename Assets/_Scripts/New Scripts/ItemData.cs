using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {

	public List <Items> item = new List<Items> ();

	// Use this for initialization
	void Start () {
		//item.Add (new Items (name, id, price, stock, items duration, amount it changes something, opens something, type));
		item.Add (new Items ("Key", 0, 5, 0, 0.0f, 0.0f, false, Items.ItemType.Key));
		item.Add (new Items ("Heart Key", 1, 25, 0, 0.0f, 0.0f, false, Items.ItemType.Key));

		item.Add (new Items ("Blood", 2, 10, 0, 0.0f, 0.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Speed Pill", 3, 0, 0, 10.0f, 0.10f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Defense Pill", 4, 0, 0, 10.0f, 10.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Damage Pill", 5, 0, 0, 10.0f, 10.0f, false, Items.ItemType.Consumable));
		item.Add (new Items ("M.Damage Pill", 6, 0, 0, 10f, 0.10f, false, Items.ItemType.Consumable));

		item.Add (new Items ("Coin", 7, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Waterballoon", 8, 15, 1, 5.0f, 50.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Discounter", 9, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Map", 10, 25, 10, 0.0f, 0.0f, false, Items.ItemType.Pickup));
		item.Add (new Items ("Hidden Passage", 11, 20, 0, 0.0f, 0.0f, false, Items.ItemType.Pickup));

		item.Add (new Items ("Reg Att 0_1", 12, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Reg Att 1_1", 13, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Reg Att 2_1", 14, 50, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 0_1", 15, 0, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 1_1", 16, 30, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
		item.Add (new Items ("Spec Att 2_1", 17, 50, 0, 0.0f, 0.0f, false, Items.ItemType.Skill));
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
