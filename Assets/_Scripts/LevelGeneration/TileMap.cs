using UnityEngine;
using System.Collections;
public class TileMap : MonoBehaviour {

	public GameObject TileAsset;
    public TileSet tileSet;
	public int mapWidth =15;
	public int mapHeight = 9;
	public GameObject[,] _map;
	public float texWidth;
	public  float texHeight;
	// Use this for initialization
	void Start () {
        Load();
        FillWalls();
       // texWidth = TileAsset.GetComponent<SpriteRenderer>().sprite.rect.width;
		//texHeight = TileAsset.GetComponent<SpriteRenderer>().sprite.rect.height;
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
                _map[x, y].name = "Tile" + x + "," + y;
                _map[x,y].transform.SetParent(this.transform);
			

		}
	}
  
	}
    [ContextMenu("Fill Floor")]
    void FillFloor()
    {
        for(int row =2;row< mapWidth- 2; row++)
        {

            for(int col =2; col<mapHeight - 2; col++)
            {
               // print(row + ","+ col);
                _map[row, col].GetComponent<SpriteRenderer>().sprite = tileSet.Floors[1];
            }



        }

    }
    [ContextMenu("Fill Wall")]
    void FillWalls()
    { /*
        for(int row = 0; row < 2;row++)
        {
            for(int col = 0; col < mapHeight; col++)
            {
                 print(row + ","+ col);
                _map[row, col].GetComponent<SpriteRenderer>().sprite = tileSet.Floors[1];
            }
        }
        */
        
        setWall(_map[0, 0], tileSet.Walls[0],false,true);
        setWall(_map[1, 0], tileSet.Walls[1], false, true);
        setWall(_map[0, 1], tileSet.Walls[6], false, true);
        for (int row = 2; row < mapWidth - 2; row++)
        {
            setWall(_map[row, 0], tileSet.Walls[2], false, true);
        }



        setWall(_map[0, 8], tileSet.Walls[0], false, false);
        setWall(_map[1, 8], tileSet.Walls[1], false, false);

        for (int row = 2; row < mapWidth - 2; row++)
        {
            setWall(_map[row, 8], tileSet.Walls[2], false, false);
        }

        setWall(_map[13, 0], tileSet.Walls[1], true, true);
        setWall(_map[14, 0], tileSet.Walls[0], true, true);
        for (int col = 2; col < mapHeight-2; col++)
        {
            setWall(_map[0, col], tileSet.Walls[5], false, false);
        }


        setWall(_map[13, 8], tileSet.Walls[1], true, false);
        setWall(_map[14, 8], tileSet.Walls[0], true, false);

        for (int col = 2; col < mapHeight - 2; col++)
        {
            setWall(_map[14, col], tileSet.Walls[5], true, false);
        }



    }

    void setWall(GameObject go,Sprite WallSprite,bool flipx,bool flipy)
    {
        go.GetComponent<SpriteRenderer>().sprite = WallSprite;
        go.GetComponent<SpriteRenderer>().flipX = flipx;
        go.GetComponent<SpriteRenderer>().flipY = flipy;
    }


}
