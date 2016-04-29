using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Resume(){


	}


	public void MainMenu(){

		//Application.LoadLevel (0);
		SceneManager.LoadScene(0);
	}


}
