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
    GameObject _doorGO;
    GameObject Wall;
    Doors door;
    public float portalAmount = 8.0f;
    public Vector3 doorPos;
	// Use this for initialization
	void Start () {
        _doorGO = this.transform.FindChild("Doors").gameObject;

        Wall = this.transform.FindChild("Wall").gameObject;
       SetType();
  
     
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void SetType()
    {
        if (gameObject.name.Equals("North"))
        {
            direction = Direction.North;
        }

        else if (gameObject.name.Equals("South"))
        {
            direction = Direction.South;
        }

        else if (gameObject.name.Equals("East"))
        {
            direction = Direction.East;
        }

        else if (gameObject.name.Equals("West"))
        {
            direction = Direction.West;
        }
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
                door.postion.x = door.transform.position.x -portalAmount;

                door.postion.y = door.transform.position.y;
                break;




        }
        
    }
    
}
