using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolyNavAgent))]

public class Foe : MonoBehaviour
{

    public float health = 100;
    public float maxHealth = 100;
    public float damage = 10;
    public float speed;
	public int id;
	GameObject database;
	FoeDatabase foeData;
	Foes foe;
    public GameObject player;
    public GameObject damageEffect;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		database = GameObject.FindGameObjectWithTag ("Database");
		foeData = database.GetComponent<FoeDatabase> ();
		foe = foeData.GetFoeByName (this.gameObject.name);
		id = foe.foeID;
		SetFoeStats (foe, id);

	}

	void SetFoeStats (Foes foe, int i) {
		health = foe.foeHealth;
		maxHealth = foe.foeHealth;
		if ((i >= 8) && (i <= 10)) {
			print ("Boss");
			//healthBarAmount = health / 100;
			//miniFoeHUD.SetActive (mainHUDopen);
			//foeHUD.SetActive (!mainHUDopen);
			//bossIsAlive = true;
			//Boss.SetHUD (statFoeHUD, statMiniFoeHUD, statFoeHealthBar, statMiniFoeHealthBar, healthBarAmount, foe);
		}
		speed = foe.foeSpeed;
		damage = foe.foeDmg;
	}

    // Update is called once per frame
    void Update()
    {

		/* This is for making all the changes needed to happen for the bosses HUD.
		 * if (bossIsAlive == true) {
			if (Input.GetKeyDown (KeyCode.T)) {
				if (hudCase == 0) {
					hudCase = 1;
				} else if (hudCase == 1) {
					hudCase = 2;
				} else {
					hudCase = 0;
				}
				SwitchHUD ();
			}
		}*/
        if (health <= 0)
        {

            Death();
        }

    }
    void OnEnable()
    {

        
    }

    void Death()
    {
		//This is for making all the changes needed to happen when the enemy is destroyed.
		Player.enemyKillCount += 1;
		if ((id >= 8) && (id <= 10)) {
			LevelManager.IncandCheckExp (50);
		} else {
			LevelManager.IncandCheckExp (5);
		} 
		if ((id >= 5) && (id <= 7)) {
			//Spliter.SplitUp (id);
		}
		/*GenRandom.CreateRandomItem (gameObject.tag);
		miniFoeHUD.SetActive (!mainHUDopen);
		foeHUD.SetActive (!mainHUDopen);
		bossIsAlive = false;*/
        Destroy(this.gameObject);
    }


    public void Hit(float dmg)
    {

        health -= dmg;
        GameObject go = Instantiate(damageEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(go, 1.0f);

    }

    public void RangeAttack(GameObject Projectile, Vector3 direction)
    {

        Instantiate(Projectile, this.transform.position, Quaternion.LookRotation(direction));
    }

    void SetType()
    {

    }









}
