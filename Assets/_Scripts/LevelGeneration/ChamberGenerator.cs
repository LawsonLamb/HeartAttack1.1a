using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ChamberGenerator : MonoBehaviour
{
    public GameObject RoomPrefab;

    public GameObject[,] Chamber;
    public List<GameObject> rooms;
	public int TotalEnemies;
    public float XOffset;
    public float yOffset;
    public int width;
    public int height;
    public int maximumNumberOfRooms = 12;
    public int minimumNumberOfRooms = 9;
   [SerializeField]
    public List<Vector2> roomPositions = new List<Vector2>();
    // Use this for initialization
    void Start()
    {
        RandomGEN();
        // int Start = (int)Random.Range(3.0f, 6.0f);
        //  int end = (int)Random.Range(1.0f, 5.0f);

        // width = Start;
        //  height = Start;
        // Chamber = new GameObject[width, height];

        //Generate();
        //ConnectRooms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*

    void Generate()
    {


        for (int x = 0; x < Chamber.GetLength(0); x++)
        {

            for (int y = 0; y < Chamber.GetLength(1); y++)
            {

                Chamber[x, y] = (GameObject)Instantiate(RoomPrefab, new Vector3(x * XOffset, y * yOffset, 0.0f), Quaternion.identity);
                Chamber[x, y].name = "Room" + x + "," + y;
                Chamber[x, y].transform.SetParent(this.transform);
                Chamber[x, y].GetComponent<Room>().type = RoomType.Base;
                if (x == 0 && y == 0)
                {
                    Chamber[x, y].GetComponent<Room>().type = RoomType.SPAWN;
                }

                else if (x == width - 1 && y == height - 1)
                {
                    Chamber[x, y].GetComponent<Room>().type = RoomType.BOSS;
                }

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

        if (y + 1 < Chamber.GetLength(1))
        {

            SetRegionType(Chamber[x, y], RegionType.Door, 0);



        }
        // check if y is less then zero or is = to make chamber height;
        else
        {
            // print("Create wall");
            SetRegionType(Chamber[x, y], RegionType.Wall, 0);
        }
    }

    void CheckSouth(int x, int y)
    {

        if (y - 1 >= 0)
        {
            SetRegionType(Chamber[x, y], RegionType.Door, 1);
        }

        else
        {
            //   print("Create wall");
            SetRegionType(Chamber[x, y], RegionType.Wall, 1);

        }


    }

    void CheckEast(int x, int y)
    {
        if (x + 1 < Chamber.GetLength(1))
        {
            SetRegionType(Chamber[x, y], RegionType.Door, 3);
            //  print("Create door");
        }

        else
        {
            SetRegionType(Chamber[x, y], RegionType.Wall, 3);
            //print("Create Wall");
        }
    }

    void CheckWest(int x, int y)
    {
        if (x - 1 >= 0)
        {
            SetRegionType(Chamber[x, y], RegionType.Door, 2);

            // print("createDoor");
        }

        else
        {
            SetRegionType(Chamber[x, y], RegionType.Wall, 2);
            //  print("create wall");
        }
    }
    */

    void SetRegionType(GameObject go, RegionType Type, int Area)
    {

        go.GetComponent<Room>().Regions[Area].type = Type;
    }

    [ContextMenu("Random GEN")]
    void RandomGEN()
    {
        int numberOfRooms = Random.Range(minimumNumberOfRooms, maximumNumberOfRooms + 1);
       // print(numberOfRooms);
        roomPositions.Add(Vector2.zero);
        int randomRoom;
        int i;
        short numberOfAdjacent = 4;
        bool selected = false;
        bool[] adjacents = { true, true, true, true };
        for (i = 0; i < numberOfRooms - 1; i++)
        {

            randomRoom = Random.Range(0, roomPositions.Count);
//            print(randomRoom);
            //Adjacent Check-------------------------------------------------------------------------------------------
            if (!roomPositions.Contains(roomPositions[randomRoom] + Vector2.up))
            {
                numberOfAdjacent--;
                adjacents[0] = false;
            }
            if (!roomPositions.Contains(roomPositions[randomRoom] - Vector2.up))
            {
                numberOfAdjacent--;
                adjacents[1] = false;
            }
            if (!roomPositions.Contains(roomPositions[randomRoom] + Vector2.left))
            {
                numberOfAdjacent--;
                adjacents[2] = false;
            }
            if (!roomPositions.Contains(roomPositions[randomRoom] - Vector2.left))
            {
                numberOfAdjacent--;
                adjacents[3] = false;
            }

            if (adjacents[0] && adjacents[1] && adjacents[2] && adjacents[3])
            {
                i--;
            }
            else {
                //Map Creation----------------------------------------------------------------------------------------
                while (!selected)
                {

                    int rand = Random.Range(0, 4);

                    if (!adjacents[rand])
                    {
                        selected = true;

                        if (rand == 0)
                        {
                            roomPositions.Add(roomPositions[randomRoom] + Vector2.up);
                        }
                        else if (rand == 1)
                        {
                            roomPositions.Add(roomPositions[randomRoom] - Vector2.up);

                        }
                        else if (rand == 2)
                        {
                            roomPositions.Add(roomPositions[randomRoom] + Vector2.left);

                        }
                        else if (rand == 3)
                        {
                            roomPositions.Add(roomPositions[randomRoom] - Vector2.left);

                        }
                    }
                }


                numberOfAdjacent = 4;
                adjacents[0] = true; adjacents[1] = true; adjacents[2] = true; adjacents[3] = true;
                selected = false;

            }





            /*
            int Start = Random.Range(0, 0);


            print((int)Start);
            //float end = Start;
         int end = Start;
            while (end == Start)
            {
                end = Random.Range(0, 9);
                print((int)end);
            }
            print("MAP");
            int[,] ID = new int[Start, end];
            */
            /*
            ID[0, 0] = 0;
            print(ID[0, 0]);
            for(int x =1;x < ID.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < ID.GetLength(1) - 1; y++)
                {   

                    ID[x, y] = 1;
                    print(ID[x, y]);
                }
            }
            ID[(int)Start-1, (int)end-1] = 2;

            print(ID[(int)Start-1, (int)end-1]);

        */



        }

        CreateRooms();
        ConstructRooms();

//	GameObject.FindGameObjectWithTag ("GameController").GetComponent<Gauntlet> ().GetEnemyCount ();


    }
    void ConstructRooms()
    {

        int i;
        int totalRooms = roomPositions.Count;
     
        for (i = 0; i < totalRooms; i++)
        {


            CheckNorth(i);
            CheckSouth(i);
            CheckEast(i);
            CheckWest(i);
         

        }
    }
    void CheckNorth(int i)
    {
        if (roomPositions.Contains(roomPositions[i] + Vector2.up))
            {


            SetRegionType(rooms[i], RegionType.Door, (int)Direction.North);
            
   
        }
      
        else
        {
            // print("Create wall");
            SetRegionType(rooms[i], RegionType.Wall, (int)Direction.North);
        }

    }

    void CheckSouth(int i)
    {
        if (roomPositions.Contains(roomPositions[i] - Vector2.up))
        {
            SetRegionType(rooms[i], RegionType.Door,1);
        }

        else
        {
            SetRegionType(rooms[i], RegionType.Wall, 1);
        }
    }

    void CheckEast(int i)
    {

        if (roomPositions.Contains(roomPositions[i] + Vector2.left))
        {
            SetRegionType(rooms[i], RegionType.Door, 2);
        }
        else {


            SetRegionType(rooms[i], RegionType.Wall, 2);
        }
    }

    void CheckWest(int i)
    {
        if (roomPositions.Contains(roomPositions[i] - Vector2.left))
        {
            SetRegionType(rooms[i], RegionType.Door, 3);
        }

        else
        {
            SetRegionType(rooms[i], RegionType.Wall, 3);
        }
    }

    void CreateRooms()
    {

        for (int i = 0; i < roomPositions.Count; i++)
        {
             rooms.Add((GameObject)Instantiate(RoomPrefab, new Vector3(roomPositions[i].x * XOffset, roomPositions[i].y * yOffset, 0.0f), Quaternion.identity));
            rooms[i].transform.SetParent(this.gameObject.transform);
			rooms[i].name = "Room " + i;

        }

    }

    public int getCount()
    {

        return roomPositions.Count;
    }
}
