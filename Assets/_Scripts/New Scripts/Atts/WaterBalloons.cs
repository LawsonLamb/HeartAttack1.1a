using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterBalloons : MonoBehaviour {




	public GameObject ImpactEffect;
	public float duration;
	// Use this for initialization
	void Start () {


	
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, duration);

	


	}


	void OnDestroy()
	{
		if (ImpactEffect) {
			GameObject go = (GameObject)Instantiate (ImpactEffect, this.transform.position, Quaternion.identity);
			go.AddComponent<Explosion> ();
		}
			
}

}