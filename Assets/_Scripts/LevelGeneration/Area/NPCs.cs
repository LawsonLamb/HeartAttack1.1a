using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCs : MonoBehaviour {

	GameObject database;
	EnviornmentDatabase areaData;

	string Name{ get { return gameObject.name; } set { gameObject.name = value; } }

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		areaData = database.GetComponent<EnviornmentDatabase> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SaveGuy () {
		print ("I will let you save your game");
	}
	public void StatusGuy () {
//		Player.On = !Player.On;
	}
	public void LoveBooth () {
//		GenRandom.LoveBoothItems (name);
		areaData.enviornment [12].timer -= 1.0f;
		if (areaData.enviornment [12].timer <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown(KeyCode.Return)) {
				if (Name == "SaveGuy") {
					SaveGuy ();
				} else if (Name == "StatusGuy") {
					StatusGuy ();
				} else {
					LoveBooth ();
				}
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
		//	if (Player.On == true) {
		//		Player.On = !Player.On;
		//	}
		}
	}

}
