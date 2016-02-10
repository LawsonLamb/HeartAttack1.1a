using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickedItem : MonoBehaviour {

	string name;
	GameObject database;
	ItemData itemData;
	AttackDatabase attData;
	Items item;

	Items buff;
	bool buffActive;
	float time;
	float saveTime;
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

		if (buffActive == true) {
			time -= 0.05f;
			CoolDownBuff();
		}
	}

	void PickUp() {
		
		item = itemData.GetItemByName (name);
		print (item.itemName);
		if (item.itemType == Items.ItemType.Skill) {
			Skills (item);
		} else if (item.itemType == Items.ItemType.Pickup) {
			Pickups (item);
		} else if (item.itemType == Items.ItemType.Consumable) {
			Consumables (item);
		} else {
			item.itemStock += 1;
		}
		HUD.DisplayUpdate ();
		Destroy (this.gameObject);
	}

	void Consumables (Items item) {
		if (item.itemID == 2) {
			PickUpHealth ();
		}
		if ((item.itemID >= 3) && (item.itemID <= 6)) {
			item.openIt = true;
			QuickBuff(item);
		}
	}

	void Pickups (Items item) {

		if ((item.itemID == 7) || (item.itemID == 8)) {
			item.itemStock += 1;
		}
		if((item.itemID >= 9) && (item.itemID <= 11)) {
			item.openIt = true;
		}

		if (item.itemID == 9) {
			for (int i = 0; i < itemData.item.Count; i++) {
				itemData.item [i].itemPrice = (itemData.item [i].itemPrice / 2);
			}
		}
	}

	void Skills (Items item) {

		for (int i = 11; i < 17; i++) {
			itemData.item [i + 1].openIt = false;
			itemData.item [i + 1].itemStock = 0;
		}

		item.openIt = true;
		Attacks att = attData.GetAttByName (item.itemName);
		Items oldAtt;

		if (att.attType == Attacks.AttackType.Regular) {
			oldAtt = itemData.GetItemByName (AttackManager.currRegAtt.attName);
			AttackManager.currRegAtt = att;
		} else {
			oldAtt = itemData.GetItemByName (AttackManager.currSpecAtt.attName);
			AttackManager.currSpecAtt = att;
		}

		DropItem(oldAtt);
	}

	void PickUpHealth () {

		/*If you have increased your health into a full health box [the Health 
		 *Load is default red for every 4 points into your heart stats] you will 
		 *restore health starting from the left most. It will only work if your 
		 *health isn't full [the right most Health Load isn't red]. Health will 
		 *restore to gray 1/2 Health and red full health*/
		if (Points.heart % 4 == 0) {
			if (Player.healthLoadList [Player.hLoads - 1].GetComponent<Image> ().color != Color.red) {
				for (int i = 0; i < Player.hLoads; i++) {
					if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.black) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.gray;
						i = Player.hLoads;
					} else if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
						i = Player.hLoads;
					}
				}
			} else {
				DropItem (item);
			}

		} else {
			/*If you haven't increased your health into a full health box [the Health 
			 *Load is default gray for every 2 points into your heart stats] you will 
			 *restore health starting from the left most. It will only work if your 
			 *health isn't full [the right most Health Load isn't gray]. Health will 
			 *restore to gray 1/2 Health and red full health*/
			if (Player.healthLoadList [Player.hLoads - 1].GetComponent<Image> ().color != Color.gray) {
				for (int i = 0; i < Player.hLoads; i++) {
					if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.black) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.gray;
						i = Player.hLoads;
					} else if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
						i = Player.hLoads;
					}
				}
			} else {
				DropItem (item);
			}
		}
	}

	void DropItem (Items drop) {

		//Once attack has a gameobject dropped will equal it
		GameObject dropped = new GameObject();

		dropped.name = drop.itemName;
		dropped.AddComponent<PickedItem> ();
	}

	void QuickBuff (Items item) {
		
		if (item.itemID == 3) {
			Player.speed += item.itemsChange;
		} else if (item.itemID == 4) {
			Player.def += item.itemsChange;
		} else if (item.itemID == 5) {
			Player.dmg += item.itemsChange;
		} else {
			Player.mDmg += item.itemsChange;
		}
		buffActive = item.openIt;
		time = item.itemDuration;
		saveTime = item.itemDuration;
		buff = item;
	}

	void CoolDownBuff () {

		if (time >= 0) {
		} else {
			if (buff.itemID == 3) {
				Player.speed -= buff.itemsChange;
			} else if (item.itemID == 4) {
				Player.def -= buff.itemsChange;
			} else if (item.itemID == 5) {
				Player.dmg -= buff.itemsChange;
			} else {
				Player.mDmg -= buff.itemsChange;
			}
			buff.openIt = buffActive;
			buff.itemDuration = saveTime;
			buffActive = false;
		}
	}
}
