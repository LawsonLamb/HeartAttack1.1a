using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RoomType
{
    Empty,
    Base,
    Start,
    End,

}

public class Room : MonoBehaviour {
    public RoomType type;
//    public List<Region> Regions;
    GameObject regionsGO;
	void Start () {
        findRegions();
	}

	void Update () {

	}



    [ContextMenu("Find Regions")]
    void findRegions()
    {
        regionsGO = this.transform.FindChild("Regions").gameObject;
       
       // Regions = new List<Region>();

        for( int i=0; i <= transform.childCount; i++)
        {

           // Regions.Add(regionsGO.transform.GetChild(i).GetComponent<Region>());
        }

       
     
    }


    public void setupRoom()
    {

        
    }



}
