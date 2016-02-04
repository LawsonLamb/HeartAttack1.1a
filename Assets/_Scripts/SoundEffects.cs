using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {

	public AudioClip[] sfxArray;
	
	public void PlaySound(int clip) {

		AudioSource audio = GetComponent<AudioSource> ();
		switch (clip) {
		case 0://Slash SFX
			audio.clip = sfxArray [clip];
			audio.priority = 180;
			audio.Play ();
			break;
		case 1://HeartBeat SFX
			audio.clip = sfxArray [clip];
			audio.priority = 128;
			audio.Play ();
			break;
		case 2://Death SFX
			audio.clip = sfxArray [clip];
			audio.priority = 128;
			audio.Play ();
			break;
		case 3://Pick Up item SFX
			audio.clip = sfxArray [clip];
			audio.priority = 120;
			audio.Play ();
			break;
		case 4://Level Up SFX
			audio.clip = sfxArray [clip];
			audio.priority = 120;
			audio.Play ();
			break;
		case 5://Potion SFX
			audio.clip = sfxArray [clip];
			audio.priority = 120;
			audio.Play ();
			print ("Played");
			break;
		}
	}
}
