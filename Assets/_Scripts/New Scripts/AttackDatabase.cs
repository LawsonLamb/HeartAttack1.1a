using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackDatabase : MonoBehaviour {

	public List<Attacks> attacks = new List<Attacks>();

	// Use this for initialization
	void Start () {
		//attacks.Add (new Attacks(string name, int id, int fireAmount, float speed, int manaCost, AttackType type));

		//The default regular skill the player can use
		attacks.Add (new Attacks ("Reg Att 0_1", 0, 1, 5, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_2", 1, 1, 5, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_3", 2, 2, 6, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_4", 3, 2, 6, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 0_5", 4, 3, 7, 3, Attacks.AttackType.Regular));

		//The default special skill the player can use
		attacks.Add (new Attacks ("Spec Att 0_1", 5, 2, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_2", 6, 2, 6, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_3", 7, 4, 7, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_4", 8, 4, 7, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 0_5", 9, 6, 8, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Reg Att 1_1", 10, 2, 8, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_2", 11, 3, 8, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_3", 12, 3, 9, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_4", 13, 3, 9, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 1_5", 14, 3, 10, 3, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Spec Att 1_1", 15, 4, 9, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_2", 16, 4, 9, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_3", 17, 4, 10, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_4", 18, 4, 10, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 1_5", 19, 4, 11, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Reg Att 2_1", 20, 3, 10, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_2", 21, 3, 11, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_3", 22, 3, 12, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_4", 23, 3, 13, 3, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Reg Att 2_5", 24, 3, 14, 3, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Spec Att 2_1", 25, 6, 11, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_2", 26, 6, 12, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_3", 27, 6, 13, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_4", 28, 6, 14, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Spec Att 2_5", 29, 6, 15, 0, Attacks.AttackType.Special));

		FindSprites ();
	}

	public void FindSprites() {

		for (int i = 0; i < attacks.Count; i++) {
			if (attacks[i].attID == i) {
				attacks[i].attIcon = Resources.Load <Sprite> ("Icons/Attacks/Att_" + i); 
			}
		}
	}

	public Attacks GetAttByName(string name){

		for (int i =0; i < attacks.Count; i++) {
			if(attacks[i].attName == name)
				return attacks[i];
		}
		return null;
	}
}
