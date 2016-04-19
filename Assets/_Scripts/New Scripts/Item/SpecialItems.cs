using UnityEngine;
using System.Collections;

public class SpecialItems : MonoBehaviour {

	GameObject database;
	ItemData itemData;
	Item item;
	GameObject miniMap;

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
		miniMap = GameObject.FindGameObjectWithTag ("Map");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActivateItem (Item currItem) {

		item = currItem;

		if (item.ID == 9) {
			Discount ();
		} else if (item.ID == 10) {
			Map ();
		} else if (item.ID == 11) {
			HiddenRooms ();
		}
	}

	void Discount(){
		
		for (int i = 0; i < itemData.item.Count; i++) {
			itemData.item [i].Price = (itemData.item [i].Price / 2);
		}

	}

	void Map() {
		
		miniMap.SetActive (true);

	}

	void HiddenRooms() {
	}
}
