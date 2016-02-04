using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
[Serializable]
public class ItemDataBase:ScriptableObject{
	[SerializeField]
	private List<Item> database;

	private List<Item> testDataBase = new List<Item>();



	void OnEnable(){
		if(database==null ){
			database = new List<Item>();
		}
		else {
			for(int i = 0;i<database.Count;i++){
				
				database[i].ID = i;
			}


		}


	}
	public void Add(Item item){
		database.Add(item);
	}
	public void Remove(Item item){
		database.Remove (item);

	}
	public void RemoveAt(int index){
		database.RemoveAt (index);
	}

	public int COUNT{
		get { return database.Count; }
	
	}
	public Item Item(int index){
		return database.ElementAt( index );
	}
	public static ItemDataBase GetDataBase(){
		return (ItemDataBase)Resources.Load<ItemDataBase> ("ItemDatBase");
	}
	public Item GetItemByID(int id){
		
		for(int i =0; i<database.Count;i++){
			if(database[i].ID == id)
				return database[i];
			
		}
		return null;
		
	}
	public Item GetItemByName(string name){

		for (int i =0; i < database.Count; i++) {
			if(database[i].name == name)
				return database[i];
		}
		return null;
	}

	/*
	public void Load_ItemsXML(string filepath){
		TextAsset _xml = Resources.Load<TextAsset>(filepath);
		XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
		StringReader reader  = new StringReader(_xml.text);
		//List<Item> itemList = serializer.Deserialize(reader) as List<Item>;
		reader.Close();
		//database = itemList;
	}
	public void Save_ItemXML(string filepath,List<Item> items){

		var serializer = new XmlSerializer (typeof(List<Item>));
		var stream = new FileStream (filepath, FileMode.Create);
		serializer.Serialize (stream, items);
		stream.Close ();

	}
	*/

	[ContextMenu("Save JSON")]
	public void Save_ItemsJSON(){

		FileStream stream=	new FileStream (Application.dataPath+"/Resources/ItemDatabase_JSON.json", FileMode.OpenOrCreate);
		string[] jsonData = new string[database.Count];
		StreamWriter sw = new StreamWriter(stream);
		for(int i =0;i<database.Count;i++){
			jsonData[i] = JsonUtility.ToJson(database[i]);
			sw.WriteLine(jsonData[i]);
			//Debug.Log(jsonData[i]);
		}
		sw.Close();
	}
	[ContextMenu("Load JSON")]
	public void Load_ItemsJSON(){
		TextAsset jsonFILE= Resources.Load<TextAsset>("ItemDatabase_JSON.json");
		FileStream stream=	new FileStream (Application.dataPath+"/Resources/ItemDatabase_JSON.json", FileMode.Open);
		StreamReader  sr= new StreamReader(stream);
		string line;
		while((line = sr.ReadLine()) != null){

			testDataBase.Add((Item)JsonUtility.FromJson<Item>(line));


		}
		sr.Close();
		foreach(Item i in testDataBase){

			Debug.Log(i.name);
		}
	}
}

