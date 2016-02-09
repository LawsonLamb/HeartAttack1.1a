using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemData : MonoBehaviour {

	public List <Items> item = new List<Items> ();

	// Use this for initialization
	void Start () {
		//item.Add (new Items (name, id, price, stock, items duration, amount it changes something, opens something, type));
		item.Add (new Items ("Key", 0, 5, 0, 0, 0, false, Items.ItemType.Key));
		item.Add (new Items ("Heart Key", 1, 25, 0, 0, 0, false, Items.ItemType.Key));

		item.Add (new Items ("Blood", 2, 10, 0, 0, 0, false, Items.ItemType.Consumable));
		item.Add (new Items ("Speed Pill", 3, 15, 0, 10f, 0.10f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Defense Pill", 4, 15, 0, 10f, 10f, false, Items.ItemType.Consumable));
		item.Add (new Items ("Damage Pill", 5, 20, 0, 10f, 10f, false, Items.ItemType.Consumable));
		item.Add (new Items ("M.Damage Pill", 6, 20, 0, 10f, 0.10f, false, Items.ItemType.Consumable));


	}
}
