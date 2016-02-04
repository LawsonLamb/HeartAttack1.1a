using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelText : MonoBehaviour {

	void OnEnable(){
		GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<Leveling_System>().currentLevelID.ToString();


	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Text>().text = GameObject.FindGameObjectWithTag("Player").GetComponent<Leveling_System>().currentLevelID.ToString();
	}
}
