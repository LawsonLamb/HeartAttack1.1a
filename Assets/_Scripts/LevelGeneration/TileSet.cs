using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class TileSet :ScriptableObject {
   public List<Sprite> Floors;
    public  List<Sprite> Walls;
   public List<Sprite> Doors;

    void OnEnable()
    {
        if ( Floors== null)
        {
            Floors= new List<Sprite>();
        }

        if(Walls == null)
        {

            Walls= new List<Sprite>();
        }

        if (Doors == null)
        {

            Doors = new List<Sprite>();
        }

    }
        // Update is called once per frame
        void Update () {
	
	}

    
}
