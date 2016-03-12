using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoeDatabase : MonoBehaviour {

	public List<Foes> foe = new List<Foes>();
	// Use this for initialization
	void Start () {
		//foe.Add (new Foes(string name, int id, float health, float speed, int dmg, FoeType type1, FoeType type2, FoeType type3));

		foe.Add (new Foes ("Heart Burn", 0, 10f, 0.15f, 1, Foes.FoeType.Clinger, Foes.FoeType.Null));
		foe.Add (new Foes ("Colestrol", 1, 5f, 0.05f, 1, Foes.FoeType.Null, Foes.FoeType.Null));
		foe.Add (new Foes ("Grease Jar", 2, 15f, 0.05f, 1, Foes.FoeType.Shooter, Foes.FoeType.Null));

		foe.Add (new Foes ("Cigarette", 3, 15f, 0.10f, 1, Foes.FoeType.Enviornment, Foes.FoeType.Runner));
		foe.Add (new Foes ("Clot", 4, 10f, 0.05f, 1, Foes.FoeType.Enviornment, Foes.FoeType.Clinger));

		foe.Add (new Foes ("Cluster", 5, 10f, 0.10f, 1, Foes.FoeType.Spliter, Foes.FoeType.Clinger));
		foe.Add (new Foes ("Pack", 6, 20f, 0.15f, 2, Foes.FoeType.Spliter, Foes.FoeType.Clinger));
		foe.Add (new Foes ("Chilly Burger", 7, 20f, 0.15f, 2, Foes.FoeType.Spliter, Foes.FoeType.Enviornment));

		foe.Add (new Foes ("Saddness", 8, 20f, 0.20f, 2, Foes.FoeType.Boss, Foes.FoeType.Enviornment));
		foe.Add (new Foes ("Depression", 9, 400f, 0.20f, 2, Foes.FoeType.Boss, Foes.FoeType.Clinger));
		foe.Add (new Foes ("Low Selfestem", 10, 600f, 0.20f, 2, Foes.FoeType.Boss, Foes.FoeType.Summoner));
	
	}

	public void FindSprites() {

		for (int i = 0; i < foe.Count; i++) {
			if (foe[i].foeID == i) {
				foe[i].foeImage = Resources.Load <Sprite> ("Icons/Foes/Foe_" + i); 
			}
		}
	}

	public Foes GetFoeByID(int id){

		for(int i =0; i< foe.Count;i++){
			if(foe[i].foeID == id)
				return foe[i];

		}
		return null;

	}

	public Foes GetFoeByName(string name){

		for (int i =0; i < foe.Count; i++) {
			if(foe[i].foeName == name)
				return foe[i];
		}
		return null;
	}
}
