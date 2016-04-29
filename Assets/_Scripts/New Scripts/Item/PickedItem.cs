using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PickedItem : MonoBehaviour {

	string Name{ get { return gameObject.name; } set { gameObject.name = value; } }
	GameObject database;
	ItemData itemData;
	AttackDatabase attData;
	Item item;
	UIScripts displays;
	Specials spec;
	SpecialItems specIt;
	Player player;

	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		spec = GameObject.FindGameObjectWithTag ("Background").GetComponent<Specials> ();
		specIt = GameObject.FindGameObjectWithTag ("Background").GetComponent<SpecialItems> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		itemData = database.GetComponent<ItemData> ();
		attData = database.GetComponent<AttackDatabase> ();

	
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
			PickUpHealth (item);
		}
		if ((item.ID >= 3) && (item.ID <= 6)) {
			for (int i = 3; i < 7; i++) {
				if (itemData.item [i].openIt == false) {
					item.openIt = true;
					QuickBuff (item);
					i = 7;
				} else {
					//DropItem (item);
					i = 7;
				}
			}
		}
	}

	void Pickups (Item item) {

		if ((item.ID == 7) || (item.ID == 8)) {
			item.Stock += 1;
		}

		if((item.ID >= 9) && (item.ID <= 11)) {
			item.openIt = true;
			specIt.ActivateItem (item);
		}

		if ((item.ID >= 18) && (item.ID <= 22)) {
			if (item.Stock <= 0) {
				PermItems (item);
				item.Stock += 1;
			} else {
				///DropItem (item);
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
//		Item oldItem = new Item ();

		if (newAtt.attType == Attacks.AttackType.Regular) {
			oldAtt = displays.currRegSkill;

			if ((oldAtt.attID >= 0) && (oldAtt.attID <= 4)) {
				//oldItem = itemData.GetItemByName(attData.attacks [0].attName);
			} else if ((oldAtt.attID >= 10) && (oldAtt.attID <= 14)) {
				//oldItem = itemData.GetItemByName(attData.attacks [10].attName);
			} else if ((oldAtt.attID >= 20) && (oldAtt.attID <= 24)) {
				//oldItem = itemData.GetItemByName(attData.attacks [20].attName);
			}
			displays.currRegSkill = newAtt;
			displays.regSkill.sprite = displays.currRegSkill.attIcon;
			displays.ChangeRegAtt (displays.attPoints);
		} else {

			oldAtt = displays.currSpecSkill;
			spec.RemoveSkill (oldAtt);

			if ((oldAtt.attID >= 5) && (oldAtt.attID <= 9)) {
				//oldItem = itemData.GetItemByName(attData.attacks [5].attName);
			} else if ((oldAtt.attID >= 15) && (oldAtt.attID <= 19)) {
				//oldItem = itemData.GetItemByName(attData.attacks [15].attName);
			} else if ((oldAtt.attID >= 25) && (oldAtt.attID <= 29)) {
				//oldItem = itemData.GetItemByName(attData.attacks [25].attName);
			}
			displays.currSpecSkill = newAtt;
			displays.specSkill.sprite = displays.currSpecSkill.attIcon;
			displays.ChangeSpecAtt (displays.skPoints);
		}

		//DropItem(oldItem);
	}

	void PickUpHealth (Item item) {
		if (player.health < player.maxHealth) {
			displays.RestoreHealth (item.Change);
		} else {
			//DropItem (item);
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
		if ((drop.ID == 2) || (drop.ID == 7) || (drop.ID == 8)) {
			drop.item.transform.localScale = new Vector3(0.1f, 0.1f, 1);
		} else if (drop.ID == 17) {
			drop.item.transform.localScale = new Vector3(3, 3, 1);
		} else {
			drop.item.transform.localScale = new Vector3(1, 1, 1);
		}
		drop.item.transform.localPosition = new Vector3 (GameObject.Find ("Player").transform.localPosition.x - Random.Range (2, 3), GameObject.Find ("Player").transform.localPosition.y - Random.Range (2, 3), 0);
	}

	void QuickBuff (Item item) {
		
		player.buff = item;
		player.buffTimer = item.Duration;
		if (item.ID == 3) {
			player.speed += item.Change;
		} else if (item.ID == 4) {
			player.def += item.Change;
		} else if (item.ID == 5) {
			player.dmg += item.Change;
		} else {
			player.mDmg += item.Change;
		}
			
	}

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.tag == "Player") {
			PickUp ();
		}
	}

	void PermItems (Item permItem) {
		if (permItem.ID == 18) {
			player.tranfusionActive = true;
		} else if (permItem.ID == 19) {
			player.speed += permItem.Change;
		} else if (permItem.ID == 20) {
			player.def += permItem.Change;
		} else if (permItem.ID == 21) {
			player.dmg += permItem.Change;
		} else if (permItem.ID == 22) {
			player.mDmg += permItem.Change;
		}
		displays.AddPermIcon (permItem);
	}
}
