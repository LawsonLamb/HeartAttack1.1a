using UnityEngine;
using System.Collections;

public class Cupid : MonoBehaviour {

	Vector3 pos;
	Player player;

	public float fireAmount;
	public float dmg;
	public bool pentrateArrow = false;

	public Transform firePoint;
	public GameObject arrow;
	int direction;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		pos = gameObject.transform.position;
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
				ChangeDirection (0);
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
				ChangeDirection (1);
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				ChangeDirection (3);
				Arrows (fireAmount);
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				ChangeDirection (2);
				Arrows (fireAmount);
			}
		}
	}

	void ChangeDirection (int direct) {
		switch (direct) {
		case 0:
			firePoint.localPosition = new Vector2 (0, 1.5f);
			direction = 0;
			break;
		case 1:
			firePoint.localPosition = new Vector2 (0, -1.5f);
			firePoint.localRotation = new Quaternion (0, 0, 89, 0);
			direction = 1;
			break;
		case 2:
			firePoint.localPosition = new Vector2 (1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 0, 0, 0);
			direction = 2;
			break;
		case 3:
			firePoint.localPosition = new Vector2 (-1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 180, 0, 0);
			direction = 3;
			break;
		}
	}

	void Arrows (float fa) {
		arrow.GetComponent<SkillBullet> ().direction = direction;
		for (int i = 0; i < fa; i++) {
			Instantiate (arrow, firePoint.position, firePoint.rotation);
		}
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
