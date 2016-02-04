using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Bar : MonoBehaviour {
	public float BarAmount{
		get{return this.transform.GetChild(0).GetComponent<Image>().fillAmount;}
		set{ this.transform.GetChild(0).GetComponent<Image>().fillAmount= value;}
	}
	public string BarText{
		get{return this.transform.GetChild(1).GetComponent<Text>().text;}
		set{this.transform.GetChild(1).GetComponent<Text>().text= value;}
	}
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
