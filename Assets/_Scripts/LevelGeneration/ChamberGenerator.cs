using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChamberGenerator : MonoBehaviour {
	/*public GameObject RoomPrefab;

	public GameObject [,] Chamber;

	public float XOffset;
	public float yOffset;
    public int width;
    public int height;
	// Use this for initialization
	void Start () {
		Chamber = new GameObject [width,height];
		Generate();
        ConnectRooms();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Generate(){

		
		for(int x=0;x<Chamber.GetLength(0);x++){

			for(int y=0;y<Chamber.GetLength(1);y++){

				Chamber[x,y] = (GameObject)Instantiate(RoomPrefab,new Vector3(x*XOffset,y*yOffset,0.0f),Quaternion.identity);
                Chamber[x, y].name = "Room" + x + "," + y;
                Chamber[x, y].transform.SetParent(this.transform);

            }

		}

	}


    void ConnectRooms()
    {
        for (int x = 0; x < Chamber.GetLength(0); x++)
        {

            for (int y = 0; y < Chamber.GetLength(1); y++)
            {

                CheckNorth(x, y);
                CheckSouth(x, y);
                CheckEast(x, y);
                CheckWest(x, y);

            }


        }

    }


    void CheckNorth(int x, int y)
    {
        
        if (y+1 < Chamber.GetLength(1)) {

            SetRegionType(Chamber[x, y], RegionType.Door, 0);
         

            
        }
            // check if y is less then zero or is = to make chamber height;
        else
        {
            print("Create wall");
            SetRegionType(Chamber[x, y], RegionType.Wall, 0);
        }
    }

    void CheckSouth(int x,int y)
    {

        if(y-1 >= 0) {
            SetRegionType(Chamber[x, y], RegionType.Door, 1);
        }

        else
        {
            print("Create wall");
            SetRegionType(Chamber[x, y], RegionType.Wall, 1);

        }


    }

    void CheckEast(int x,int y)
    {
        if(x+1< Chamber.GetLength(1))
        {
            SetRegionType(Chamber[x, y], RegionType.Door, 3);
            print("Create door");
        }

        else
        {
            SetRegionType(Chamber[x, y], RegionType.Wall, 3);
            print("Create Wall");
        }
    }

    void CheckWest(int x, int y)
    {
        if (x - 1 >= 0)
        {
            SetRegionType(Chamber[x, y], RegionType.Door, 2);
           
            print("createDoor");
        }

        else
        {
            SetRegionType(Chamber[x, y], RegionType.Wall, 2);
            print("create wall");
        }
    }



    void SetRegionType(GameObject go, RegionType Type, int Area)
    {

        go.GetComponent<Room>().Regions[Area].type = Type;
    }



*/
}
