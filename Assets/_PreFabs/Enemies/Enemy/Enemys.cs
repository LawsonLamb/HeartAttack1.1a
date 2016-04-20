using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
[Serializable]
public class Enemys :ScriptableObject{
	[SerializeField]
	private List<EnemyData> database;
	void OnEnable(){
		if(database==null){
			database = new List<EnemyData>();
		}
	}

	public void Add(EnemyData enemy){
		database.Add(enemy);
	}
	public void Remove(EnemyData enemy){
		database.Remove (enemy);
		
	}
	public void RemoveAt(int index){
		database.RemoveAt (index);
	}
	
	public int COUNT{
		get { return database.Count; }
		
	}
	public EnemyData Enemy (int index){
		return database.ElementAt( index );
	}
}
