using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[System.Serializable]
public class TileSet : ScriptableObject {
    [SerializeField] public List<Sprite> Floors;
    [SerializeField] public  List<Sprite> Walls;
    [SerializeField] public List<Sprite> Doors;
  
    public static TileSet GetTileSet()
    {

        return (TileSet)Resources.Load<TileSet>("TileSet");
    }
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
      

    
}
