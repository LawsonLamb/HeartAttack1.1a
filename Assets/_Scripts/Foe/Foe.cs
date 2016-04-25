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
<<<<<<< HEAD
	private GenRandom npc;

=======
    Animator anim;
    bool attack = false;
>>>>>>> origin/master
    // Use this for initialization
    void Start()
	{   //gameObject.tag = "Foe";
        //gameObject.layer = "Foe";
       // gameObject.AddComponent<Animator>();
     //   anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
		database = GameObject.FindGameObjectWithTag ("Database");
		npc = GameObject.FindGameObjectWithTag ("Background").GetComponent<GenRandom> ();
        getFoeData();
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
    void getFoeData()
    {
        if (database)
        {
            foeData = database.GetComponent<FoeDatabase>();
          //  foe = foeData.GetFoeByName(this.gameObject.name);
          //  id = foe.foeID;
          //8  SetFoeStats(foe, id);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (attack)
        {

           // attack = false;
            //anim.SetBool("Attack", attack);
        }
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            database = GameObject.FindGameObjectWithTag("Database");
            getFoeData();
        }

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
       // anim.SetBool("Attack", attack);
    }
    void OnEnable()
    {

        
    }

    void Death()
    {
		//This is for making all the changes needed to happen when the enemy is destroyed.
		if ((id >= 8) && (id <= 10)) {
			player.GetComponent<Player>().LevelManager (50);
		} else {
			player.GetComponent<Player>().LevelManager (5);
		} 
		if ((id >= 5) && (id <= 7)) {
			//Spliter.SplitUp (id);
		}
		/*GenRandom.CreateRandomItem (gameObject.tag);
		miniFoeHUD.SetActive (!mainHUDopen);
		foeHUD.SetActive (!mainHUDopen);
		bossIsAlive = false;*/
<<<<<<< HEAD
		npc.GuantletGen (gameObject.tag);
=======



		GameObject.FindGameObjectWithTag ("GameController").GetComponent<Gauntlet> ().EnemyKilled ();
>>>>>>> origin/master
        Destroy(this.gameObject);
    }


    public void Hit(float dmg)
    {

        health -= dmg;
        if (damageEffect)
        {
            GameObject go = Instantiate(damageEffect, transform.position, Quaternion.identity) as GameObject;

            Destroy(go, 1.0f);
        }
        

    }

    public void RangeAttack(GameObject Projectile, Vector3 direction)
    {

        GameObject go = (GameObject)Instantiate(Projectile, this.transform.position, Quaternion.LookRotation(direction));
        go.GetComponent<EnemySpell>().Damage = damage;
    }

    void SetType()
    {
        
    }

    public void MeleeAttack(Vector3 direction)
    {

        GameObject.FindGameObjectWithTag("Background").GetComponent<UIScripts>().TakeDamage(damage);
        attack = true;
        //anim.SetBool("Attack", false);
        
        
    }

	 void OnDestory(){


	}









}
