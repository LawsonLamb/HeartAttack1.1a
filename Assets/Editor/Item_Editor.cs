using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.IO;


[System.Serializable]
public class Item_Editor : EditorWindow {


	private int _index = 0;
	private Vector2 scrollPosition = Vector2.zero;

	private ItemDataBase _items;

	
	void OnEnable(){

		_index= 0;
		if(_items==null){
			LoadDataBase ();
		}
		else{
		
		}
	}


  

	void LoadDataBase(){
		_items = (ItemDataBase)AssetDatabase.LoadAssetAtPath<ItemDataBase> ("Assets/Resources/ItemDataBase.asset");
		
	
		if(_items==null)
			CreateDataBase();

	}
	void CreateDataBase(){
		_items = ScriptableObject.CreateInstance<ItemDataBase>();
		AssetDatabase.CreateAsset (_items, "Assets/Resources/ItemDataBase.asset");
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
	
	}


	[MenuItem ("DataEditor/Item Editor Window")]
	public static void  ShowWindow () {

		EditorWindow.GetWindow(typeof(Item_Editor));
		
	
	}
	
	


	void OnGUI () {

		GUILayout.Label ("Item DataBase", EditorStyles.boldLabel);

		EditorGUILayout.BeginVertical();

		TOP_BUTTONS ();
		EditorGUILayout.BeginHorizontal ();
		if(_items.COUNT>0){
			Scroll_Area ();
			Value_Window ();
		}
		EditorGUILayout.EndHorizontal ();

		EditorGUILayout.EndVertical ();


	}


    
	void ItemTable_Body(){

		EditorGUILayout.BeginVertical();

		for (int k = 0; k < _items.COUNT; k++) {
			if(_items.Item(k)!=null){
			EditorGUILayout.BeginHorizontal();

				if(GUILayout.Button(_items.Item(k).Name,"Box",GUILayout.ExpandWidth(true))){
			
				_index = k;
					EditorUtility.SetDirty(_items);
				

			}

			if(GUILayout.Button("-",GUILayout.Width(15.0f))){
				//	AssetDatabase.DeleteAsset("Assets/Resources/Items/"+_items.Item(k).Name.ToString()+".asset");
					_items.RemoveAt(k);
					EditorUtility.SetDirty(_items);

				}
			EditorGUILayout.EndHorizontal();
			}
		}

		EditorGUILayout.EndVertical();	

	
	}
    

	void OnSelectionChange(){


	}

    
	void Value_Window(){

		try {
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.BeginVertical ("Box",GUILayout.Width(300));

	 
	
		_items.Item(_index).Type = (Item.ItemType)EditorGUILayout.EnumPopup("Type:" , _items.Item(_index).Type);
		_items.Item(_index).Name= EditorGUILayout.TextField("Name",_items.Item(_index).Name);
		_items.Item(_index).Icon= (Sprite)EditorGUILayout.ObjectField ("Sprite",_items.Item(_index).Icon, typeof(Sprite), false);




		EditorGUILayout.EndVertical ();	
		EditorGUILayout.BeginVertical("Box");
		_items.Item(_index).Price= 	(int)EditorGUILayout.IntField("Price",_items.Item(_index).Price);
		_items.Item(_index).Stock= (int)EditorGUILayout.IntField("Stock",_items.Item(_index).Stock);
		_items.Item(_index).Duration =(float)EditorGUILayout.FloatField("Duration",_items.Item(_index).Duration);
		EditorGUILayout.EndVertical();
		EditorGUILayout.EndHorizontal ();
		}

			catch (System.ArgumentOutOfRangeException ex){
				Debug.Log(ex.ToString());
			}
		catch(System.NullReferenceException ex){
			Debug.Log(ex.ToString());
			//this.Close();
		}

	}

    
	void TOP_BUTTONS(){
		EditorGUILayout.BeginHorizontal ("box",GUILayout.Width(50));
		/*
		if (GUILayout.Button ("Load XML ")) {
			_items.Load_ItemsXML ("Item_Data");
			
		}
		*/

		/*
		if (GUILayout.Button ("Save XML")) {

		}
		*/
		/*
		if(GUILayout.Button("CreateDataBase File")){
		//	CreatePotionDataBase();
			CreateDataBase ();
		}
		*/


		if (GUILayout.Button ("Load DataBase")) {
			LoadDataBase ();

		}
		/*
		if(GUILayout.Button ("Save DataBase")){
			AssetDatabase.SaveAssets();

		}
	*/
		if(GUILayout.Button("New Item")){

            _items.Add(new Item());

		}
		/*
		if (GUILayout.Button ("Load GameObjects")) {
			Create_GameObjects ();
		}

		*/
		if (GUILayout.Button ("Create prefabs")) {
			Create_Prefabs();

		}

		if (GUILayout.Button ("Load Selected GameObject")) {
			Create_Selected_GameObject ();
		

		}	

		EditorGUILayout.EndHorizontal();
	}
	void Scroll_Area(){

		EditorGUILayout.BeginVertical (GUILayout.Width(250));

		scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.ExpandHeight(true)); 
		if(_items.COUNT>0){
		ItemTable_Body();
		}
		GUILayout.EndScrollView();
		EditorGUILayout.EndVertical ();


	}

	void Create_Prefabs(){

		for (int i = 0; i < _items.COUNT; i++){

			//GameObject go = new GameObject (_items.Item (i).name+" Game Object");
			//go.gameObject.AddComponent<Item_View> ().item = _items.Item (i);


			//Object prefab =PrefabUtility.CreateEmptyPrefab("Assets/_PreFabs/Items/"+_items.Item (i).name+".prefab");
			//PrefabUtility.ReplacePrefab(go.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
		}

	}
	void Create_GameObjects(){

		for (int i = 0; i < _items.COUNT; i++) {
		//	GameObject go = new GameObject (_items.Item(i).name + " Game Object");
			//go.gameObject.AddComponent<Item_View> ().item = _items.Item(i);

		}
	

	}

	void Create_Selected_GameObject(){
		//GameObject go = new GameObject (_items.Item(_index).name + "-Object");
		//go.gameObject.AddComponent<Item_View> ().item =_items.Item(_index);


	}

	void OnInspectorUpdate(){
		Repaint ();
	}
	
	
}
