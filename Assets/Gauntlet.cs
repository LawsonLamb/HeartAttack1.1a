using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Gauntlet : MonoBehaviour {
    public int EnemyCount = 0;
	public GameObject Chamber;
    public Text text;
	GameObject[] Foes;
	// Use this for initialization
	void Start () {


		


	
	}
	
	// Update is called once per frame
	void Update () {
		GetEnemyCount ();
        text.text = EnemyCount.ToString();

        if (EnemyCount == 0)
        {
			Application.LoadLevel(2);
        }
	}

	[ContextMenu("Enemy Count")]
	public void GetEnemyCount(){
		
		Foes = GameObject.FindGameObjectsWithTag ("Foe");
		EnemyCount = Foes.Length;
	}



	public void EnemyKilled(){
		
		EnemyCount--;
	}


}
