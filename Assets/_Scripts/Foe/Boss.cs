using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {

	/*Needs to create a HUD to display the current Health of the enemy*/
	public static List<GameObject> mainhealthBar = new List<GameObject>();
	public static float fullHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetHUD (GameObject mainHUD, GameObject mainBar, float amount, Foes foe ) {
		mainHUD.transform.GetChild(0).GetChild(0).GetComponent<Image> ().sprite = foe.foeImage;
		for (int i = 0; i < amount; i++) {
			
			GameObject newBar = Instantiate (mainBar);
			newBar.name = mainBar.name + "_" +(0 + i);
			newBar.transform.SetParent (mainHUD.transform.GetChild (1).transform);
			newBar.transform.localPosition = new Vector3 (-257.5f, 0, 0);
			newBar.transform.localScale = new Vector3 (1, 1, 1);

			if (i == 0) {
				newBar.GetComponent<Image> ().color = Color.red;
			} else if (i == 1) {
				newBar.GetComponent<Image> ().color = Color.yellow;
			} else if (i == 2) {
				newBar.GetComponent<Image> ().color = Color.green;
			} else if (i == 3) {
				newBar.GetComponent<Image> ().color = Color.cyan;
			} else if (i == 4) {
				newBar.GetComponent<Image> ().color = Color.blue;
			} else {
				newBar.GetComponent<Image> ().color = Color.magenta;
			}
			mainhealthBar.Add (newBar);
		}
	}

	public static void LoseHealth (float amount, float health) {

		mainhealthBar[(int)amount - 1].transform.localScale = new Vector3 ((health/100) - (amount - 1), 1, 1);
		if (mainhealthBar[(int)amount - 1].transform.localScale.x <= 0) {
			Physical.healthBarAmount -= 1;
			if(((int)amount - 2) >= 0) {
				mainhealthBar[(int)amount - 2].transform.localScale = new Vector3 ((health/100) - (amount - 2), 1, 1);
			}
			Destroy (mainhealthBar[(int)amount - 1]);
		}
	}
}
