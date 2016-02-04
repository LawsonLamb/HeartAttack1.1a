using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
[Serializable]
[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Item_View : MonoBehaviour {


	private CircleCollider2D _collider;

	public ItemDataBase db;
	[SerializeField]
	public Item item;
	[HideInInspector]
	public  int itemID;
	/*
	public Item_View(Item item){

	}
	*/


	void OnEnable(){
		Get_Data();

	}
	void Start () {
		Get_Data();
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().sprite = item.sprite;
	}

	void Get_Data(){
		gameObject.tag = "Item";
		GetComponent<SpriteRenderer>().sprite = item.sprite;
		_collider =GetComponent<CircleCollider2D> ();
		_collider.isTrigger = true;


	}

	public void ChangeData(int ID){
		itemID = ID;
		item = db.Item (itemID);
	}
}
