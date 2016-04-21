using UnityEngine;
using System.Collections;


public class Doors : MonoBehaviour
{

    public bool Locked;
    public Vector2 postion;
      
    GameObject Player;
    // 14,2
    //14,12
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player") {
			Player.transform.position = postion;
		}
    }

    

    
}
