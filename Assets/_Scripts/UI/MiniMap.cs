using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class MiniMap : MonoBehaviour
{

    public GameObject chamber;
    //  public GameObject ChamberObject;
    public GameObject RoomPrefab;
    public List<GameObject> rooms;
    public Vector2 offset;

    // Use this for initialization
    void Start()
    {
        rooms = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
		
		if (rooms.Count == 0 && gameObject.activeSelf) {
			SetRooms ();
		} else {
			GetCurrentRoom ();
		}

    }

    public void OnEnable()
    {
        
        rooms = new List<GameObject>();
        SetRooms();
    }
    

    void SetRooms()
    {
       
        for (int i = 0; i < chamber.GetComponent<ChamberGenerator>().getCount(); i++)
        {
        
            rooms.Add((GameObject)Instantiate(RoomPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity));
         
            rooms[i].transform.SetParent(this.transform);
            Vector2 pos = chamber.GetComponent<ChamberGenerator>().roomPositions[i];

            rooms[i].GetComponent<RectTransform>().localPosition = new Vector2(pos.x * offset.x, pos.y * offset.y);

        }

    }

    [ContextMenu("Shift Rooms")]
    void ShiftRooms()
    {
        Vector2 pos = new Vector2(0.0f, 0.0f);

        for (int i = 0; i < rooms.Count; i++)
        {
            RectTransform rect = rooms[i].GetComponent<RectTransform>();

            if (rect.localPosition.x <= -120.0f)
            {
                print(" Greater then -");
                // shift right;
                pos.x = rooms[i - 1].GetComponent<RectTransform>().localPosition.x;
                rect.localPosition = pos;
            }

            if (rect.localPosition.x >= 120.0f)
            {
                // shift right;
                //pos.x = rooms[i + 1].GetComponent<RectTransform>().localPosition.x;
                //  rect.localPosition = pos;
            }





        }


    }



	void GetCurrentRoom(){

		for (int i = 0; i < chamber.GetComponent<ChamberGenerator> ().getCount (); i++) {
			if (chamber.GetComponent<ChamberGenerator> ().rooms [i].GetComponent<Room> ().PlayerInRoom) {

				rooms [i].GetComponent<Image> ().color = Color.red;

			} else {

				rooms [i].GetComponent<Image> ().color = Color.white;

			}


		}


	}





}
