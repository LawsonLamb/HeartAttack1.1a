using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Attacks {

	public GameObject attack;
	public string attName;
	public int attID;
	public int amountFired;
	public float attSpeed;
	public int manaUse;
	public Sprite attIcon;
	public AttackType attType;

	public enum AttackType {
		Regular,
		Special
	}

	public Attacks () {
	}

	public Attacks (string name, int id, int fireAmount, float speed, int manaCost, AttackType type){
		attName = name;
		attID = id;
		amountFired = fireAmount;
		attSpeed = speed;
		manaUse = manaCost;
		attType = type;
	}

	public void CreateGameObject (int direction, Transform firePoint) {
		attack = new GameObject ();
		attack.name = attName;
		if(((attID < 5) || (attID > 9)) && ((attID < 15) || (attID > 19))) {
			attack.AddComponent<SpriteRenderer> ().sprite = attIcon;
		}
		if (attType == AttackType.Regular) {
			attack.AddComponent<CircleCollider2D> ();
			attack.AddComponent<SkillBullet> ();
			attack.AddComponent<Rigidbody2D> ();
			SkillBullet.direction = direction;
		} else if (attType == AttackType.Special) {
			attack.AddComponent<Specials> ();
		}
		attack.transform.localScale = new Vector3 (4, 4, 1);
		attack.transform.position = firePoint.position;
		attack.transform.rotation = firePoint.rotation;
	}
}
