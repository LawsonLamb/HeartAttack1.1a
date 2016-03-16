﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TileMap : MonoBehaviour {

	public GameObject TileAsset;
    public TileSet tileSet;
	public int mapWidth =15;
	public int mapHeight = 9;
	[SerializeField]
	public GameObject[,] _map;
	public float texWidth;
	public  float texHeight;

	// Use this for initialization
	void Start () {

		Load();
		FillWalls();
 
      
    }
	
	// Update is called once per frame
	void Update () {
	
	}


	#region Build Map
	[ContextMenu("Load")]
	void Load(){
		_map = new GameObject[mapWidth,mapHeight];
		for(int x=0;x<mapWidth;x++){
			for(int y=0; y<mapHeight;y++){
				_map[x,y]= Instantiate(TileAsset,new Vector3(x*texWidth,y*texHeight,0.0f),Quaternion.identity)  as GameObject;
                _map[x, y].name = "Tile" + x + "," + y;
                _map[x,y].transform.SetParent(this.transform);
				bool FlipX;
				bool FlipY;
				if(x<=2 && y<=2){
					FlipX =false;
					FlipY = true;
				}


			

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
        
        setSprite(_map[0, 0], tileSet.Walls[0],false,true);
        setSprite(_map[1, 0], tileSet.Walls[1], false, true);
        setSprite(_map[0, 1], tileSet.Walls[6], false, true);
		setSprite(_map[1,1],tileSet.Walls[7],false,true);


        for (int row = 2; row < mapWidth - 2; row++)
		{	for(int col =0; col < 2; col++){

				if(row == 6|| row == 7 || row == 8)
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





        setSprite(_map[0, 8], tileSet.Walls[0], false, false);
        setSprite(_map[1, 8], tileSet.Walls[1], false, false);
		setSprite(_map[0, 7], tileSet.Walls[6], false, false);
		setSprite(_map[1,7],tileSet.Walls[7],false,false);

        for (int row = 2; row < mapWidth - 2; row++)
		{
			for(int col =7; col < 9; col++){
				if(row == 6|| row == 7 || row == 8)
				{

				//	Doors.Add(_map[row, col]);

				}

				else{
					if(col ==7){
						setSprite(_map[row, 7], tileSet.Walls[8], true, false);
					}

					else if(col ==8){

						setSprite(_map[row, 8], tileSet.Walls[2], false, false);
					}

				}



			}
          
        }

	


        setSprite(_map[13, 0], tileSet.Walls[1], true, true);
        setSprite(_map[14, 0], tileSet.Walls[0], true, true);
		setSprite(_map[14, 1], tileSet.Walls[6], true, true);
		setSprite(_map[13,1],tileSet.Walls[7],true,true);

        for (int col = 2; col < mapHeight-2; col++){ 

							for(int row =0; row<2;row++){

								if(col == 3 || col ==4 || col ==5){
								//Doors.Add(_map[row, col]);
								}
								else{
								if(row ==0){

									setSprite(_map[0, col], tileSet.Walls[5], false, false);
								}
								else if(row ==1){
									setSprite(_map[1, col], tileSet.Walls[9], false, false);

								}
							}
							}
         
        }


		



        setSprite(_map[13, 8], tileSet.Walls[1], true, false);
        setSprite(_map[14, 8], tileSet.Walls[0], true, false);
		setSprite(_map[14, 7], tileSet.Walls[6], true, false);
		setSprite(_map[13,7],tileSet.Walls[7],true,false);

        for (int col = 2; col < mapHeight - 2; col++)
		{	

			for(int row =13; row<mapWidth;row++){

				if(col == 3 || col ==4 || col ==5){
					//Doors.Add(_map[row, col]);
				}

				else{
					if(row ==14){
						setSprite(_map[14, col], tileSet.Walls[5], true, false);
					}

					else{
						setSprite(_map[13, col], tileSet.Walls[9], true, true);

					}

				}
			}
			
          
        }

	


    }

	[ContextMenu("Fill Door")]
	void FillDoors(){

		fill_top();




	}
	void fill_top(){
		setSprite(_map[6,8],tileSet.Doors[0],false,false);
		setSprite(_map[7,8],tileSet.Doors[1],false,false);
		setSprite(_map[8,8],tileSet.Doors[2],false,false);

	}


	#endregion





    void setSprite(GameObject go,Sprite WallSprite,bool flipx,bool flipy)
    {
        go.GetComponent<SpriteRenderer>().sprite = WallSprite;
        go.GetComponent<SpriteRenderer>().flipX = flipx;
        go.GetComponent<SpriteRenderer>().flipY = flipy;
    }


}