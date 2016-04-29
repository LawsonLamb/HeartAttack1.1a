using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HTPControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HomeButton() {
		//Application.LoadLevel (0);
		SceneManager.LoadScene (0);
	}

	public void PlayButton() {
	//	Application.LoadLevel (2);
		SceneManager.LoadScene (2);
	}
}
