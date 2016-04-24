using UnityEngine;
using System.Collections;

public class Gauntlet : MonoBehaviour {
	public int EnemyCount;
	public GameObject Chamber;
	// Use this for initialization
	void Start () {


		


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("Enemy Count")]
	void GetEnemyCount(){
		
		ChamberGenerator cg = Chamber.GetComponent<ChamberGenerator> ();
		EnemyCount = 0;
		for (int i = 0; i<cg.rooms.Count; i++) {

			EnemyCount += cg.rooms [i].GetComponent<Room> ().EnemiesInRoom.Count;
		}


	}


	public void EnemyKilled(){

		EnemyCount -= 1;
	}
}
