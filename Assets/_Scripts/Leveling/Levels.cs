using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
[Serializable]
public class Levels: ScriptableObject {
	[SerializeField]
	private List<Level> lvls;
	void OnEnable(){
		if(lvls==null ){
			lvls = new List<Level>();
		}

	}
	public void Add(Level lvl){
		lvls.Add(lvl);
	}
	public void Remove(Level lvl){
		lvls.Remove (lvl);
		
	}
	public void RemoveAt(int index){
		lvls.RemoveAt (index);
	}
	
	public int COUNT{
		get { return lvls.Count; }
		
	}
	public Level Level(int index){
		return lvls.ElementAt( index );
	}
		
}
