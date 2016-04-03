using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {

	public List <Item> item = new List<Item> ();

	// Use this for initialization
	void Start () {
		//item.Add (new Item (string name, int id, int price, int stock, float duration, float change, bool open, Sprite icon, ItemType type))

		item.Add (new Item ("Key", 0, 5, 0, 0.0f, 0.0f, false, Item.ItemType.Key));
		item.Add (new Item ("Heart Key", 1, 25, 0, 0.0f, 0.0f, false, Item.ItemType.Key));

		item.Add (new Item ("Blood", 2, 10, 0, 0.0f, 0.0f, false, Item.ItemType.Consumable));
		item.Add (new Item ("Speed Pill", 3, 0, 0, 10.0f, 0.10f, false, Item.ItemType.Consumable));
		item.Add (new Item ("Defense Pill", 4, 0, 0, 10.0f, 1.0f, false, Item.ItemType.Consumable));
		item.Add (new Item ("Damage Pill", 5, 0, 0, 10.0f, 10.0f, false, Item.ItemType.Consumable));
		item.Add (new Item ("M.Damage Pill", 6, 0, 0, 10.0f, 10.0f, false, Item.ItemType.Consumable));

		item.Add (new Item ("Coin", 7, 0, 0, 0.0f, 0.0f, false, Item.ItemType.Pickup));
		item.Add (new Item ("Waterballoon", 8, 15, 1, 10.0f, 50f, false, Item.ItemType.Pickup));
		item.Add (new Item ("Discounter", 9, 30, 0, 0.0f, 0.0f, false, Item.ItemType.Pickup));
		item.Add (new Item ("Map", 10, 25, 0, 0.0f, 0.0f, false, Item.ItemType.Pickup));
		item.Add (new Item ("Hidden Passage", 11, 20, 0, 0.0f, 0.0f, false, Item.ItemType.Pickup));

		item.Add (new Item ("Regular Shot_1", 12, 0, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));
		item.Add (new Item ("Double Shot_1", 13, 30, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));
		item.Add (new Item ("Barrage_1", 14, 50, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));
		item.Add (new Item ("Enrage_1", 15, 0, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));
		item.Add (new Item ("Restore_1", 16, 30, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));
		item.Add (new Item ("Cupid_1", 17, 50, 0, 0.0f, 0.0f, false, Item.ItemType.Skill));

		//Permit Perks
		//After 10 hits (under change float) you restore 1 health
		item.Add (new Item ("Transfusion", 18, 50, 0, 0, 10.0f, false, Item.ItemType.Pickup));

		//Increases Speed
		item.Add (new Item ("Adrenalin", 19, 50, 0, 0, 0.125f, false, Item.ItemType.Pickup));

		//Increases Defesne
		item.Add (new Item ("Pace Maker", 20, 50, 0, 0, 1.25f, false, Item.ItemType.Pickup));

		//Increases Damage
		item.Add (new Item ("Defibrillator", 21, 50, 0, 0, 2.5f, false, Item.ItemType.Pickup));

		//Increases M.Damage
		item.Add (new Item ("Aloe Vera", 22, 50, 0, 0, 2.5f, false, Item.ItemType.Pickup));

		FindSprites ();
	}
		
	public void FindSprites() {
		
		for (int i = 0; i < item.Count; i++) {
			if (item[i].ID == i) {
				item[i].Icon = Resources.Load <Sprite> ("Icons/Items/Item_" + i); 
			}
		}
	}

	public Item GetItemByID(int id){

		for(int i =0; i< item.Count;i++){
			if(item[i].ID == id)
				return item[i];

		}
		return null;

	}

	public Item GetItemByName(string name){

		for (int i =0; i < item.Count; i++) {
			if(item[i].Name == name)
				return item[i];
		}
		return null;
	}
}
