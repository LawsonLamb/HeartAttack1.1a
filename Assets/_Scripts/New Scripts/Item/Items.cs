using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Items {

	public GameObject item;
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

	public void CreateGameObject () {
		item = new GameObject ();
		item.name = itemName;
		item.AddComponent<SpriteRenderer> ().sprite = itemIcon;
		item.AddComponent<PickedItem> ();
		item.AddComponent<BoxCollider2D> ();
		item.AddComponent<Rigidbody2D> ();
		item.transform.localScale = new Vector3 (5, 5, 1);
		item.transform.localPosition = new Vector3 (Random.Range(0,8), Random.Range(0,8), 0);
	}
		
}
