using UnityEngine;
using System.Collections;
using UnityEditor;

public class Editor_Menus: EditorWindow {
	
	[MenuItem("Assets/Create/ItemDataBase")]
	public static void  CreateItemDataBase(){
		ItemDataBase _items = ScriptableObject.CreateInstance<ItemDataBase>();
		AssetDatabase.CreateAsset (_items, "Assets/Resources/ItemDataBase.asset");
		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();


	}
    [MenuItem("Assets/Create/TileSet")]
    public static void CreateTileSet()
    {
        TileSet _set = ScriptableObject.CreateInstance<TileSet>();
        AssetDatabase.CreateAsset(_set, "Assets/Resources/TileSet.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }




}
