using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
///[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Attacker : MonoBehaviour {

	public float Magnitude = 3.0f;
	
	GameObject player;
	float sqrMagnitude;
	bool attack = false;
	private Animator anim;

	Enemy enemy;
	Vector3 direction;
	float distance;
	public float timeBetweenAttacks = 0.15f;  
	float timer;
	void Init(){
		enemy = gameObject.GetComponent<Enemy>();
		anim = gameObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		sqrMagnitude = Magnitude*Magnitude;
		
	}
	// Use this for initialization
	void Start () {
		Init();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		direction = player.transform.position - transform.position;
		if(Vector3.SqrMagnitude(direction) < sqrMagnitude){
			if(timer >= timeBetweenAttacks && Time.timeScale != 0){
			attack = true;
			}
			//Attack(damage);
			//anim.SetBool("Attack",attack);
			
		}
		
		else{
			attack= false;
		}
		
		
		anim.SetBool("Attack",attack);
		
		
		

	}
	

	void OnDestory(){
		print ("DIE");
	}
	

	
	
	[ContextMenu("Damage")]
	public void TestDMG(){
		player.gameObject.GetComponent<UI_Player>().Hit (enemy.damage);

	}
	void  OnCollisionEnter2D(Collision2D coll){
		
		
	}

	void OnDrawGizmos(){
		#if UNITY_EDITOR
		UnityEditor.Handles.color = Color.yellow;
		UnityEditor.Handles.DrawWireDisc(this.transform.position,this.transform.forward,Magnitude);
		
		//Debug.DrawLine(this.transform.position,player.transform.position);
		
		#endif		
	}
	
	
	

}
