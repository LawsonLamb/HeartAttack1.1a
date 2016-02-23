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
		Hazard,
		Obstical,
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

	public void CreateGameObject() {
	
		obj = new GameObject ();
		obj.name = objName;
		obj.AddComponent<SpriteRenderer> ().sprite = objImage;
		obj.AddComponent<Rigidbody2D> ();
		obj.AddComponent<Collider2D> ();
		obj.tag = "Foes";
		if (envType == EnvType.Door) {
			obj.AddComponent<Doors> ();
		} else if (envType == EnvType.Hazard) {
			obj.AddComponent<Hazards> ();
		} else if (envType == EnvType.NPC) {
			obj.AddComponent<NPCs> ();
			obj.AddComponent<GenRandom> ();
			obj.GetComponent<Collider2D> ().isTrigger = true;
		} else {
			obj.AddComponent<Obsticals> ();
			obj.AddComponent<GenRandom> ();
		}
	}
}
