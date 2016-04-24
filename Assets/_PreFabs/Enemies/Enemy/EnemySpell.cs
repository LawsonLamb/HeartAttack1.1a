using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemySpell : MonoBehaviour {

	public float Damage;
	public int Duration;
	private Transform child;
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
		
	
		rb.AddForce(transform.forward*moveSpeed);
		Destroy (this.gameObject,Duration);
	
	}
	
	
	

	void OnTriggerEnter2D(Collider2D  col){
		enemy = col.gameObject;
		if (enemy.tag == "Player") {

			GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ().TakeDamage (Damage);
			Destroy (this.gameObject);
			
		}
			if (enemy.tag == "polyNav") {
			print ("Destory");
			Destroy (this.gameObject);
		}

		
	}
	
	void OnDestroy(){
        if (ImpactEffect)
        {
            Instantiate(ImpactEffect, this.transform.position, Quaternion.identity);
        }
		
	}
	
	
	void Init(){
		
		rb = gameObject.GetComponent<Rigidbody2D>();
		
	}
}


