using UnityEngine;
using System.Collections;

public class GenRandom : MonoBehaviour {

	GameObject database;
	ItemData itemData;

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		itemData = database.GetComponent<ItemData> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			CreateRandomItem ();
		}
	}

	void CreateRandomItem () {

		for (int i = 0; i < 3; i++) {
			int j = itemData.item[Random.Range(0,23)].itemID;
			itemData.item[j].item = new GameObject ();
			itemData.item [j].item.name = itemData.item [j].itemName;
			itemData.item [j].item.AddComponent<SpriteRenderer> ().sprite = itemData.item [j].itemIcon;
			itemData.item [j].item.AddComponent<PickedItem> ();
			itemData.item [j].item.AddComponent<BoxCollider2D> ();
			itemData.item [j].item.AddComponent<Rigidbody2D> ();
			itemData.item [j].item.transform.localScale = new Vector3 (5, 5, 1);
			itemData.item [j].item.transform.localPosition = new Vector3 (Random.Range(0,8), Random.Range(0,8), 0);
		}
	}
}
