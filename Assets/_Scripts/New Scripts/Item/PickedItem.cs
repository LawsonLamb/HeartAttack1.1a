using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickedItem : MonoBehaviour {

	string name;
	GameObject database;
	ItemData itemData;
	AttackDatabase attData;
	Item item;
	UIScripts displays;
	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		itemData = database.GetComponent<ItemData> ();
		attData = database.GetComponent<AttackDatabase> ();

		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PickUp() {

		item = itemData.GetItemByName (name);
		if (item.Type == Item.ItemType.Skill) {
			Skills (item);
		} else if (item.Type == Item.ItemType.Pickup) {
			Pickups (item);
		} else if (item.Type == Item.ItemType.Consumable) {
			Consumables (item);
		} else {
			item.Stock += 1;
		}
		displays.SackUpdate ();
		Destroy (this.gameObject);
	}

	void Consumables (Item item) {
		if (item.ID == 2) {
			PickUpHealth ();
		}
		if ((item.ID >= 3) && (item.ID <= 6)) {
			item.openIt = true;
			QuickBuff(item);
		}
	}

	void Pickups (Item item) {

		if ((item.ID == 7) || (item.ID == 8)) {
			item.Stock += 1;
		}

		if((item.ID >= 9) && (item.ID <= 11)) {
			item.openIt = true;
		}

		if (item.ID == 9) {
			for (int i = 0; i < itemData.item.Count; i++) {
				itemData.item [i].Price = (itemData.item [i].Price / 2);
			}
		}

		if ((item.ID >= 18) && (item.ID <= 22)) {
			if (item.Stock <= 0) {
				PermItems (item);
				item.Stock += 1;
			} else {
				DropItem (item);
			}
		}
	}

	void Skills (Item item) {

		for (int i = 11; i < 17; i++) {
			itemData.item [i + 1].openIt = false;
			itemData.item [i + 1].Stock = 0;
		}

		item.openIt = true;
		Attacks newAtt = attData.GetAttByName (item.Name);
		Attacks oldAtt = new Attacks ();
		Item oldItem = new Item ();

		if (newAtt.attType == Attacks.AttackType.Regular) {
			oldAtt = displays.currRegSkill;

			if ((oldAtt.attID >= 0) && (oldAtt.attID <= 4)) {
				oldItem = itemData.GetItemByName(attData.attacks [0].attName);
			} else if ((oldAtt.attID >= 10) && (oldAtt.attID <= 14)) {
				oldItem = itemData.GetItemByName(attData.attacks [10].attName);
			} else if ((oldAtt.attID >= 20) && (oldAtt.attID <= 24)) {
				oldItem = itemData.GetItemByName(attData.attacks [20].attName);
			}
			displays.currRegSkill = newAtt;
			displays.regSkill.sprite = displays.currRegSkill.attIcon;
			displays.ChangeRegAtt (displays.attPoints);
		} else {
			oldAtt = displays.currSpecSkill;

			if ((oldAtt.attID >= 5) && (oldAtt.attID <= 9)) {
				oldItem = itemData.GetItemByName(attData.attacks [5].attName);
			} else if ((oldAtt.attID >= 15) && (oldAtt.attID <= 19)) {
				oldItem = itemData.GetItemByName(attData.attacks [15].attName);
			} else if ((oldAtt.attID >= 25) && (oldAtt.attID <= 29)) {
				oldItem = itemData.GetItemByName(attData.attacks [25].attName);
			}
			displays.currSpecSkill = newAtt;
			displays.specSkill.sprite = displays.currSpecSkill.attIcon;
			displays.ChangeSpecAtt (displays.skPoints);
		}

		DropItem(oldItem);
	}

	void PickUpHealth () {

		/*If you have increased your health into a full health box [the Health 
		 *Load is default red for every 4 points into your heart stats] you will 
		 *restore health starting from the left most. It will only work if your 
		 *health isn't full [the right most Health Load isn't red]. Health will 
		 *restore to gray 1/2 Health and red full health*/

	}

	void DropItem (Item drop) {

		//Once attack has a gameobject dropped will equal it
		drop.item = new GameObject();
		drop.item.name = drop.Name;
		drop.item.AddComponent<SpriteRenderer> ().sprite =  drop.Icon;
		drop.item.AddComponent<PickedItem> ();
		drop.item.AddComponent<BoxCollider2D> ();
		drop.item.AddComponent<Rigidbody2D> ();
		drop.item.transform.localScale = new Vector3 (5, 5, 1);
		drop.item.transform.localPosition = new Vector3 (GameObject.Find ("Player").transform.localPosition.x, GameObject.Find ("Player").transform.localPosition.y - 5, 0);
	}

	void QuickBuff (Item item) {
		

	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Player") {
			PickUp ();
		}
	}

	void PermItems (Item item) {
		displays.AddPermIcon (item);
	}
}
