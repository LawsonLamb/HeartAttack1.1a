using UnityEngine;
using System.Collections;
[System.Serializable]
public class Level {

	[SerializeField] public int xp;
	[SerializeField] public int Blood;
	[SerializeField] public int Love;
	[SerializeField] public int Strength;
	[SerializeField] public int Intelligence;
	[SerializeField] public int Dexterity;
	[SerializeField] public int Luck;

	public Level(){

	}

	public Level(int xp,int Blood,int Love,int Strength, int Intelligence,int Dexterity,int Luck){
		this.xp = xp;
		this.Blood = Blood;
		this.Love = Love;
		this.Strength = Strength;
		this.Intelligence = Intelligence;
		this.Dexterity = Dexterity;
		this.Luck = Luck;
	}

}
