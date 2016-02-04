using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Player : MonoBehaviour {

	public GameObject Healthbar;
	public GameObject PowerBar;
	public GameObject StatPanel;
	public GameObject BloodEffect;
	float timer;
	public int Current_Blood;
	private int max_Blood{get{return ls.currentLevel.Blood;}}
	public int Current_Love;
	int max_Love {get{return ls.currentLevel.Love;}}
	int Current_XP;
	UI_Bar health;
	UI_Bar power;
	UI_StatsPanel UI_Stats;
	Leveling_System ls;
	// Use this for initialization
	void Start () {

		UI_Stats = StatPanel.GetComponent<UI_StatsPanel>();

		health = Healthbar.GetComponent<UI_Bar>();
		power = PowerBar.GetComponent<UI_Bar>();
		ls = gameObject.GetComponent<Leveling_System>();
		//max_Blood = ls.currentLevel.Blood;
//		max_Love  = ls.currentLevel.Love;
		health.BarText = max_Blood.ToString();
		power.BarText = max_Love.ToString();
		Current_Blood = ls.currentLevel.Blood;
		Current_Love = ls.currentLevel.Love;
		

		UI_Stats.Blood_Text = ls.currentLevel.Blood.ToString();
		UI_Stats.Love_Text = ls.currentLevel.Love.ToString();
		UI_Stats.Dexterity_Text = ls.currentLevel.Dexterity.ToString();
		UI_Stats.Intelligence_Text = ls.currentLevel.Intelligence.ToString();
		UI_Stats.Luck_Text = ls.currentLevel.Luck.ToString();

	

	
	}

	// Update is called once per frame
	void Update () {

		if(Current_Blood<=0){
			SceneManager.LoadScene(7);
		}

	}
	[ContextMenu("Blood")]
	public void bloodEffect(){
		float rot = Random.Range(0,360);
		GameObject go =  Instantiate(BloodEffect,transform.position,Quaternion.Euler(0, 0,rot)) as GameObject;
		go.transform.SetParent(this.transform);
	}	

	public void DecreaseLove(int Amount){

		if (Current_Love<= 0){
			
			Current_Love= 0;
		} else {
			Current_Love -= Amount;
		}
		power.BarAmount =(float) Current_Love/(float) max_Love;
		power.BarText = Current_Love.ToString();

	}
	public void IncreaseLove(int Amount){
		if(Current_Love<=ls.currentLevel.Love){

			if(Amount>=ls.currentLevel.Love || Current_Love+Amount>=ls.currentLevel.Love){
				int temp = ls.currentLevel.Love;

				Current_Love= temp;

			}

			else {

				Current_Love+=Amount;

			}
			power.BarAmount = (float)Current_Love/ (float)max_Love;
			power.BarText =  Current_Love.ToString();
				
		
	}
	}

	public void Hit(int dmg){
	//	print ("player hit "+ Current_Blood);


			Current_Blood-= dmg;
		//print ("After: "+ Current_Blood);
		
			bloodEffect();
			health.BarAmount = (float)Current_Blood/(float)max_Blood;
			  health.BarText = Current_Blood.ToString();
		
	}

	public void AddHealth(int Amount){

		if(Current_Blood<=ls.currentLevel.Blood){

			if(Amount>=ls.currentLevel.Blood || Current_Blood+Amount>=ls.currentLevel.Blood){
				int temp = ls.currentLevel.Blood;
			
				Current_Blood = temp;
			
			}

			else {

				Current_Blood+=Amount;

			}
			health.BarAmount = (float)Current_Blood/(float)max_Blood;
			health.BarText = Current_Blood.ToString();

		}
	}

}
