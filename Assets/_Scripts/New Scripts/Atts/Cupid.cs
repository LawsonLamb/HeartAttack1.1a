using UnityEngine;
using System.Collections;

public class Cupid : MonoBehaviour {

	Vector3 pos;
	Player player;

	public float fireAmount;
	public float dmg;
	public bool pentrateArrow = false;

	// Use this for initialization
	void Start () {
	
		pos = gameObject.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		Fly ();
		ShootArrows ();
	}

	void Fly(){

		if (Input.GetKey (KeyCode.W)) {
			pos.y += player.speed;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= player.speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= player.speed;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += player.speed;
		} else {
		}

		gameObject.transform.position = pos;

	}

	void ShootArrows(){
		if (player.magic > 0) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Arrows (fireAmount);
			}
		}
	}

	void Arrows (float fa) {
		
	}

	public void Summon(int cupidLv) {

		if (cupidLv == 1) {
			fireAmount = 1;
			dmg = 2.5f;
		} else if (cupidLv == 2) {
			fireAmount = 1;
			dmg = 5f;
		} else if (cupidLv == 3) {
			fireAmount = 1;
			dmg = 7.5f;
			pentrateArrow = true;
		} else if (cupidLv == 4) {
			fireAmount = 2;
			dmg = 10f;
		} else {
			fireAmount = 2;
			dmg = 12.5f;
		}

	}

	public void Unsummon() {
		this.gameObject.SetActive (false);
	}
}
