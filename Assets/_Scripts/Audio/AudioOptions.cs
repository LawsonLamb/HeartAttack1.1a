using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioOptions : MonoBehaviour {

	Toggle toggle;
	Scrollbar scrollBar;
	GameObject Audio;
	bool audioSetting = true;
	bool sound = false;
	float volume;
	// Use this for initialization
	void Start () {
		Audio = GameObject.FindGameObjectWithTag ("Sounds");
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Mute() {

		toggle = GetComponent<Toggle> ();
		

		if (toggle.isOn == audioSetting) {
			sound = false;
			Audio.GetComponent<AudioSource>().mute = sound;
		} else {
			sound = true;
			Audio.GetComponent<AudioSource>().mute = sound;
		}
	}

	public void Volume() {
		scrollBar = GetComponent<Scrollbar> ();

		volume = scrollBar.value;
		
		Audio.GetComponent<AudioSource>().volume = volume;
	}
}
