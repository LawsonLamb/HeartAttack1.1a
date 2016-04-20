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
	public int direction;
	public float dmg;
	float yRot;
	UIScripts displays;
	Animator ani;
	// Use this for initialization
	void Start () {
		yRot = 0.0f;
		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase>();
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		ani = GetComponent<Animator> ();
		att = attData.GetAttByID (displays.currRegSkill.attID);
		speed = att.attSpeed;
		switch (direction) {
		case 0:
			//speedX = GetComponent<Rigidbody2D> ().velocity.x;
			if (this.name.Contains ("Blood")) {

			}
			speedY = speed;
			break;
		case 1:
			if (this.name.Contains ("Blood")) {

			}
			//speedX = GetComponent<Rigidbody2D> ().velocity.x;
			speedY = -speed;
			break;
		case 2:
			speedX = speed;
			if (this.name.Contains ("Blood")) {

			}
			//speedY = GetComponent<Rigidbody2D> ().velocity.x;
			break;
		case 3:
			speedX = -speed;
		//	speedY = GetComponent<Rigidbody2D> ().velocity.x;
			break;
		}
	
	
	}
	
	// Update is called once per frame
	void Update () {

		//speedY -= 0.025f;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speedX, speedY);

		lifeSpan -= 0.5f;
		if (lifeSpan <= 0) {
			//ani.SetTrigger ("NoObjectHit");
			Splat();
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if ((col.gameObject.tag == "Boss") || (col.gameObject.tag == "Foe")){
	//		ani.SetTrigger ("ObjectHit");
			Splat();
		}
	}
<<<<<<< HEAD
=======

>>>>>>> origin/master

	public void Splat () {
		Destroy (gameObject);
	}

    void OnDestroy()
    {
		if (ImpactEffect) {
			Instantiate (ImpactEffect, this.transform.position, Quaternion.identity);
		}
    }
<<<<<<< HEAD
=======

>>>>>>> origin/master
}
