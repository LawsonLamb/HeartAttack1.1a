using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KeyboardControls : MonoBehaviour {


	//public List<GameObject> Panels;

	public KeyCode PauseKey;
	public KeyCode InventoryKey;
	public KeyCode statKey;




	public GameObject pausePanel;
	public GameObject statPanel;
	public GameObject skillPanel;
	public GameObject miniMapPanel;
	public GameObject playerHud;
	public GameObject tooltip;
	public GameObject letters;

	bool openPauseMenu;
	bool openSEIMenu;
	bool openSkillMenu;
	bool openPlayerHud;
	bool openMiniMap;
	bool openLetter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		/*if (Application.loadedLevel == 5) {
			Game_Play_Only ();
		}*/
		Game_Play_Only();
	}

	void Game_Play_Only() {

		//Pauses the game
		if (Input.GetKeyDown (KeyCode.P)) {
			openPauseMenu = pausePanel.activeSelf;
			openPauseMenu = !openPauseMenu;
		
			pausePanel.SetActive (openPauseMenu);
		}

		//Opens Stat/Equip/Inv Menu
		if (Input.GetKeyDown (KeyCode.I)) {
			openSEIMenu = statPanel.activeSelf;
			openSEIMenu = !openSEIMenu;
			statPanel.SetActive (openSEIMenu);
		}

		//Opens letter Menu
		if (Input.GetKeyDown (KeyCode.L)) {
			openLetter = letters.activeSelf;
			openLetter = !openLetter;
			tooltip.SetActive (false);
			letters.SetActive (openLetter);
		}

		//Opens Skills Menu
		if (Input.GetKeyDown (KeyCode.K)) {
			openSkillMenu = skillPanel.activeSelf;
			openSkillMenu = !openSkillMenu;
			skillPanel.SetActive (openSkillMenu);
		}

		//Turns the Player Hud on/off
		if (Input.GetKeyDown (KeyCode.U)) {
			openPlayerHud = playerHud.activeSelf;
			openPlayerHud = !openPlayerHud;
			playerHud.SetActive (openPlayerHud);
		}

		//Turns Mini Map on/off
		if (Input.GetKeyDown (KeyCode.M)) {
			openMiniMap = miniMapPanel.activeSelf;
			openMiniMap = !openMiniMap;
			miniMapPanel.SetActive (openMiniMap);
		}

	}



}
