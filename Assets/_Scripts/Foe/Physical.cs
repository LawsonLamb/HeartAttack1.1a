using UnityEngine;
using System.Collections;

public class Physical : MonoBehaviour {

	/*All that is missing now is the movement for the enemy. Speed is already set depending on the foe.
	This is a base Script since all enemeies will have a physcail script to them.*/
	FoeDatabase foeData;
	UIScripts displays;
	Player player;

	Foes thisFoe;
	GenRandom npc;
	public float health;
	public string m_name;
	public int id;
	float speed;
	int dmg;


	// Use this for initialization
	void Start () {

		foeData = GameObject.FindGameObjectWithTag ("Database").GetComponent<FoeDatabase>();
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetFoeStats (Foes foe) {
		thisFoe = foe;
		health = foe.foeHealth;
		speed = foe.foeSpeed;
		m_name = foe.foeName;
		dmg = foe.foeDmg;
		id = foe.foeID;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			displays.TakeDamage (dmg);
		} else if (col.gameObject.tag == "Blood") {
			if (health <= 0) {
				if (col.gameObject.tag != "Boss") {
					player.LevelManager (5);
				}
				if ((thisFoe.foeID >= 5) && (thisFoe.foeID <= 7)) {
					//Spliter.Split (id);
					//Spliter.Split (id);
				}
				npc.GuantletGen (gameObject);
				player.enemyKillCount += 1;
				Destroy (gameObject);
			}
		}
	}
}
