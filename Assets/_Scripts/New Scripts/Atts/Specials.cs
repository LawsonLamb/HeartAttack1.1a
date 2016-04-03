using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Specials : MonoBehaviour {

	string name;
	GameObject database;
	AttackDatabase attData;
	Attacks att;

	GameObject player;
	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
		ActivateSkill ();
	}

	public void ActivateSkill () {
	
		att = attData.GetAttByName (name);

		att.attSpeed = player.GetComponent<Player>().speed;

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


		print ("Your stats are buffed until cool down is over.");

	}
	void Restore () {


		print ("You can recover all your missing health.");
	}
	void Cupid () {


	}
}
