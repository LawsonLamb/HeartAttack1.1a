using UnityEngine;
using System.Collections;

public class CameraTrigger : MonoBehaviour {

	public bool PlayerInTrigger;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Player"){

			GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
			//Vector2.Lerp(camera.transform.position,this.transform.position,Time.deltaTime);

			camera.transform.position =	new Vector3(this.transform.position.x,this.transform.position.y,camera.transform.position.z);
			PlayerInTrigger = true;
		}


	}


	void OnTriggerExit2D(Collider2D col){

		PlayerInTrigger = false;

	}
















}
