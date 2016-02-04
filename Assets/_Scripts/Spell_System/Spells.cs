using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System;

[Serializable]
public class Spells : ScriptableObject {
	[SerializeField]
	private List<GameObject> spells;

	void OnEnable(){
		if(spells==null ){
		spells = new List<GameObject>();
		}
		
	}
	public void Add(GameObject spell){
		spells.Add(spell);
	}
	public void Remove(GameObject spell){
		spells.Remove (spell);
		
	}
	public void RemoveAt(int index){
		spells.RemoveAt (index);
	}
	
	public int COUNT{
		get { return spells.Count; }
		
	}
	public GameObject Spell(int index){
		return spells.ElementAt( index );
	}
	/*
	public Spells GetSpellByID(int id){
		
		for(int i =0; i<spells.Count;i++){
			if(spells[i].ID == id)
				return spells[i];
			
		}
		return null;
		}
		*/
	
	public static Spells GetDataBase(){
		return (Spells)Resources.Load<Spells> ("Spells");
	}


	


}
