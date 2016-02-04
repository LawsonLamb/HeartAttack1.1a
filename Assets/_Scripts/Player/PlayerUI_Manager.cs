using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class PlayerUI_Manager : MonoBehaviour {
	[SerializeField]
	public GameObject InventoryPanel;
	public GameObject StatusPanel;
	public GameObject SkillPanel;
	public GameObject PausePanel;
	public KeyCode PauseKey;
	public KeyCode InventoryKey;
	public KeyCode statKey;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_input();
	}


	void _input(){

		if(Input.GetKeyDown(InventoryKey)){
			InventoryPanel.GetComponent<Panel>().Toggle();

		}
		if(Input.GetKeyDown(statKey)){
			StatusPanel.GetComponent<Panel>().Toggle();

		}
		if(Input.GetKeyDown(PauseKey)){
			PausePanel.GetComponent<Panel>().Toggle();

		}

	}

	 bool toggle(bool value){
		value =!value;
		return value;
	}
}
