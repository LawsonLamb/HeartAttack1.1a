using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackDatabase : MonoBehaviour {

	public List<Attacks> attacks = new List<Attacks>();

	// Use this for initialization
	void Start () {
		//attacks.Add (new Attacks(name, id, shoots fired, speed, cost, type));

		//The default regular skill the player can use
		attacks.Add (new Attacks ("Reg Att 0_1", 0, 1, 1, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_2", 1, 1, 2, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_3", 2, 2, 3, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_4", 3, 2, 4, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_5", 4, 3, 5, 3, Attacks.AttackType.Regular));

		//The default special skill the player can use
		attacks.Add (new Attacks ("Spec Att 0_1", 5, 2, 2, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_2", 6, 2, 3, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_3", 7, 4, 4, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_4", 8, 4, 5, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_5", 9, 6, 6, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Reg Att 1_1", 10, 2, 4, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_2", 11, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_3", 12, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_4", 13, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_5", 14, 3, 5, 3, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Spec Att 1_1", 15, 4, 5, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_2", 16, 4, 5, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_3", 17, 4, 5, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_4", 18, 4, 5, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_5", 19, 4, 5, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Reg Att 2_1", 20, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_2", 21, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_3", 22, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_4", 23, 3, 5, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_5", 24, 3, 5, 3, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Spec Att 2_1", 25, 6, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_2", 26, 6, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_3", 27, 6, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_4", 28, 6, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_5", 29, 6, 6, 0, Attacks.AttackType.Special));
	}

	public Attacks GetAttByName(string name){

		for (int i =0; i < attacks.Count; i++) {
			if(attacks[i].attName == name)
				return attacks[i];
		}
		return null;
	}
}
