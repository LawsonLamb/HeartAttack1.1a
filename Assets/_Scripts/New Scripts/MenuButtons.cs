using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public GameObject StartUI;
	public GameObject ModeUI;

	// Use this for initialization
	void Start () {
	
		StartUI.SetActive (true);
		ModeUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartButton() {
		StartUI.SetActive (false);
		ModeUI.SetActive (true);
	}

	public void CreditButton() {
		Application.LoadLevel (1);
	}

	public void QuitButton() {
		Application.Quit ();
	}

	public void StoryButton() {
		//Load Actual Story Game Mode
	}

	public void GauntletButton() {
		Application.LoadLevel (3);
	}

	public void ReturnButton() {
		StartUI.SetActive (true);
		ModeUI.SetActive (false);
	}
}
