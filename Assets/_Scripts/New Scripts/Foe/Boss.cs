using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {

	/*Needs to create a HUD to display the current Health of the enemy*/
	public static List<GameObject> minihealthBar = new List<GameObject>();
	public static List<GameObject> mainhealthBar = new List<GameObject>();
	public static float fullHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetHUD (GameObject mainHUD, GameObject miniHUD, GameObject mainBar, GameObject miniBar, float amount, Foes foe ) {
		miniHUD.transform.GetChild(0).GetChild(0).GetComponent<Image> ().sprite = foe.foeImage;
		mainHUD.transform.GetChild(0).GetChild(0).GetComponent<Image> ().sprite = foe.foeImage;
		miniHUD.transform.GetChild(1).GetComponent<Text> ().text = foe.foeName;
		for (int i = 0; i < amount; i++) {
			GameObject newMBar = Instantiate (miniBar);
			newMBar.name = miniBar.name + "_" +(0 + i);
			newMBar.transform.SetParent (miniHUD.transform.GetChild (2).transform);
			newMBar.transform.localPosition = new Vector3 (-40f, 0, 0);
			newMBar.transform.localScale = new Vector3 (1, 1, 1);

			GameObject newBar = Instantiate (mainBar);
			newBar.name = mainBar.name + "_" +(0 + i);
			newBar.transform.SetParent (mainHUD.transform.GetChild (1).transform);
			newBar.transform.localPosition = new Vector3 (-257.5f, 0, 0);
			newBar.transform.localScale = new Vector3 (1, 1, 1);

			if (i == 0) {
				newMBar.GetComponent<Image> ().color = Color.red;
				newBar.GetComponent<Image> ().color = Color.red;
			} else if (i == 1) {
				newMBar.GetComponent<Image> ().color = Color.yellow;
				newBar.GetComponent<Image> ().color = Color.yellow;
			} else if (i == 2) {
				newMBar.GetComponent<Image> ().color = Color.green;
				newBar.GetComponent<Image> ().color = Color.green;
			} else if (i == 3) {
				newMBar.GetComponent<Image> ().color = Color.cyan;
				newBar.GetComponent<Image> ().color = Color.cyan;
			} else if (i == 4) {
				newMBar.GetComponent<Image> ().color = Color.blue;
				newBar.GetComponent<Image> ().color = Color.blue;
			} else {
				newMBar.GetComponent<Image> ().color = Color.magenta;
				newBar.GetComponent<Image> ().color = Color.magenta;
			}
			minihealthBar.Add (newMBar);
			mainhealthBar.Add (newBar);
		}
	}

	public static void LoseHealth (float amount, float health) {

		minihealthBar[(int)amount - 1].transform.localScale = new Vector3 ((health/100) - (amount - 1), 1, 1);
		mainhealthBar[(int)amount - 1].transform.localScale = new Vector3 ((health/100) - (amount - 1), 1, 1);
		if ((minihealthBar[(int)amount - 1].transform.localScale.x <= 0) && (mainhealthBar[(int)amount - 1].transform.localScale.x <= 0)) {
			Physical.healthBarAmount -= 1;
			if(((int)amount - 2) >= 0) {
				minihealthBar[(int)amount - 2].transform.localScale = new Vector3 ((health/100) - (amount - 2), 1, 1);
				mainhealthBar[(int)amount - 2].transform.localScale = new Vector3 ((health/100) - (amount - 2), 1, 1);
			}
			Destroy (minihealthBar[(int)amount - 1]);
			Destroy (mainhealthBar[(int)amount - 1]);
		}
	}
}
