using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Specials : MonoBehaviour {

	string name{ 
		get { return gameObject.name; } 
		set{ gameObject.name = value; }
	
	}
	GameObject database;
	AttackDatabase attData;
	UIScripts displays;
	Attacks att;
	Player player;
	Cupid cupid;

	public bool wasActive = false;
	public int coolFactor;
	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateSkill (Attacks currAtt) {
	
		att = currAtt;

		att.attSpeed = player.speed;


		if ((att.attID >= 5) && (att.attID <= 9)) {
			Enrage ();
		} else if ((att.attID >= 15) && (att.attID <= 19)) {
			Restore ();
		} else if ((att.attID >= 25) && (att.attID <= 29)) {
			Cupid ();
		}

	}

	void Enrage () {

		if (att.attName == "Enrage_1") {
			player.speed += .250f;
			player.def += 2.50f;
			player.dmg += 5f;
			player.mDmg += 5f;
			coolFactor = 2;
		} else if (att.attName == "Enrage_2") {
			player.speed += .3f;
			player.def += 3f;
			player.dmg += 5.5f;
			player.mDmg += 5.5f;
			coolFactor = 4;
		} else if (att.attName == "Enrage_3") {
			player.speed += .35f;
			player.def += 3.5f;
			player.dmg += 6f;
			player.mDmg += 6f;
			coolFactor = 6;
		} else if (att.attName == "Enrage_4") {
			player.speed += .4f;
			player.def += 4f;
			player.dmg += 6.5f;
			player.mDmg += 6.5f;
			coolFactor = 8;
		} else {
			player.speed += .45f;
			player.def += 4.5f;
			player.dmg += 7f;
			player.mDmg += 7f;
			coolFactor = 10;
		} 
		player.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
	}

	void Restore () {

		float restoreHealthAmount = player.maxHealth - player.health;
		float restoreMagicAmount = player.maxMagic - player.magic;
		displays.RestoreHealth (restoreHealthAmount);
		displays.RestoreMagic (restoreMagicAmount);
	}

	void Cupid () {
		cupid = GameObject.FindGameObjectWithTag ("Cupid").GetComponent<Cupid> ();

		if (att.attName == "Cupid_1") {
			cupid.Summon (1);
			coolFactor = 2;
		} else if (att.attName == "Cupid_2") {
			cupid.Summon (2);
			coolFactor = 4;
		} else if (att.attName == "Cupid_3") {
			cupid.Summon (3);
			coolFactor = 6;
		} else if (att.attName == "Cupid_4") {
			cupid.Summon (4);
			coolFactor = 8;
		} else {
			cupid.Summon (5);
			coolFactor = 10;
		}
		print ("Summon a Cupid to help you fight");

	}

	public void RemoveSkill (Attacks currAtt) {

		att = currAtt;

		att.attSpeed = player.speed;

		if (wasActive) {
			if ((att.attID >= 5) && (att.attID <= 9)) {
				Calm ();
			} else if ((att.attID >= 25) && (att.attID <= 29)) {
				Alone ();
			}
		}

		wasActive = false;
	}

	void Calm() {

		if (att.attName == "Enrage_1") {
			player.speed -= .250f;
			player.def -= 2.50f;
			player.dmg -= 5f;
			player.mDmg -= 5f;
		} else if (att.attName == "Enrage_2") {
			player.speed -= .3f;
			player.def -= 3f;
			player.dmg -= 5.5f;
			player.mDmg -= 5.5f;
		} else if (att.attName == "Enrage_3") {
			player.speed -= .35f;
			player.def -= 3.5f;
			player.dmg -= 6f;
			player.mDmg -= 6f;
		} else if (att.attName == "Enrage_4") {
			player.speed -= .4f;
			player.def -= 4f;
			player.dmg -= 6.5f;
			player.mDmg -= 6.5f;
		} else {
			player.speed -= .45f;
			player.def -= 4.5f;
			player.dmg -= 7f;
			player.mDmg -= 7f;
		} 
		player.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
	}

	void Alone() {
		if (att.attName == "Cupid_1") {
			cupid.Unsummon ();
		} else if (att.attName == "Cupid_2") {
			cupid.Unsummon ();
		} else if (att.attName == "Cupid_3") {
			cupid.Unsummon ();
		} else if (att.attName == "Cupid_4") {
			cupid.Unsummon ();
		} else {
			cupid.Unsummon ();
		}
		print ("Cupid Leaves your side");
	}
}
