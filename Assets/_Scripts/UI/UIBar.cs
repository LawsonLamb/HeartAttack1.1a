using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIBar : MonoBehaviour {
	
	public float BarAmount{
		get{return this.transform.GetChild(0).GetComponent<Image>().fillAmount;}
		set{ this.transform.GetChild(0).GetComponent<Image>().fillAmount= value;}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
