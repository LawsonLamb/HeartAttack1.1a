using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Gauntlet : MonoBehaviour {
    public int EnemyCount = 1;
	public GameObject Chamber;
    public Text text;
	// Use this for initialization
	void Start () {


		


	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = EnemyCount.ToString();
        if (EnemyCount == 0)
        {
           
            Application.LoadLevel(3);
        }
	}

	[ContextMenu("Enemy Count")]
	public void GetEnemyCount(){
		
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
