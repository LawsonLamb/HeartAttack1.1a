using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Items {

	public GameObject item;
	public string itemName;
	public int itemID;
	public int itemPrice;
	public int itemStock;
	public float itemDuration;
	public float itemsChange;
	public bool openIt;
	public Sprite sprite;
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
}
