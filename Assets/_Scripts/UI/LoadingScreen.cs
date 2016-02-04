using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

	public GameObject background;
	public GameObject text;
	public GameObject progressBar;

	private int loadProgress = 0;

	// Use this for initialization
	void Start () {
		background.SetActive (false);
		text.SetActive (false);
		progressBar.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int sceneID) {
		StartCoroutine (DisplayLoadingScreen (sceneID));
	}

	IEnumerator DisplayLoadingScreen (int Id) {

		background.SetActive (true);
		text.SetActive (true);
		progressBar.SetActive (true);

		progressBar.transform.localScale = new Vector3 (loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

		text.GetComponent<GUIText>().text = "Loading " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync (Id);
		while (!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			text.GetComponent<GUIText>().text = "Loading " + loadProgress + "%";
			progressBar.transform.localScale = new Vector3 (async.progress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
			yield return null;
		}
	}
}
