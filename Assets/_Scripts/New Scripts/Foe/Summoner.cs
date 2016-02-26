using UnityEngine;
using System.Collections;

public class Summoner : MonoBehaviour {

	/*Summons other enemies. For now the only enemy that can be summoned are: 
	 *Colestrol (ID: 1)
	 *Cluster (ID: 5)*/
	GameObject database;
	FoeDatabase foeData;
	Foes foeOne;
	Foes foeTwo;
	GameObject parentFoe;

	float magic;
	float fullMagic = 500;
	public static float fullHealth;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Database");
		foeData = database.GetComponent<FoeDatabase> ();
		parentFoe = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		if (Physical.health >= (fullHealth/2)) {
			magic += 0.5f;
			if (magic >= fullMagic) {
				Summon (1,5);
				magic = 0;
			}
		} else if (Physical.health <= (fullHealth/2)) {
			fullMagic = 250;
			magic += 0.5f;
			if (magic >= fullMagic) {
				Summon (1,5);
				magic = 0;
			}
		}
	}

	void Summon (int foeOneID, int foeTwoID) {

		int choice = Random.Range (0, 5);

		foeOne = foeData.GetFoeByID (foeOneID);
		foeTwo = foeData.GetFoeByID (foeTwoID);
		switch (choice) {
		case 0:
			for (int i = 0; i < 4; i++) {
				foeOne.CreateGameObject ();
				foeOne.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
			}
			print ("Created 4 Colestrol and 0 Cluster");
			break;
		case 1:
			for (int i = 0; i < 4; i++) {
				if (i <= 2) {
					foeOne.CreateGameObject ();
					foeOne.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				} else {
					foeTwo.CreateGameObject ();
					foeTwo.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				}
			}
			print ("Created 3 Colestrol and 1 Cluster");
			break;
		case 2:
			for (int i = 0; i < 4; i++) {
				if (i <= 1) {
					foeOne.CreateGameObject ();
					foeOne.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				} else {
					foeTwo.CreateGameObject ();
					foeTwo.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				}
			}
			print ("Created 2 Colestrol and 2 Cluster");
			break;
		case 3:
			for (int i = 0; i < 4; i++) {
				if (i <= 0) {
					foeOne.CreateGameObject ();
					foeOne.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				} else {
					foeTwo.CreateGameObject ();
					foeTwo.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
				}
			}
			print ("Created 1 Colestrol and 3 Cluster");
			break;
		case 4:
			for (int i = 0; i < 4; i++) {
				foeTwo.CreateGameObject ();
				foeTwo.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
			}
			print ("Created 0 Colestrol and 4 Cluster");
			break;
		}
	}
}
