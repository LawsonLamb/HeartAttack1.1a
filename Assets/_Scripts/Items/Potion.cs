using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Potion:Item{

	public Potion_Type _type; 
	public Potion():base(){
	
	}
	public Potion(string Name):base(Name){
		this.name = Name;

	}

}
