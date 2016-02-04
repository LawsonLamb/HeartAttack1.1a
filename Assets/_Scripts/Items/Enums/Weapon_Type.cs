using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
[System.Serializable]
public enum Weapon_Type{
	[XmlEnum("")]
	None,
	[XmlEnum("Physical")]
	Physical,
	[XmlEnum("Magical")]
	Magical,
}

