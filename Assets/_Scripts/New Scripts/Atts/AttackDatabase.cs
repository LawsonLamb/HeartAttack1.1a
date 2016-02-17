using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackDatabase : MonoBehaviour {

	public List<Attacks> attacks = new List<Attacks>();

	// Use this for initialization
	void Start () {
		//attacks.Add (new Attacks(string name, int id, int fireAmount, float speed, int manaCost, AttackType type));

		//The default regular skill the player can use
		attacks.Add (new Attacks ("Regular Shot_1", 0, 1, 5, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Regular Shot_2", 1, 1, 5, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Regular Shot_3", 2, 2, 6, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Regular Shot_4", 3, 2, 6, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Regular Shot_5", 4, 3, 7, 2, Attacks.AttackType.Regular));

		//The default special skill the player can use
		attacks.Add (new Attacks ("Enrage_1", 5, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Enrage_2", 6, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Enrage_3", 7, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Enrage_4", 8, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Enrage_5", 9, 1, 0, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Double Shot_1", 10, 2, 8, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Double Shot_2", 11, 3, 8, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Double Shot_3", 12, 3, 9, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Double Shot_4", 13, 3, 9, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Double Shot_5", 14, 3, 10, 2, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Restore_1", 15, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Restore_2", 16, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Restore_3", 17, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Restore_4", 18, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Restore_5", 19, 1, 0, 0, Attacks.AttackType.Special));

		//The 1/2 regular skills the player can find
		attacks.Add (new Attacks ("Barrage_1", 20, 3, 10, 1, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Barrage_2", 21, 3, 11, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Barrage_3", 22, 3, 12, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Barrage_4", 23, 3, 13, 2, Attacks.AttackType.Regular));
		attacks.Add (new Attacks ("Barrage_5", 24, 3, 14, 2, Attacks.AttackType.Regular));

		//The 1/2 special skills the player can find
		attacks.Add (new Attacks ("Cupid_1", 25, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Cupid_2", 26, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Cupid_3", 27, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Cupid_4", 28, 1, 0, 0, Attacks.AttackType.Special));
		attacks.Add (new Attacks ("Cupid_5", 29, 1, 0, 0, Attacks.AttackType.Special));

		//Finds the sprites for each of the Attacks
		FindSprites ();
	}

	public void FindSprites() {

		//Searches throught the folders for the att_(att ID) for each attack.
		for (int i = 0; i < attacks.Count; i++) {
			if (attacks[i].attID == i) {
				attacks[i].attIcon = Resources.Load <Sprite> ("Icons/Attacks/Att_" + i); 
			}
		}
	}

	public Attacks GetAttByName(string name){

		//goes through the attacks and finds the one coresponding to the name given.
		for (int i =0; i < attacks.Count; i++) {
			if(attacks[i].attName == name)
				return attacks[i];
		}
		return null;
	}
}
