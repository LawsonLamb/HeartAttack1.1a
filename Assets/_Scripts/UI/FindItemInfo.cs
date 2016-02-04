using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FindItemInfo : MonoBehaviour {

	GameObject parent;
	List<GameObject> shopSlot = new List<GameObject> ();
	int childAmount;
	ItemDataBase database;
	// Use this for initialization
	void Start () {

		database = ItemDataBase.GetDataBase ();

		parent = this.gameObject;
		childAmount = parent.transform.childCount;
		for (int i = 0; i < childAmount; i++) {
			shopSlot.Add(parent.transform.GetChild (i).gameObject);
			//print (shopSlot[i].gameObject.name);
		}
		for (int i = 0; i < shopSlot.Count; i++) {
			FindItems (shopSlot[i].name, i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FindItems(string child, int num) {

		Item itemInSlot = database.GetItemByName (child);

		if (itemInSlot.name == shopSlot[num].name) {
			for (int i = 0; i < 3; i++) {
				if (i == 0){
					shopSlot[num].transform.GetChild (i).GetComponent<Image>().sprite = itemInSlot.sprite;
				}
				else if (i == 1){
					shopSlot[num].transform.GetChild (i).GetComponent<Text>().text = itemInSlot.name;
				}
				else {
					shopSlot[num].transform.GetChild (i).GetComponent<Text>().text = itemInSlot.price + " LN Stock: " + itemInSlot.stock ;
				}

			}
		}
	}
}
