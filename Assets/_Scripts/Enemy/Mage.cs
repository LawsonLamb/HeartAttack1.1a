using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
public class Mage : MonoBehaviour {
	
	public GameObject RangeSpell;
	public float timeBetweenSpells = 0.15f;  
	float timer;
	public int damage= 10;
	public float Magnitude = 3.0f;
	bool attack = false;
	GameObject player;
	float sqrMagnitude;
	private Animator anim;
	Vector3 direction;
	float distance;
//	Enemy enemy;

	void Init(){

	//	enemy = gameObject.GetComponent<Enemy>();
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
		Attack();
		
		
	
	}
	public void Attack(){
		timer += Time.deltaTime;
		direction = player.transform.position - transform.position;
		if(Vector3.SqrMagnitude(direction) < sqrMagnitude){
			if(timer >= timeBetweenSpells && Time.timeScale != 0){
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
	
	public void Shoot(){
		
		
	}

	

	
	
	[ContextMenu("Damage")]
	public void TestDMG(){
		//player.gameObject.GetComponent<Player_Stats>().Hit (damage);
		RangeAttack();
		//Hit(damage);
		
		
	}

	void RangeAttack(){

		Instantiate(RangeSpell,this.transform.position, Quaternion.LookRotation(direction));
	}
	void OnDrawGizmos(){
		#if UNITY_EDITOR
		UnityEditor.Handles.color = Color.blue;
		UnityEditor.Handles.DrawWireDisc(this.transform.position,this.transform.forward,Magnitude);
		

		#endif		
	}
	

}
