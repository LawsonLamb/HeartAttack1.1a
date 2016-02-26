using UnityEngine;
using System.Collections;

public class Spliter : MonoBehaviour {


	/*Splits into smaller enemies. There are 3 different spliters.
	 *Spliter 1: Cluster (ID: 5), splits into 3 Colestrol (ID: 1).
	 *Spliter 2: Pack (ID: 6), splits into 4 Cigarettes (ID: 3).
	 *Spliter 3: Chilly Burger (ID: 7), splits into 1 Heart Burn (ID: 0) &  1 Grease Jar (ID: 2).*/
	GameObject database;
	static FoeDatabase foeData;
	static Foes foe;
	static GameObject parentFoe;
	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Database");
		foeData = database.GetComponent<FoeDatabase> ();
		parentFoe = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void SplitUp (int id) {
		if (id == 5) {
			foe = foeData.GetFoeByID (1);
			for (int i = 0; i < 3; i++) {
				foe.CreateGameObject ();
				foe.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
			}
		} else if (id == 6) {
			foe = foeData.GetFoeByID (3);
			for (int i = 0; i < 4; i++) {
				foe.CreateGameObject ();
				foe.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
			}
		} else {
			foe = foeData.GetFoeByID (0);
			foe.CreateGameObject ();
			foe.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);

			foe = foeData.GetFoeByID (2);
			foe.CreateGameObject ();
			foe.foe.transform.localPosition = new Vector3 (GameObject.Find (parentFoe.name).transform.localPosition.x, GameObject.Find (parentFoe.name).transform.localPosition.y, 0);
		}
	}
}
