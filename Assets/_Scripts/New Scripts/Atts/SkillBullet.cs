using UnityEngine;
using System.Collections;

public class SkillBullet : MonoBehaviour {

	float speed;
	float speedX;
	float speedY;
	GameObject database;
	AttackDatabase attData;
	Attacks att;
	public static int direction;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase>();
		att = attData.GetAttByName (this.gameObject.name);
		speed = att.attSpeed;
		switch (direction) {
		case 0:
			speedX = GetComponent<Rigidbody2D> ().velocity.x;
			speedY = speed;
			break;
		case 1:
			speedX = GetComponent<Rigidbody2D> ().velocity.x;
			speedY = -speed;
			break;
		case 2:
			speedX = speed;
			speedY = GetComponent<Rigidbody2D> ().velocity.x;
			break;
		case 3:
			speedX = -speed;
			speedY = GetComponent<Rigidbody2D> ().velocity.x;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedX, speedY);

	}
}
