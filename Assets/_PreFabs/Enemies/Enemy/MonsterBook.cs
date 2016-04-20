using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class MonsterBook : MonoBehaviour {

	private Sprite sprite;
	private SpriteRenderer render;

	public string name;
	[HideInInspector]
	public int age;
	[HideInInspector]
	public EnemyType type;
	[HideInInspector]
	public int rank;
	[HideInInspector]
	public int blood;
	[HideInInspector]
	public int love;
	[HideInInspector]
	public int expGiven;
	[HideInInspector]
	public int letters;
	[HideInInspector]
	/*public EnemySpell spell1;
	//[HideInInspector]
	//public EnemySpell spell2;
	[HideInInspector]*/
	public string description;
	[HideInInspector]
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
