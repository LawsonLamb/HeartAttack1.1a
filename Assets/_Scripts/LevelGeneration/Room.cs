using UnityEngine;
using System.Collections;
using System.Collections.Generic;
class Group{

	public List<Sprite> Top;
	public List<Sprite> Bottom;
	public List<Sprite> left;
	public List<Sprite> right;

	Group(){
		
	}



}

public class Room : MonoBehaviour {

	//public List<Transform> EmptyTiles;

	Transform replace;



	public List<Sprite> DoorTop;

	public List<Sprite> DoorBottom;

	public List<Sprite> DoorLeft;

	public List<Sprite> DoorRight;

	public List<Sprite> Walltop;

	public List<Sprite> WallBottom;

	public List<Sprite> WallLeft;

	public List<Sprite> WallRight;

	//[HideInInspector]
	public List<Transform> TopTiles;
	//HideInInspector]
	public List<Transform> LeftTiles;
	//[HideInInspector]
	public List<Transform> RightTiles;
	//[HideInInspector]
	public List<Transform> BottomTiles;

	// Use this for initialization
	[ContextMenu("Start")]
	void Start () {

		FindTiles();
		ReplaceTiles();



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	[ContextMenu("Find Tiles")]
	void FindTiles(){

		replace = transform.FindChild("Replace");
		TopTiles.Clear();
		LeftTiles.Clear();
		RightTiles.Clear();
		BottomTiles.Clear();

		TopTiles.Add(replace.FindChild("Tile_8_8"));
		TopTiles.Add(replace.FindChild("Tile_7_8"));
		TopTiles.Add(replace.FindChild("Tile_6_8"));
		TopTiles.Add(replace.FindChild("Tile_6_7"));
		TopTiles.Add(replace.FindChild("Tile_8_7"));


		LeftTiles.Add(replace.FindChild("Tile_13_5"));
		LeftTiles.Add(replace.FindChild("Tile_14_5"));
		LeftTiles.Add(replace.FindChild("Tile_14_4"));
		LeftTiles.Add(replace.FindChild("Tile_14_3"));
		LeftTiles.Add(replace.FindChild("Tile_13_3"));


		RightTiles.Add(replace.FindChild("Tile_0_3"));
		RightTiles.Add(replace.FindChild("Tile_1_3"));
		RightTiles.Add(replace.FindChild("Tile_0_4"));
		RightTiles.Add(replace.FindChild("Tile_0_5"));
		RightTiles.Add(replace.FindChild("Tile_1_5"));



		BottomTiles.Add(replace.FindChild("Tile_8_1"));
		BottomTiles.Add(replace.FindChild("Tile_8_0"));
		BottomTiles.Add(replace.FindChild("Tile_7_0"));
		BottomTiles.Add(replace.FindChild("Tile_6_0"));
		BottomTiles.Add(replace.FindChild("Tile_6_1"));
	}

	void ReplaceTiles(){

		for(int i =0;i<5;i++){

			TopTiles[i].GetComponent<SpriteRenderer>().sprite = DoorTop[i];
			LeftTiles[i].GetComponent<SpriteRenderer>().sprite = DoorLeft[i];
			RightTiles[i].GetComponent<SpriteRenderer>().sprite = DoorRight[i];
			BottomTiles[i].GetComponent<SpriteRenderer>().sprite = DoorBottom[i];

		}


	}



		}
