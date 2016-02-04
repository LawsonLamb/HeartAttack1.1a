using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UI_SpellSlot : MonoBehaviour,IDropHandler  {
	public int id;
	public GameObject Child;
	// Use this for initialization
	void Start () {
		if(transform.childCount==1){
			Child = transform.GetChild(0).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDrop(PointerEventData data)
	{
		if(transform.childCount>0){
			Transform op = data.pointerDrag.gameObject.GetComponent<UI_Spell>().orginalParent;
			data.pointerDrag.gameObject.transform.SetParent(op);
			data.pointerDrag.gameObject.transform.position = op.position;
			
			return;
		}
		
		
		GameObject droppedObject = data.pointerDrag.gameObject;
		if(droppedObject!=null){
			droppedObject.GetComponent<UI_Spell>().orginalParent = this.transform;
			droppedObject.transform.SetParent(this.transform);
			droppedObject.transform.position = this.transform.position;
			
			
			
		}

}
}