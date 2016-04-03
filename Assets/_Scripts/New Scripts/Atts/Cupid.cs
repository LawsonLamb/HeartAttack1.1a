using UnityEngine;
using System.Collections;

public class Cupid : MonoBehaviour {

	Vector3 pos;
	GameObject player;
	// Use this for initialization
	void Start () {
	
		pos = gameObject.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			pos.y += player.GetComponent<Player>().speed;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= player.GetComponent<Player>().speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= player.GetComponent<Player>().speed;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += player.GetComponent<Player>().speed;
		} else {
		}

		gameObject.transform.position = pos;

	}
}
