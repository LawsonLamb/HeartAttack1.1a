using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnviornmentDatabase : MonoBehaviour {

	public List<Enviornment> enviornment = new List<Enviornment>();
	// Use this for initialization
	void Start () {
		//enviornment.Add (new Enviornment (string name, int id, int dmgToPlayer, float dmgToEnemy, bool pass, float time, EnvType type));
	
		enviornment.Add (new Enviornment ("Room Door", 0, 0, 0, true, 0, Enviornment.EnvType.Door));
		enviornment.Add (new Enviornment ("Treasure Room Door", 1, 0, 0, false, 0, Enviornment.EnvType.Door));
		enviornment.Add (new Enviornment ("Shop Room Door", 2, 0, 0, false, 0, Enviornment.EnvType.Door));
		enviornment.Add (new Enviornment ("Heart Room Door", 3, 0, 0, false, 0, Enviornment.EnvType.Door));

		enviornment.Add (new Enviornment ("Secret Passage", 4, 0, 0, false, 0, Enviornment.EnvType.SecretPassage));

		enviornment.Add (new Enviornment ("Acid", 5, 5, 5, true, 0, Enviornment.EnvType.Hazard));
		enviornment.Add (new Enviornment ("Arrows", 6, 5, 5, true, 5f, Enviornment.EnvType.Hazard));

		enviornment.Add (new Enviornment ("Grave Stone", 7, 0, 0, false, 0, Enviornment.EnvType.Obsticals));
		enviornment.Add (new Enviornment ("Dirt Clog", 8, 0, 0, false, 0, Enviornment.EnvType.Obsticals));
		enviornment.Add (new Enviornment ("Grease Patch", 9, 5, 5, true, 0, Enviornment.EnvType.Obsticals));

		enviornment.Add (new Enviornment ("Save Guy", 10, 0, 0, true, 0, Enviornment.EnvType.NPC));
		enviornment.Add (new Enviornment ("Satus Guy", 11, 0, 0, true, 0, Enviornment.EnvType.NPC));
		enviornment.Add (new Enviornment ("Love Booth", 12, 0, 0, true, 0, Enviornment.EnvType.NPC));

	}
	
	public Enviornment GetEnviornmentByName(string name){

		for (int i =0; i < enviornment.Count; i++) {
			if(enviornment[i].objName == name)
				return enviornment[i];
		}
		return null;
	}
}
