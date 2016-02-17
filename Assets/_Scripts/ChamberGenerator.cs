using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChamberGenerator : MonoBehaviour {
	public GameObject RoomPrefab;

	public GameObject [,] Chamber;

	public float XOffset;
	public float yOffset;
	// Use this for initialization
	void Start () {
		Chamber = new GameObject[3,3];
		Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Generate(){
		print("Generate");
		for(int x=0;x<Chamber.GetLength(0);x++){

			for(int y=0;y<Chamber.GetLength(1);y++){

				Instantiate(RoomPrefab,new Vector3(x*XOffset,y*yOffset,0.0f),Quaternion.identity);

			}

		}

	}

}
