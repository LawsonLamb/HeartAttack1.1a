using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickedItem : MonoBehaviour {

	string name;
	GameObject database;
	ItemData itemData;
	AttackDatabase attData;
	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
		attData = database.GetComponent<AttackDatabase> ();
		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			PickUp ();
		}
	}

	void PickUp() {
		
		Items item = itemData.GetItemByName (name);
		if (item.itemType == Items.ItemType.Skill) {
			Skills (item);
		}
		item.itemStock += 1;
	}

	void Consumables (Items item) {
	}

	void Pickups (Items item) {
		
	}

	void Skills (Items item) {

		for (int i = 11; i < 17; i++) {
			itemData.item [i + 1].openIt = false;
			itemData.item [i + 1].itemStock = 0;
		}

		item.openIt = true;
		Attacks att = attData.GetAttByName (item.itemName);
		Attacks oldAtt;

		if (att.attType == Attacks.AttackType.Regular) {
			oldAtt = AttackManager.currRegAtt;
			AttackManager.currRegAtt = att;
		} else {
			oldAtt = AttackManager.currSpecAtt;
			AttackManager.currSpecAtt = att;
		}
		//DropOldAtt(oldAtt);
	}
}
