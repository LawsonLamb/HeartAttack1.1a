using UnityEngine;
using System.Collections;

public class HTPControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HomeButton() {
		Application.LoadLevel (0);
	}

	public void PlayButton() {
		Application.LoadLevel (2);
	}
}
