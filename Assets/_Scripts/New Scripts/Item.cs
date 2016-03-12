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

    public void CreateGameObject(string name, int i)
    {
        item = new GameObject();
        item.name = Name;
        item.AddComponent<SpriteRenderer>().sprite = Icon;
        item.AddComponent<PickedItem>();
        item.AddComponent<BoxCollider2D>();
        item.AddComponent<Rigidbody2D>();
        item.transform.localScale = new Vector3(5, 5, 1);
        if (name == "LoveBooth")
        {
            item.transform.localPosition = new Vector3(GameObject.Find(name).transform.localPosition.x + 3, GameObject.Find(name).transform.localPosition.y, 0);
        }
        else if (name == "Foe")
        {
            item.transform.localPosition = new Vector3(GameObject.FindGameObjectWithTag(name).transform.localPosition.x, GameObject.FindGameObjectWithTag(name).transform.localPosition.y, 0);
        }
        else {
            item.transform.localPosition = new Vector3(5 * i, 0, 0);
        }
    }

}
