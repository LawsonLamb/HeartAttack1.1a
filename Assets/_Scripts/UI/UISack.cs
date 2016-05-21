using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UISack : MonoBehaviour {
	public UISackItem coin;
	public UISackItem waterBallon;
	public UISackItem Key;
	public UISackItem HeartKey;
	ItemData itemData;
	//TODO: SAVE "SACK" TO FILE
	// Use this for initialization
	void Start () {
		itemData = GameObject.FindObjectOfType<ItemData> ();
		coin.m_Item = 	itemData.GetItemByID (7);
		waterBallon.m_Item = 	itemData.GetItemByID (8);
		Key.m_Item =  itemData.GetItemByID (0);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			coin.m_Item.Stock++;

		}

		coin.m_Item = 	itemData.GetItemByID (7);
		waterBallon.m_Item = 	itemData.GetItemByID (8);
		Key.m_Item =  itemData.GetItemByID (0);
	

	}
}
