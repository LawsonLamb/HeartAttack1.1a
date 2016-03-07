using UnityEngine;
using System.Collections;
public class TileMap : MonoBehaviour {

	public GameObject TileAsset;
	public int mapWidth =15;
	public int mapHeight = 9;
	public GameObject[,] _map;
	int texWidth;
	int texHeight;
	// Use this for initialization
	void Start () {
		texWidth = TileAsset.GetComponent<Sprite>().texture.width;
		texWidth = TileAsset.GetComponent<Sprite>().texture.height;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[ContextMenu("Load")]
	void Load(){
		_map = new GameObject[mapWidth,mapHeight];
		for(int x=0;x<mapWidth;x++){
			for(int y=0; y<mapHeight;y++){
				_map[x,y]= Instantiate(TileAsset,new Vector3(x*texWidth,y*texHeight,0.0f),Quaternion.identity)  as GameObject;
				_map[x,y].transform.SetParent(this.transform);
			

		}
	}
	}
}
