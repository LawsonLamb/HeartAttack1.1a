using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Points : MonoBehaviour {

	GameObject amountBar;
	GameObject pointDisplay;
	public GameObject pointAmountDisplay;
	public static GameObject statPointAmountDisplay;
	public static int attack; //Regular skill
	public static int heart;
	public static int skill;	//Special skill
	public static int speed;

	int manaUp;
	int heartUp;

	public GameObject attAdd;
	public GameObject heartAdd;
	public GameObject skillAdd;
	public GameObject speedAdd;
	public static GameObject statAttAdd;
	public static GameObject statHeartAdd;
	public static GameObject statSkillAdd;
	public static GameObject statSpeedAdd;

	// Use this for initialization
	void Start () {
	
		statAttAdd = attAdd;
		statHeartAdd = heartAdd;
		statSkillAdd = skillAdd;
		statSpeedAdd = speedAdd;
	}
	
	// Update is called once per frame
	void Update () {
	
		DeactivateAll ();
	}

	public void PressedButt () {

		//Gathers all the information that is needed before any changes can be made.
		InitializeUI ();

		//Only allows points to be changed if you actually have points to use.
		if (Player.points > 0) {
			ChangePoints ();
		}
		//Changes the status according to what you increased.
		ChangeStatus ();

		//Updates UI for everything to match up with the changes you have made.
		ChangeUI ();

	}

	void InitializeUI () {

		//Starts by making sure the points displayed is accurate to what you have.
		pointAmountDisplay.GetComponent<Text> ().text = Player.points + "/30";

		//Finds the points display for the button that has been pressed and stores it.
		pointDisplay = transform.parent.gameObject.transform.GetChild (1).gameObject;

		//Finds the Bar display for the button that has been pressed and stores it.
		amountBar = transform.parent.gameObject.transform.GetChild (0).gameObject;

	}

	void ChangePoints () {

		/*Cross checks for the sibling Bar of the button pressed. As well as makes sure
		that the status coresponding to the Bar is not already above 8 points. If so it
		then adds one point to the status and takes one from your useable points.*/
		if ((amountBar.name == "Attack_Bar Back") && (attack < 8)) {
			attack += 1;
			Player.points -= 1;
		} else if ((amountBar.name == "Heart_Bar Back") && (heart < 8)){
			heart += 1;
			Player.points -= 1;
		} else if ((amountBar.name == "Skill_Bar Back") && (skill < 8)) {
			skill += 1;
			Player.points -= 1;
		} else {
			if (speed < 8) {
				speed += 1;
				Player.points -= 1;
			}
		}

	}

	void ChangeStatus () {

		/*Cross checks for the sibling bar of the button pressed. As well as makes sure
		thatt he status coresponding to the bar is above 0 but not above 8. If so it
		then checks if the status is divisable by 2. If so it effects the player in a
		different way compared to if it is not.*/
		if (amountBar.name == "Attack_Bar Back") {
			if ((attack > 0) && (attack <= 8)) {
				if (attack % 2 == 0) {
					Player.UpdateStatus (attack, heart, skill, speed);
					AttackManager.ChangeRegAtt (attack);
				} else {
					Player.UpdateStatus (attack, heart, skill, speed);
				}
			}
		} else if (amountBar.name == "Heart_Bar Back") {
			if ((heart > 0) && (heart <= 8)) {
				if (heart % 2 == 0) {
					heartUp += 1;
					HUD.AddHealthIcon (heartUp);
					Player.UpdateStatus (attack, heart, skill, speed);
				} else {
					Player.UpdateStatus (attack, heart, skill, speed);
				}
			}
		} else if (amountBar.name == "Skill_Bar Back") {
			if ((skill > 0) && (skill <= 8)) {
				if (skill % 2 == 0) {
					manaUp += 1;
					HUD.AddManaIcon (manaUp);
					Player.UpdateStatus (attack, heart, skill, speed);
					AttackManager.ChangeSpecialAtt (skill);
				} else {
					Player.UpdateStatus (attack, heart, skill, speed);
				}
			}
		} else {
			if ((speed > 0) && (speed <= 8)) {
				if (speed % 2 == 0) {
					Player.UpdateStatus (attack, heart, skill, speed);
				} else {
					Player.UpdateStatus (attack, heart, skill, speed);
				}
			}
		}
			
	}

	void ChangeUI () {

		/* Checks if your status are above 0 but not above 8. If so it then changes the 
		bar Icon of for the amount of each status.*/
		if (amountBar.name == "Attack_Bar Back") {
			for (int a = 0; a < attack; a++) {
				amountBar.transform.GetChild (a).GetComponent<Image> ().color = Color.green;
			}
		} else if (amountBar.name == "Heart_Bar Back") {
			for (int h = 0; h < heart; h++) {
				amountBar.transform.GetChild (h).GetComponent<Image> ().color = Color.green;
			}
		} else if (amountBar.name == "Skill_Bar Back") {
			for (int sk = 0; sk < skill; sk++) {
				amountBar.transform.GetChild (sk).GetComponent<Image> ().color = Color.green;
			}
		} else {
			for (int sp = 0; sp < speed; sp++) {
				amountBar.transform.GetChild (sp).GetComponent<Image> ().color = Color.green;
			}
		}

		/*Cross checks for the sibling bar of the button presed. It the updates the points
		display for each status. If the status is at 8 it then deactivates the button so it
		can no longer be updated again.*/
		if (amountBar.name == "Attack_Bar Back") {
			pointDisplay.GetComponent<Text> ().text = attack + "/8";
			if (attack == 8) {
				this.gameObject.SetActive (false);
			}
		} else if (amountBar.name == "Heart_Bar Back") {
			pointDisplay.GetComponent<Text> ().text = heart + "/8";
			if (heart == 8) {
				this.gameObject.SetActive (false);
			}
		} else if (amountBar.name == "Skill_Bar Back") {
			pointDisplay.GetComponent<Text> ().text = skill + "/8";
			if (skill == 8) {
				this.gameObject.SetActive (false);
			}
		} else {
			pointDisplay.GetComponent<Text> ().text = speed + "/8";
			if (speed == 8) {
				this.gameObject.SetActive (false);
			}
		}
			
		//Updates the points display.
		pointAmountDisplay.GetComponent<Text> ().text = Player.points + "/30";
	
	}

	void DeactivateAll() {
		/*If you don't have any points or you've already used all 30 points attainable 
		 *throught out the game then the add buttons disappear.*/
		if((Player.points == 0) || ((attack + heart + skill + speed) == 30)) {
			attAdd.gameObject.SetActive (false);
			heartAdd.gameObject.SetActive (false);
			skillAdd.gameObject.SetActive (false);
			speedAdd.gameObject.SetActive (false);
		}
	}

	public static void ActivateAll() {
		if (Player.points > 0) {
			statAttAdd.gameObject.SetActive (true);
			statHeartAdd.gameObject.SetActive (true);
			statSkillAdd.gameObject.SetActive (true);
			statSpeedAdd.gameObject.SetActive (true);
		}
	}
}
