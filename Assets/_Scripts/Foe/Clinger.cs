using UnityEngine;
using System.Collections;

public class Clinger : MonoBehaviour {

	/*When this enemy is in range of the player it will chase after him. Might even speed up.*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Player") {


			//GetComponent<Foe> ().MeleeAttack ();


		}


	}


}
