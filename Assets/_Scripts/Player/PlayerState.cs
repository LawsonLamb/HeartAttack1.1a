using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	private Leveling_System ls;
	public int PlayerLevel;
	public static int letters;



	void Start () {
		ls = gameObject.GetComponent<Leveling_System>();

		//ps = gameObject.GetComponent<Player_Stats>();
		//pc = gameObject.GetComponent<Player_Control>();

	}
	
	// Update is called once per frame
	void Update () {


	
	}

}
