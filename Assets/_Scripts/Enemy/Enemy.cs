using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BehaviorDesigner.Runtime;
///[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
//[ExecuteInEditMode]
public class Enemy : MonoBehaviour {
//	Leveling_System ls;
	public EnemyType type;
	public int age;
	[HideInInspector]
	public int health =100;
	public int maxHealth = 100;
	public int damage= 10;
	 Image image;
	public GameObject effect;
	public GameObject player;


	void Init(){
		GameObject.FindGameObjectWithTag("Player");
	//	ls = gameObject.GetComponent<Leveling_System>();
		image = gameObject.transform.GetComponentInChildren<Image>();
	//	ls.currentLevelID = age;
		//player = GameObject.FindGameObjectWithTag("Player");

	}
	// Use this for initialization
	void Start () {
		Init();
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(health<=0){
			
			Death();
		}
	}
	void Death(){

		GetComponent<Loot>().DropLoot();
		GameObject.FindGameObjectWithTag("Player").GetComponent<Leveling_System>().AddXP(10);
		Destroy(this.gameObject);

	}


	void OnDestory(){
	//player.GetComponent<Leveling_System>().AddXP(10);
	}

	public void Hit(int dmg){

		health-= dmg;
		GameObject go =  Instantiate(effect, transform.position, Quaternion.identity) as GameObject;
		Destroy(go, 1.0f);
		image.fillAmount =(float)health/(float)maxHealth;

	}


	









}
