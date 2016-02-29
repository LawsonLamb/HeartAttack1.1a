using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolyNavAgent))]

public class Foe : MonoBehaviour
{

    public int health = 100;
    public int maxHealth = 100;
    public int damage = 10;
    public int speed;
    public GameObject player;
    public GameObject damageEffect;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

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

        Destroy(this.gameObject);
    }


    public void Hit(int dmg)
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
