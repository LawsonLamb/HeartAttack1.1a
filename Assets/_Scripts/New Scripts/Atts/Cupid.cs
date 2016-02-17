using UnityEngine;
using System.Collections;

public class Cupid : MonoBehaviour {

	Vector3 pos;

	// Use this for initialization
	void Start () {
	
		pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			pos.y += Player.speed;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= Player.speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= Player.speed;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += Player.speed;
		} else {
		}

		gameObject.transform.position = pos;

	}
}
