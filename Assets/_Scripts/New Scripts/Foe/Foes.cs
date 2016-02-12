using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Foes {

	public GameObject foe;
	public string foeName;
	public int foeID;
	public float foeHealth;
	public float foeSpeed;
	public int foeDmg;
	public Sprite foeImage;
	public FoeType foeType1;
	public FoeType foeType2;

	public enum FoeType {

		Spliter,
		Enviornment,
		Physical,
		Shooter,
		Clinger,
		Runner,
		Summoner,
		Boss,
		Null,

	}

	public Foes () {
	}

	public Foes (string name, int id, float health, float speed, int dmg, FoeType type1, FoeType type2) {
		foeName = name;
		foeID = id;
		foeHealth = health;
		foeSpeed = speed;
		foeDmg = dmg;
		foeType1 = type1;
		foeType2 = type2;
	}

	void Start(){
		Init ();
	}

	void Init() {

		foe.AddComponent<Physical> ();
		if ((foeType1 == FoeType.Boss) || (foeType2 == FoeType.Boss)) {
			foe.AddComponent<Boss> ();
		}
		if ((foeType1 == FoeType.Clinger) || (foeType2 == FoeType.Clinger)) {
			foe.AddComponent<Clinger> ();
		}
		if ((foeType1 == FoeType.Enviornment) || (foeType2 == FoeType.Enviornment)) {
			foe.AddComponent<Area> ();
		}
		if ((foeType1 == FoeType.Runner) || (foeType2 == FoeType.Runner)) {
			foe.AddComponent<Runner> ();
		}
		if ((foeType1 == FoeType.Shooter) || (foeType2 == FoeType.Shooter)) {
			foe.AddComponent<Shooter> ();
		}
		if ((foeType1 == FoeType.Spliter) || (foeType2 == FoeType.Spliter)) {
			foe.AddComponent<Spliter> ();
		}
		if ((foeType1 == FoeType.Summoner) || (foeType2 == FoeType.Summoner)) {
			foe.AddComponent<Summoner> ();
		}
		if ((foeType1 == FoeType.Null) || (foeType2 == FoeType.Null)) {
		}
	}
}
