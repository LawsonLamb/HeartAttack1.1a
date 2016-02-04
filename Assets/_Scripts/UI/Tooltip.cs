using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {
private Item item;
private string data;

 	public GameObject tooltip;


	void Start(){
		//tooltip = GameObject.Find("Tooltip");
		tooltip.SetActive(false);
		
	}
	void Update(){
		if(tooltip.activeSelf){
			tooltip.transform.position = Input.mousePosition;
			
		}
		
	}
	public void Activate(Item item){
		
		this.item = item;
		ConstrcutDataString();
		tooltip.SetActive(true);
	}
	
	public void Deactivate(){
		
		tooltip.SetActive(false);
	}
	public void ConstrcutDataString(){
	
		data = item.name;
		
		//data = "<color=#0473f0><b>"+ item.Title +"</color>\n\n"+ item.Description+"\nPower:"+ item.Power;
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
		//tooltip.GetComponent<Text>().text = data;
	}
}
