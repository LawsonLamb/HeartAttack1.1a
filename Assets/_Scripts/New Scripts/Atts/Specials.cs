using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Specials : MonoBehaviour {

	string name;
	GameObject database;
	AttackDatabase attData;
	Attacks att;

	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase> ();
		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
		ActivateSkill ();
	}

	public void ActivateSkill () {
	
		att = attData.GetAttByName (name);

		att.attSpeed = Player.speed;

		if ((att.attID >= 5) && (att.attID <= 9)) {
			Enrage ();
		} else if ((att.attID >= 15) && (att.attID <= 19)) {
			Restore ();
		} else if ((att.attID >= 25) && (att.attID <= 29)) {
			Cupid ();
		}
		Destroy (gameObject);
	}

	void Enrage () {

		if (att.attID == 5) {
			Player.preCoolDown = 10f;
			Player.dmg += 45f;
			Player.mDmg += 50f;
			Player.def += 5.0f;
			Player.speed += .25f;
			GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
		} else if (att.attID == 6) {
			Player.preCoolDown = 15f;
			Player.dmg += 50f;
			Player.mDmg += 55f;
			Player.def += 5.5f;
			Player.speed += .5f;
			GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.cyan;
		} else if (att.attID == 7) {
			Player.preCoolDown = 20f;
			Player.dmg += 55f;
			Player.mDmg += 60f;
			Player.def += 6.0f;
			Player.speed += .75f;
			GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		} else if (att.attID == 8) {
			Player.preCoolDown = 25f;
			Player.dmg += 60f;
			Player.mDmg += 65f;
			Player.def += 6.5f;
			Player.speed += 1.0f;
			GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.gray;
		} else {
			Player.preCoolDown = 30f;
			Player.dmg += 65f;
			Player.mDmg += 70f;
			Player.def += 7.0f;
			Player.speed += 1.25f;
			GameObject.Find ("Player").gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		print ("Your stats are buffed until cool down is over.");

	}
	void Restore () {

		if (att.attID == 15) {
			Player.preCoolDown = 10f;
		} else if (att.attID == 15) {
			Player.preCoolDown = 8f;
		} else if (att.attID == 15) {
			Player.preCoolDown = 6f;
		} else if (att.attID == 15) {
			Player.preCoolDown = 4f;
		} else {
			Player.preCoolDown = 2f;
		}

		for (int i = 0; i < Player.hLoads; i++) {
			if (i < (Player.hLoads - 1)) {
				Player.healthLoadList [i].GetComponent<Image> ().color = Color.red;
				Player.miniHealthLoadList [i].GetComponent<Image> ().color = Color.red;
			}
		}

		if (Points.heart % 4 == 0) {
			Player.healthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.red;
			Player.miniHealthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.red;
		} else {
			Player.healthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.gray;
			Player.miniHealthLoadList [Player.hLoads - 1].GetComponent<Image> ().color = Color.gray;
		}
		print ("You can recover all your missing health.");
	}
	void Cupid () {

		if (att.attID == 25) {
			Player.preCoolDown = 10f;
		} else if (att.attID == 26) {
			Player.preCoolDown = 15f;
		} else if (att.attID == 27) {
			Player.preCoolDown = 20f;
		} else if (att.attID == 28) {
			Player.preCoolDown = 25f;
		} else {
			Player.preCoolDown = 30f;
		}

		GameObject cupid = new GameObject ();
		cupid.name = "Cupid_Follower";
		cupid.AddComponent<SpriteRenderer> ().sprite = att.attIcon;
		cupid.AddComponent<Cupid> ();
		cupid.transform.localScale = new Vector3 (4, 4, 1);
		cupid.transform.position = Player.firePoint.position;
		cupid.transform.rotation = Player.firePoint.rotation;
		cupid.transform.SetParent (GameObject.Find ("Player").transform);
	}
}
