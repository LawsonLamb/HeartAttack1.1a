using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class EnemyData{

	[SerializeField] public int ID;
	[SerializeField] public string name;
	[SerializeField] public Sprite Sprite;
	[SerializeField] public int Age;
//	[SerializeField] public Level CurrentLevel;
	[SerializeField] public int maxHealth;
	[SerializeField] public int damage;
	[SerializeField] public EnemyType Type;
	[SerializeField] public GameObject DamageEffect;
	[SerializeField] public GameObject RangeSpell;


}
