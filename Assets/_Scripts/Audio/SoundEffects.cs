using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffects : MonoBehaviour {


	public List<AudioSource> Audio;

	void Start (){
		for(int i=0;i< transform.childCount;i++){

			if (transform.GetChild (i).GetComponent<AudioSource> ()) {
				Audio.Add (transform.GetChild (i).GetComponent<AudioSource> ());
			}


		}

	}
	
	public void PlaySound(int clip) {


	
			
			PlayAudio (Audio [clip]);



	}


	private void PlayAudio(AudioSource source){
		if (!source.isPlaying) {

			source.Play ();
		} else {

		}

	}



}
