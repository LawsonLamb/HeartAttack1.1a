using UnityEngine;
using System.Collections;
// trying to fix

public enum RegionType
{
    Door,
    Wall,
    Empty,
}


public class Region : MonoBehaviour {

    public RegionType type;
    public Direction direction;
    public Transform[,] tiles;
    GameObject _doorGO;
    GameObject Wall;
    Doors door;
    public float portalAmount = 8.0f;
    public Vector3 doorPos;
    bool[] flip;
    TileSet tileset;
    // Use this for initialization
    void Start() {
        flip = new bool[2];
        //tiles = new Transform[3, 2];
        tileset = TileSet.GetTileSet();
        //_doorGO = this.transform.FindChild("Doors").gameObject;
        //Wall = this.transform.FindChild("Wall").gameObject;

        SetType();
       
       

    }

    // Update is called once per frame
    void Update() {

    }

    void SetType()
    {

        if (gameObject.name.Equals("North"))
        {
            direction = Direction.North;
            flip[0] = false;
            flip[1] = true;
            tiles = new Transform[3, 2];
            setTiles();
         //   SetDoors(flip);
            SetWall(false,false);
           
        }

        else if (gameObject.name.Equals("South"))
        {
            direction = Direction.South;
            flip[0] = false;
            flip[1] = false;
            tiles = new Transform[3, 2];
            setTiles();
          //  SetDoors(flip);
            SetWall(true,true);
        }

        else if (gameObject.name.Equals("East"))
        {
            flip[0] = true;
            flip[1] = true;
            direction = Direction.East;
            tiles = new Transform[3, 2];
            setTiles();
             setRegionEW(flip);
           // setWallEW(true, true);
        }

        else if (gameObject.name.Equals("West"))
        {
            tiles = new Transform[3, 2];
            flip[0] = false;
            flip[1] = true;
            direction = Direction.West;
               setTiles();
           // setWallEW(false, false);
            setRegionEW(flip);
        }



    }


  void SetRegion()
    {
        switch (direction)
        {
            case Direction.North:

                break;

            case Direction.South:

                break;

            case Direction.East:

                break;
            case Direction.West:

                break;

        }
    }


    void setDoor()
    {
        switch (type)
        {
            case RegionType.Door:
                Wall.SetActive(false);
                _doorGO.SetActive(true);
                door = _doorGO.GetComponentInChildren<Doors>();
                doorPos = door.transform.position;
                SetDoorPortal();
                break;

            case RegionType.Wall:
                Wall.SetActive(true);
                _doorGO.SetActive(false);
                break;

            case RegionType.Empty:
                Wall.SetActive(false);
                _doorGO.SetActive(false);
                break;


        }

    }



    void SetDoorPortal()
    {

        switch (direction)
        {

            case Direction.North:

                door.postion.x = door.transform.position.x;

                door.postion.y = (portalAmount + door.transform.position.y);



                break;


            case Direction.South:
                door.postion.x = door.transform.position.x;

                door.postion.y = (door.transform.position.y - portalAmount);

                break;

            case Direction.East:
                door.postion.x = door.transform.position.x + portalAmount;

                door.postion.y = door.transform.position.y;
                break;



            case Direction.West:
                door.postion.x = door.transform.position.x - portalAmount;

                door.postion.y = door.transform.position.y;
                break;




        }

    }


    void setTiles()
    {
        //  print(gameObject.name);
        for (int row = 0; row < tiles.GetLength(0); row++)
        {

            for (int col = 0; col < tiles.GetLength(1); col++)
            { int temp = col % tiles.GetLength(0) + row * tiles.GetLength(1);
             //   print(row + " ," +  col + ":" + temp);

                tiles[row, col] = transform.GetChild(temp);
              //   print(tiles[row, col].name);

            }
        }
    }

    void SetDoors(bool[] flip)
    {
        int i = 0;
        int j = 3;


        if (!flip[0] && !flip[1])
        {
            i = 3;
            j = 0;
        }

        else if (!flip[0] && flip[1])
        {
            i = 0;
            j = 3;
        }

        else if (flip[0] && !flip[1])
        {
            i = 9;
            j = 6;
        }


        for (int row = 0; row < tiles.GetLength(0); row++)
        {

            for (int col = 0; col < tiles.GetLength(1); col++)
            {
                if (col == 0)
                {

                    setSprite(tiles[row, col], tileset.Doors[j], flip[0], flip[1]);
                    j++;
                }
                else if (col == 1)
                {

                    setSprite(tiles[row, col], tileset.Doors[i], flip[0], flip[1]);

                    i++;
                }

            }

        }

        //setSprite(tiles[0, 0], tileset.Doors[3], flip[0], flip[1]);
        //setSprite(tiles[1, 0], tileset.Doors[4], flip[0], flip[1]);
        //setSprite(tiles[2, 0], tileset.Doors[5], flip[0], flip[1]);

        // setSprite(tiles[0, 1], tileset.Doors[0], flip[0], flip[1]);
        // setSprite(tiles[1, 1], tileset.Doors[1], flip[0], flip[1]);
        // setSprite(tiles[2, 1], tileset.Doors[2], flip[0], flip[1]);



    }

    void setRegionEW(bool[] flip)
    {

       int i = 9;
       int j = 6;
		string layer = "default";
		bool foreGround = true;
        if (flip[0] && flip[1])
        {
			foreGround = false;
            i = 6;
            j = 9;
        }
     

        for (int row = 0; row < tiles.GetLength(0); row++)
        {

            for (int col = 0; col < tiles.GetLength(1); col++)
            {
                if (col == 0)
                {
					if (row == 1) {
						tiles [row, col].GetComponent<Tile> ().isTrigger = true;
					}

					if (foreGround) {
						tiles [row, col].GetComponent<SpriteRenderer> ().sortingLayerName = "Foreground";
					}
                    setSprite(tiles[row, col], tileset.Doors[j], flip[0], flip[1]);
                    j++;
                }
                else if (col == 1)
                {
					if (row == 1) {
						tiles [row, col].GetComponent<Tile> ().isTrigger = true;
					}
					if (!foreGround) {
						tiles [row, col].GetComponent<SpriteRenderer> ().sortingLayerName = "Foreground";
					}
                    setSprite(tiles[row, col], tileset.Doors[i], flip[0], flip[1]);

                    i++;
                }

            }

        }

    }

    void SetWall(bool flipx, bool flipy)
    {
        int i = 8;
        int j = 2;
        if( flipx && flipy)
        {
            i = 2;
            j = 8;
        }
       
        for (int row = 0; row < tiles.GetLength(0); row++)
        {

            for (int col = 0; col < tiles.GetLength(1); col++)
            {
                if(col ==0)
                setSprite(tiles[row, col], tileset.Walls[i], flipx, flipy);
                else if(col == 1)
                {
                  setSprite(tiles[row, col], tileset.Walls[j], flipx, flipy);

                }
            }


        }

    }


    void setWallEW(bool flipX, bool flipY)
    {
        int i = 5;
        int j = 9;
        if (flipX && flipY)
        {
            i = 9;
            j = 5;
        }

        for (int row = 0; row < tiles.GetLength(0); row++)
        {

            for (int col = 0; col < tiles.GetLength(1); col++)
            {
                if (col == 0)
                    setSprite(tiles[row, col], tileset.Walls[i], flipX, flipY);
                else if (col == 1)
                {
                    setSprite(tiles[row, col], tileset.Walls[j], flipX, flipY);

                }
            }


        }

    }

    
    void setSprite(Transform go, Sprite WallSprite, bool flipx, bool flipy)
    {
        go.gameObject.GetComponent<SpriteRenderer>().sprite = WallSprite;
        go.gameObject.GetComponent<SpriteRenderer>().flipX = flipx;
        go.gameObject.GetComponent<SpriteRenderer>().flipY = flipy;
    }



}
