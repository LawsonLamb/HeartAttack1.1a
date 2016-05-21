using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UISackItem : MonoBehaviour {
	
	public Item m_Item;
	// Use this for initialization
	void Start () {
		m_Item = null;
	//	m_Item.ID = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (m_Item!=null){

			m_Text = string.Format("{0:x00#}", m_Item.Stock);
			m_Icon = m_Item.Icon;
		}
	}



	public string m_Text{ get{return this.transform.GetComponentInChildren<Text> ().text; } set { this.transform.GetComponentInChildren<Text> ().text = value; } }
	public Sprite m_Icon{ get { return this.transform.GetComponentInChildren<Image> ().overrideSprite; } set {  this.transform.GetComponentInChildren<Image> ().overrideSprite = value; } }

}
