using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class UI_StatsPanel : MonoBehaviour {
	public List<GameObject> Panels;
	public string Strength_Text {

		get{return Panels[0].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[0].transform.GetChild(1).GetComponent<Text>().text = value;}

	}
	public  string Intelligence_Text{
		get{return Panels[1].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[1].transform.GetChild(1).GetComponent<Text>().text = value;}

	}
	public string Dexterity_Text{
		get{return Panels[2].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[2].transform.GetChild(1).GetComponent<Text>().text = value;}
	}

	public  string Luck_Text{
		get{return Panels[3].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[3].transform.GetChild(1).GetComponent<Text>().text = value;}
	}
	public string Blood_Text{
		get{return Panels[4].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[4].transform.GetChild(1).GetComponent<Text>().text = value;}
	}
	public   string Love_Text{
		get{return Panels[5].transform.GetChild(1).GetComponent<Text>().text;}
		set{ Panels[5].transform.GetChild(1).GetComponent<Text>().text = value;}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
