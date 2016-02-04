using UnityEngine;
using System.Collections;

using System.Xml.Serialization;
[System.Serializable]
public enum Item_Type{
	[XmlEnum("")]
	None,
	[XmlEnum("Potion")]
	Potion,
	[XmlEnum("Weapon")]
	Weapon,
	[XmlEnum("Armor")]
	Armor,
	[XmlEnum("Lock")]
	Lock


}
