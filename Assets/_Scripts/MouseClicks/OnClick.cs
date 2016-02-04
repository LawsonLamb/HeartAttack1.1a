using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClick : MonoBehaviour {

	public static bool loading;
	public static bool saving;

	LoadingScreen loadScene;
	// Use this for initialization
	void Start () {
	
		loadScene = GameObject.FindGameObjectWithTag ("Loading Scene").GetComponent<LoadingScreen> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Return_ToStart () {
		loadScene.LoadLevel (0);
	}

	public void Load_GameFromStart (){
		loadScene.LoadLevel (1);
	}

	public void Load_GameFromFile () {
		loadScene.LoadLevel (1);
	}

	public void Delete_GameFile () {
		
	}

	public void Load_MyHeartsScene (){
	
		//Current scene would be Title
		if (Application.loadedLevel == 0) {
			loading = true;
		} else {
			saving = true;
		}
		loadScene.LoadLevel (4);

	}

	public void Load_HeartConditionScene () {
		loadScene.LoadLevel (3);
	}

	public void Load_HeartShopSecene () {
		loadScene.LoadLevel (2);
	}

	public void Load_MonsterBook () {
		loadScene.LoadLevel (6);
	}
	
	public void Load_LevelChoiceScene () {

		if (Application.loadedLevel == 2) { //Current Scene would be Heart Shop
			loadScene.LoadLevel (1);
		} else if (Application.loadedLevel == 3) { //Current Scene would be Hearts Condition
			loadScene.LoadLevel (1);
		}  else if (Application.loadedLevel == 5) { //Current Scene would be Levels
			loadScene.LoadLevel (1);
		} else if (Application.loadedLevel == 6) { //Current Scene would be Monster Book
			loadScene.LoadLevel (1);
		}

	}

	public void Exit_MyHeartScene () {

		if (saving) {
			saving = false;
			loadScene.LoadLevel (1);
		}
		
		if (loading) {
			loading = false;
			loadScene.LoadLevel (0);
		}

	}

	public void Restart_GameLevel () {
			loadScene.LoadLevel (5);
	}



}