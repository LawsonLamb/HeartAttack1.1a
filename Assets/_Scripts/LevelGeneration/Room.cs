using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum RoomType
{
    Empty,
    Base,
    SPAWN,
    BOSS,

}
[System.Serializable]
public class Room : MonoBehaviour {

   public RoomType type;
   public List<Region> Regions;
    GameObject regionsGO;
	public List<GameObject> Enemies;
	public int minimumNumberOfEnemies =0;
	public int maximumNumberOfEnemies =0;
	public List<GameObject> EnemiesInRoom;

	void Start () {
		
	//	Enemies = new List<GameObject> ();
		EnemiesInRoom = new List<GameObject> ();
        findRegions();
		setupRoom ();
	}

	void Update () {

	}




    [ContextMenu("Find Regions")]
    void findRegions()
    {
        regionsGO = this.transform.FindChild("Regions").gameObject;
       
       Regions = new List<Region>();

        for( int i=0; i < transform.childCount; i++)
        {

           Regions.Add(regionsGO.transform.GetChild(i).GetComponent<Region>());

        }

       
     
    }


    public void setupRoom()
    {
		int numberOfEnemies = Random.Range (minimumNumberOfEnemies, maximumNumberOfEnemies);
		int e = 0;
		for (int i = 0; i < numberOfEnemies; i++) {

			e = Random.Range (0, Enemies.Count);
			GameObject go = Enemies [e];
			EnemiesInRoom.Add((GameObject)Instantiate (go, new Vector3 (0.0f, 0.0f, 0.0f), Quaternion.identity));
			EnemiesInRoom [i].transform.SetParent (this.transform);
			EnemiesInRoom [i].transform.localPosition = new Vector2 (Random.Range(4,24),Random.Range(4,13));

		}

    }



}
