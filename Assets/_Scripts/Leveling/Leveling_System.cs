using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Leveling_System : MonoBehaviour {
	private Levels levels;
	[HideInInspector]
	public Level currentLevel;
	[HideInInspector]
	public Level NextLevel;
	[HideInInspector]
	public int currentXp;
	[HideInInspector]
	public int nextLevelID;
	int maxLevel;
	public int currentLevelID;
	void OnEnable(){
		levels = (Levels)Resources.Load<Levels>("Levels");
		maxLevel = levels.COUNT;
		SetCurrentLevel();
		SetNext_Level();
	}
	void Start () {
	
	}
	
	void Update () {
	
	}
	void SetCurrentLevel(){
		currentLevel = levels.Level(currentLevelID);


	}
	void SetNext_Level(){
		nextLevelID =  currentLevelID+1;
		NextLevel = levels.Level(nextLevelID);

	}
	public void AddXP(int points){

		currentXp+=points;

	}
	public void Level_UP(){
		if(currentXp>NextLevel.xp){
			print("LevelUP");
			GetComponent<SoundEffects>().PlaySound (4);
			currentLevelID+=1;
			SetCurrentLevel();
			SetNext_Level();
		}

	}
	[ContextMenu("Addpoints")]
	public void Test_level(){
			AddXP(5);
			Level_UP();
	}
	[ContextMenu("Reset")]
	public void Reset(){
		currentLevelID =0;
		currentXp = 0;
		SetCurrentLevel();
		SetNext_Level();

	}




}
