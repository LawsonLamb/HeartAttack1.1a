using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
[System.Serializable]
public class Item
{

    public GameObject item;
    public GameObject priceDisplay;
    public string Name;
    public int ID;
    public int Price;
    public int Stock;
    public float Duration;
    public float Change;
    public bool openIt;
    public Sprite Icon;
    public ItemType Type;

    public enum ItemType
    {
        Consumable,
        Key,
        Skill,
        Pickup,

    }

    public Item()
    {

    }

    public Item(string name, int id, int price, int stock, float duration, float change, bool open, ItemType type)
    {
        Name = name;
        ID = id;
        Price = price;
        Stock = stock;
        Duration = duration;
        Change = change;
        openIt = open;
        Type = type;

    }

	public void CreateGameObject(GameObject npc, int i, int ID)
    {
        item = new GameObject();
        item.name = Name;
        item.AddComponent<SpriteRenderer>().sprite = Icon;
        item.AddComponent<PickedItem>();
        item.AddComponent<BoxCollider2D>();
        item.AddComponent<Rigidbody2D>();
		if ((ID == 2) || (ID == 7) || (ID == 8)) {
			item.transform.localScale = new Vector3(0.1f, 0.1f, 1);
		} else if (ID == 17) {
			item.transform.localScale = new Vector3(3, 3, 1);
		} else {
			item.transform.localScale = new Vector3(1, 1, 1);
		}
        item.transform.position = new Vector3(npc.transform.position.x, npc.transform.position.y, 0);
       
    }

}
