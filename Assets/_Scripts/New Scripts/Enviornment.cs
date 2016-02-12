using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Enviornment {

	public GameObject obj;
	public string objName;
	public int objID;
	public int objPlayerDmg;
	public float objEnemyDmg;
	public bool passable;
	public float timer;
	public Sprite objImage;
	public EnvType envType;

	public enum EnvType {

		Door,
		SecretPassage,
		Hazard,
		Obsticals,
		NPC,

	}

	public Enviornment () {
	}

	public Enviornment (string name, int id, int dmgToPlayer, float dmgToEnemy, bool pass, float time, EnvType type) {
		objName = name;
		objID = id;
		objPlayerDmg = dmgToPlayer;
		objEnemyDmg = dmgToEnemy;
		passable = pass;
		timer = time;
		envType = type;
	}
}
