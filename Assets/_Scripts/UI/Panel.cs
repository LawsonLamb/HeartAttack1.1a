using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {

	public bool isActive;

	void Start(){

		isActive = gameObject.activeSelf;
	}

	public void Toggle(){

		isActive = gameObject.activeSelf;
		isActive =!isActive;
		gameObject.SetActive(isActive);




	}
}
