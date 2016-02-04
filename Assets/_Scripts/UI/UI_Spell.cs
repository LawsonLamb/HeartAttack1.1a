using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Spell : MonoBehaviour,IBeginDragHandler , IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler {
	public Sprite sprite;
	public GameObject spell;
	public int slot;
	private Vector2 offset;
//	private Spells spellList;
	//public Tooltip tooltip;
	public Transform orginalParent;
	// Use this for initialization
	void Start () {

	//spellList =	Spells.GetDataBase();
	orginalParent = this.transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnBeginDrag(PointerEventData eventData)
	{
		if(spell!=null){
			orginalParent = this.transform.parent;
			var canvas = FindInParents<Canvas>(gameObject);
			if (canvas == null)
				return;
			this.transform.SetParent(canvas.transform);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
	
	
	public void OnDrag(PointerEventData eventData)
	{
		if(spell!=null){
			
			this.transform.position = eventData.position-offset;
			
		}
		
		
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		// this.transform.SetParent(inv.slots[slot].transform);
		// this.transform.position = inv.slots[slot].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		
		if(spell!=null){
			offset = eventData.position - new Vector2(this.transform.position.x,this.transform.position.y);
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{    if(spell!=null){
			//tooltip.Activate(item);
		}
	}
	
	public void OnPointerExit(PointerEventData eventData)
	{
		//tooltip.Deactivate();
	}
	

	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();
		
		if (comp != null)
			return comp;
		
		var t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}
