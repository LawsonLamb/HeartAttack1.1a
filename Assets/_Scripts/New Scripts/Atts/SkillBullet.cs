using UnityEngine;
using System.Collections;

public class SkillBullet : MonoBehaviour {

	float speed;
	float speedX;
	float speedY;
	public float lifeSpan = 75f;
    public GameObject ImpactEffect;
	GameObject database;
	AttackDatabase attData;
	Attacks att;
	public static int direction;
	public static float dmg;
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

		speedY -= 0.025f;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedX, speedY);

		lifeSpan -= 0.5f;
		if (lifeSpan <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Foe") {
			Destroy (gameObject);
		}
	}
    void OnDestroy()
    {
        Instantiate(ImpactEffect, this.transform.position, Quaternion.identity);
    }
}
