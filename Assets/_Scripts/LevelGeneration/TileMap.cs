using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TileMap : MonoBehaviour {

	public GameObject TileAsset;
    Transform Floor;
    Transform Wall;
    public TileSet tileSet;
	public int mapWidth =15;
	public int mapHeight = 9;
	[SerializeField]
	public GameObject[,] _map;
	public float texWidth;
	public  float texHeight;
	int halfWidth;
	int halfHeight;
	// Use this for initialization
	void Start () {
     Floor =  this.transform.FindChild("Floor");
		Load();
		setWall ();
		FillFloor ();
		FillWalls();
 
      
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	#region Build Map
	[ContextMenu("Load")]
	void Load(){
		
		 halfWidth = GetRegion (mapWidth);
		 halfHeight = GetRegion (mapHeight);
	
        DestoryChildren();
        CreateGameObject("Walls");
        CreateGameObject("Floor");
		//Floor =  this.transform.FindChild("Floor");
	
        
        _map = new GameObject[mapWidth,mapHeight];
		for(int x=0;x<mapWidth;x++){
			for(int y=0; y<mapHeight;y++){
				_map[x,y]= Instantiate(TileAsset,new Vector3(x*texWidth,y*texHeight,0.0f),Quaternion.identity)  as GameObject;
                _map[x, y].name = "Tile" + x + "," + y;
                _map[x,y].transform.SetParent(this.transform);
				


			

		}
	}
		//FillWalls ();
	}
    [ContextMenu("Fill Floor")]
    void FillFloor()
    {
        Floor = this.transform.FindChild("Floor");
        for (int row =2;row< mapWidth- 2; row++)
        {

            for(int col =2; col<mapHeight - 2; col++)
            {
               // print(row + ","+ col);
                _map[row, col].GetComponent<SpriteRenderer>().sprite = tileSet.Floors[1];
                _map[row, col].transform.SetParent(Floor);
            }



        }

    }
    [ContextMenu("Fill Wall")]
    void FillWalls()
    { 
        
        setSprite(_map[0, 0], tileSet.Walls[0], false, true);
        setSprite(_map[1, 0], tileSet.Walls[1], false, true);
        setSprite(_map[0, 1], tileSet.Walls[6], false, true);
		setSprite(_map[1, 1], tileSet.Walls[7], false, true);

        for (int row = 2; row < mapWidth - 2; row++)
		{	for(int col =0; col < 2; col++){

				if(row == halfWidth-1 || row== halfWidth || row == halfWidth+1)
				{
					//Doors.Add(_map[row, col]);
				}

				else{
					if(col ==0){

					
						setSprite(_map[row, col], tileSet.Walls[2], false, true);
					
					}

					else if(col==1){


						setSprite(_map[row, col], tileSet.Walls[8], false, true);
					}
				}

			}
          
        }
			
		setSprite(_map[0, mapHeight-1], tileSet.Walls[0], false, false);
		setSprite(_map[1, mapHeight-1], tileSet.Walls[1], false, false);
		setSprite(_map[0, mapHeight-2], tileSet.Walls[6], false, false);
		setSprite(_map[1, mapHeight-2], tileSet.Walls[7], false, false);

        for (int row = 2; row < mapWidth - 2; row++)
		{
			for(int col =mapHeight-2; col <= mapHeight; col++){
				if(row == halfWidth-1 || row== halfWidth || row == halfWidth+1)
				{

				//	Doors.Add(_map[row, col]);

				}
				else{
					if(col == mapHeight-2){
						setSprite(_map[row, col], tileSet.Walls[8], true, false);
					}

					else if(col ==mapHeight-1){

						setSprite(_map[row, col], tileSet.Walls[2], false, false);
					}

				}



			}
          
        }

	


        setSprite(_map[mapWidth-2, 0], tileSet.Walls[1], true, true);
        setSprite(_map[mapWidth-1, 0], tileSet.Walls[0], true, true);
		setSprite(_map[mapWidth-1, 1], tileSet.Walls[6], true, true);
		setSprite(_map[mapWidth-2, 1], tileSet.Walls[7], true, true);

        for (int col = 2; col < mapHeight-2; col++){ 
			for(int row =0; row<2;row++){

				if(col == halfHeight-1 || col ==halfHeight || col ==halfHeight+1){
								//Doors.Add(_map[row, col]);
								
				
				}
				else{
				if(row ==0){

						setSprite(_map[row, col], tileSet.Walls[5], false, false);
					}
					else if(row ==1){
						setSprite(_map[row, col], tileSet.Walls[9], false, false);

								}
							}
					}
         
        }






		setSprite(_map[mapWidth-2, mapHeight-1], tileSet.Walls[1], true, false);
		setSprite(_map[mapWidth-1, mapHeight-1], tileSet.Walls[0], true, false);
		setSprite(_map[mapWidth-1, mapHeight-2], tileSet.Walls[6], true, false);
		setSprite(_map[mapWidth-2, mapHeight-2], tileSet.Walls[7], true, false);


        for (int col = 2; col < mapHeight - 2; col++)
		{	

			for(int row =mapWidth-2; row<mapWidth;row++){

				if(col == halfHeight-1 || col ==halfHeight || col ==halfHeight+1){
					//Doors.Add(_map[row, col]);
				}

				else{
					if(row ==mapWidth-1){
						setSprite(_map[row, col], tileSet.Walls[5], true, false);
					}

					else{
					setSprite(_map[row, col], tileSet.Walls[9], true, true);

					}

				}
			}
			
          
        }

	


    }



    #endregion
    [ContextMenu("set Wall")]
    void setWall()
	{ 
        Wall = transform.FindChild("Walls");
        for (int row = 0; row < mapWidth ; row++)
        {
            for (int col = 0; col < 2; col++)
            {
				
				if (row == halfWidth-1 || row== halfWidth || row == halfWidth+1)
                {

                }

                else {

                    _map[row, col].transform.SetParent(Wall);

                }

            }

        }


        for (int row = 0; row < mapWidth ; row++)
        {
            for (int col = 7; col < 9; col++)
            {
				if (row == halfWidth-1 || row== halfWidth || row == halfWidth+1)
				{

				}
                else
                {
                    _map[row, col].transform.SetParent(Wall);
                }

            }
        }


        for (int col = 0; col < mapHeight ; col++)
        {

            for (int row = 0; row < 2; row++)
            {

                if (col == 3 || col == 4 || col == 5)
                {
					
                }

                else
                {
                    _map[row, col].transform.SetParent(Wall);
                }

            }
        }



        for (int col = 0; col < mapHeight ; col++)
        {

            for (int row = 13; row < mapWidth; row++)
            {
                if (col == 3 || col == 4 || col == 5)
                {
					
                }

                else
                {
                    _map[row, col].transform.SetParent(Wall);
                }
            }
        }

    }
    [ContextMenu("Destory")]
    void DestoryChildren()
    {

        while (this.transform.childCount > 0)
        {
            DestroyImmediate(this.transform.GetChild(0).gameObject);

        }
    }



    void setSprite(GameObject go,Sprite WallSprite,bool flipx,bool flipy)
    {
        go.GetComponent<SpriteRenderer>().sprite = WallSprite;
        go.GetComponent<SpriteRenderer>().flipX = flipx;
        go.GetComponent<SpriteRenderer>().flipY = flipy;
    }


    void CreateGameObject(string Name)
    {
        GameObject go = new GameObject();
        go.name = Name;
        go.transform.SetParent(this.transform);

    }

	int GetRegion(int Size){

		return Size / 2;
	}


}
