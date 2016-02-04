using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemySpell : MonoBehaviour {

	public int Damage;
	public int Duration;
	private Transform child;
	public GameObject Effect;
	public GameObject ImpactEffect;
	private Collider2D col;
	public float moveSpeed = .05f;
//	private GameObject Player;
	private Rigidbody2D rb;
	GameObject enemy;
	
	

	
	
	// Use this for initialization

	void Start () {
		Init();
	}
	void OnAwake(){
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (direction * moveSpeed);
		//transform.Translate (Vector2.up * moveSpeed);
		
		//rb.AddForce(direction*moveSpeed);
		//rb.velocity = transform.forward*moveSpeed;
		rb.AddForce(transform.forward*moveSpeed);
		Destroy (this.gameObject,Duration);
		//Destroy (this.gameObject,Duration);
	}
	
	
	
	void OnCollisionEnter2D(Collision2D col){
		enemy = col.gameObject;
	
		if(enemy.tag =="Player"){

			enemy.GetComponent<UI_Player>().Hit(Damage);
			Destroy(this.gameObject);

		}

	}
	void OnTriggerEnter2D(Collider2D  col){
		enemy = col.gameObject;
		if(enemy.tag =="Player"){

			enemy.GetComponent<UI_Player>().Hit(Damage);
			Destroy(this.gameObject);
			
		}

		
	}
	
	void OnDestroy(){
		Instantiate(ImpactEffect,this.transform.position,Quaternion.identity);
		/*
		if(enemy!=null){
			GameObject go = Instantiate(ImpactEffect,enemy.transform.position,Quaternion.identity) as GameObject;
			
		}
		else {
			GameObject go	= Instantiate(ImpactEffect,this.transform.position,Quaternion.identity) as GameObject;
			
		}
		*/
	}
	
	
	void Init(){
		//Player = GameObject.FindGameObjectWithTag("Player");
		rb = gameObject.GetComponent<Rigidbody2D>();
		//rb.AddForce(direction*moveSpeed);
		
	}
}


