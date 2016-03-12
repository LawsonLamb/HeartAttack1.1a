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

	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
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
		HUD.DisplayUpdate ();
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
			oldAtt = AttackManager.currRegAtt;

			if ((oldAtt.attID >= 0) && (oldAtt.attID <= 4)) {
				oldItem = itemData.GetItemByName(attData.attacks [0].attName);
			} else if ((oldAtt.attID >= 10) && (oldAtt.attID <= 14)) {
				oldItem = itemData.GetItemByName(attData.attacks [10].attName);
			} else if ((oldAtt.attID >= 20) && (oldAtt.attID <= 24)) {
				oldItem = itemData.GetItemByName(attData.attacks [20].attName);
			}
			AttackManager.currRegAtt = newAtt;
			AttackManager.regSkillImage.GetComponent<Image>().sprite = AttackManager.currRegAtt.attIcon;
			AttackManager.ChangeRegAtt (Points.attack);
		} else {
			oldAtt = AttackManager.currSpecAtt;

			if ((oldAtt.attID >= 5) && (oldAtt.attID <= 9)) {
				oldItem = itemData.GetItemByName(attData.attacks [5].attName);
			} else if ((oldAtt.attID >= 15) && (oldAtt.attID <= 19)) {
				oldItem = itemData.GetItemByName(attData.attacks [15].attName);
			} else if ((oldAtt.attID >= 25) && (oldAtt.attID <= 29)) {
				oldItem = itemData.GetItemByName(attData.attacks [25].attName);
			}
			AttackManager.currSpecAtt = newAtt;
			AttackManager.specSkillImage.GetComponent<Image>().sprite = AttackManager.currSpecAtt.attIcon;
			AttackManager.ChangeSpecialAtt (Points.skill);
		}

		DropItem(oldItem);
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
						Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.gray;
						i = Player.hLoads;
					} else if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
						Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
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
						Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.gray;
						i = Player.hLoads;
					} else if (Player.healthLoadList [i].GetComponent<Image> ().color == Color.gray) {
						Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
						Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
						i = Player.hLoads;
					}
				}
			} else {
				DropItem (item);
			}
		}
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
		
		if (item.ID == 3) {
			Player.speed += item.Change;
		} else if (item.ID == 4) {
			Player.def += item.Change;
		} else if (item.ID == 5) {
			Player.dmg += item.Change;
		} else {
			Player.mDmg += item.Change;
		}
		Player.buff = item;
		Player.bTimer = Player.buff.Duration;
		Player.saveBTimer = Player.bTimer;
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Player") {
			PickUp ();
		}
	}

	void PermItems (Item item) {

		HUD.AddPermIcon (item);
		if(item.ID == 18) {
			Player.enemyKillCount = 0;
			item.openIt = true;
		} else if (item.ID == 19) {
			Player.adren += item.Change;
		} else if (item.ID == 20) {
			Player.pMaker += item.Change;
		} else if (item.ID == 21) {
			Player.defib += item.Change;
		} else if (item.ID == 22) {
			Player.aVera += item.Change;
		}
		Player.UpdateStatus (Points.attack, Points.heart, Points.skill, Points.speed);
			
	}
}
