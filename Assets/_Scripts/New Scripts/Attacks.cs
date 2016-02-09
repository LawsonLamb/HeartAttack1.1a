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
}
