using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnButtons : MonoBehaviour {

	Text text;
	
	// Use this for initialization
	void Start () {
	
		text = GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (OnClick.loading == true) {
			text.text = "Home";
		}
		
		if (OnClick.saving == true) {
			text.text = "Levels";
		}
	}
}
