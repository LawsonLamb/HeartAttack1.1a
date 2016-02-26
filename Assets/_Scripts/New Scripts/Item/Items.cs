using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Items {

	public GameObject item;
	public GameObject priceDisplay;
	public string itemName;
	public int itemID;
	public int itemPrice;
	public int itemStock;
	public float itemDuration;
	public float itemsChange;
	public bool openIt;
	public Sprite itemIcon;
	public ItemType itemType;

	public enum ItemType
	{
		Consumable,
		Key,
		Skill,
		Pickup,

	}

	public Items () {
	
	}

	public Items (string name, int id, int price, int stock, float duration, float change, bool open, ItemType type) {
		itemName = name;
		itemID = id;
		itemPrice = price;
		itemStock = stock;
		itemDuration = duration;
		itemsChange = change;
		openIt = open;
		itemType = type;

	}

	public void CreateGameObject (string name, int i) {
		item = new GameObject ();
		item.name = itemName;
		item.AddComponent<SpriteRenderer> ().sprite = itemIcon;
		item.AddComponent<PickedItem> ();
		item.AddComponent<BoxCollider2D> ();
		item.AddComponent<Rigidbody2D> ();
		item.transform.localScale = new Vector3 (5, 5, 1);
		if (name == "LoveBooth") {
			item.transform.localPosition = new Vector3 (GameObject.Find (name).transform.localPosition.x + 3, GameObject.Find (name).transform.localPosition.y, 0);
		} else if (name == "Foe") {
			item.transform.localPosition = new Vector3 (GameObject.FindGameObjectWithTag(name).transform.localPosition.x, GameObject.FindGameObjectWithTag (name).transform.localPosition.y, 0);
		} else {
			item.transform.localPosition = new Vector3 (5 * i, 0, 0);
		}
	}
		
}
