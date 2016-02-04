using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
[ExecuteInEditMode]
public class Loot : MonoBehaviour {
	[SerializeField]
	public int Letters;
	[SerializeField]
	//public List<Item> DropableItems;
	public List<GameObject> DropableItems;
	// Use this for initialization
	void Start () {
		
	}
	void OnEnable(){
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public  void DropLoot(){
		PlayerState.letters+=Letters;
		int ran = 	Random.Range(0,DropableItems.Count);
		Instantiate(DropableItems[ran],transform.position,Quaternion.identity);
	}
	void OnDestroy(){
	

	}


}
