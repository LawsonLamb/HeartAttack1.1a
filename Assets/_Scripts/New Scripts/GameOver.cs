﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartButton() {
		if (Application.loadedLevel == 2) {
			Application.LoadLevel (2);
		} else {
			//Load story mode level
		}
	}
	public void MainMenuButton() {
		Application.LoadLevel (0);
	}
	public void QuitButton() {
		Application.Quit ();
	}
}