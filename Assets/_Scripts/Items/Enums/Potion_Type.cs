using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
[System.Serializable]
public enum Potion_Type{
	[XmlEnum("")]
	None,
	[XmlEnum("Restoritive")]
	Restoritive,
	[XmlEnum("Increaser")]
	Increaser


}