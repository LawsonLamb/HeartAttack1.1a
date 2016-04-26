using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public GameObject Target;
	public float radius = 5.0F;
	public float power = 10.0F;
	public float damage = 100.0f;
	// Use this for initialization
	void Start () {
		Vector2 explosionPos = transform.position;
	
		Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, radius);
		foreach (Collider2D hit in colliders) {

			if (hit.gameObject.tag == "Foe") {
				hit.gameObject.GetComponent<Foe> ().Hit (damage);

			}

	}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
