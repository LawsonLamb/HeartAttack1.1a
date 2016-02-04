using UnityEngine;
using System.Collections;

[System.Serializable]
public class Effect {
	public Effect_Type e_type;
	public float amount;
	public Effect(){
		this.amount = 0.0f;
		this.e_type = Effect_Type.none;
	}
	public Effect(Effect_Type e_type,float amount){
		this.amount = amount;
		this.e_type = e_type;
	}
	
}
