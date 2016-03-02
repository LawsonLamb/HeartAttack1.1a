using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public static int lv = 0;
	public static int currExp = 0;
	public static int maxExp = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void IncandCheckExp (int expInc) {
	
		currExp += expInc;
		if (currExp >= maxExp) {
			lv += 1;
			maxExp = 50 + (125 * lv);
			currExp = 0;
			Player.points += 3;
			Points.ActivateAll ();
		}
	}
}
