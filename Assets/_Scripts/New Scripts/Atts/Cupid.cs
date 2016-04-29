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
	private float SkillRotation;
	//private Vector2 VecDirection;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		gameObject.transform.localScale = new Vector3(3, 3, 1);
	}
	
	// Update is called once per frame
	void Update () {
		Fly ();
		ShootArrows ();
	}

	void Fly(){

		pos = new Vector2(player.gameObject.transform.localPosition.x + 2, player.gameObject.transform.localPosition.y + 1) ;
		/*if (Input.GetKey (KeyCode.W)) {
			pos.y += player.gameObject.transform.position.y;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= player.speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= player.gameObject.transform.position.y;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += player.speed;
		} else {
		}*/

		gameObject.transform.localPosition = pos;

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
			//VecDirection = Vector2.up;
			SkillRotation = 90.0f;

			break;
		case 1:
			firePoint.localPosition = new Vector2 (0, -1.5f);

			firePoint.localRotation = new Quaternion (0, 0, 90, 0);

			//VecDirection = Vector2.down;
			SkillRotation = -90.0f;

			direction = 1;
			break;
		case 2:
			firePoint.localPosition = new Vector2 (1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 0, 270, 0);
			//VecDirection = Vector2.left;
			SkillRotation = 0.0f;

			direction = 2;
			break;
		case 3:
			firePoint.localPosition = new Vector2 (-1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 0, 180, 0);
			//VecDirection = Vector2.right;
			SkillRotation = 180.0f;
			direction = 3;
			break;
		}
	}

	void Arrows (float fa) {
		arrow.GetComponent<SkillBullet> ().direction = direction;
		for (int i = 0; i < fa; i++) {
			Instantiate (arrow,this.transform.position,Quaternion.Euler(0,0,SkillRotation) );
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
