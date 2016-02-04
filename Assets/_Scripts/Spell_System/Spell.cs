using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Spell : MonoBehaviour {

	public int ID;
	public int Damage;
	public int Duration;
	private Transform child;
	public GameObject Effect;
	public GameObject ImpactEffect;
	private Collider2D col;
	public float moveSpeed = .05f;
	private GameObject Player;
	private Rigidbody2D rb;
	Vector2 direction;
	

	// Use this for initialization
	void OnEnable(){
		Init();

	}
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
	//	rb.velocity+= direction*moveSpeed;
		rb.AddForce(direction*moveSpeed);

		
		Destroy (this.gameObject,Duration);
	}

	void OnCollisionEnter2D(Collision2D col){
		GameObject enemy = col.gameObject;
		if(enemy.tag =="Enemy"){
			 enemy.GetComponent<Enemy>().Hit(Damage);
			Destroy(this.gameObject);

		}
	}
void OnTriggerEnter2D(Collider2D  col){

		GameObject enemy = col.gameObject;
		if(enemy.tag =="Enemy"){
			enemy.GetComponent<Enemy>().Hit(Damage);
			Destroy(this.gameObject);
			
		}

	}

	void OnDestroy(){
		Instantiate(ImpactEffect,this.transform.position,Quaternion.identity);
	}

	void Init(){
		Player = GameObject.FindGameObjectWithTag("Player");
		direction = Player.GetComponent<Player_Control>().VecDirection;
		rb = gameObject.GetComponent<Rigidbody2D>();
		rb.AddForce(direction*moveSpeed);

	}
}
