using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AttackManager : MonoBehaviour {

	public GameObject regSkill;
	public GameObject specSkill;

	public static GameObject regSkillImage;
	public static GameObject specSkillImage;

	GameObject database;
	public static AttackDatabase attData;
	public static ItemData itemData;

	public static Attacks currRegAtt;
	public static Attacks currSpecAtt;

	// Use this for initialization
	void Start () {

		/*What the deafult Regular attack and Special Attacks are this is what the player 
		 * will be attacking with from start.*/
		database = GameObject.FindGameObjectWithTag ("Database");
		attData = database.GetComponent<AttackDatabase>();
		itemData = database.GetComponent<ItemData> ();

		currRegAtt = attData.attacks [0];
		currSpecAtt = attData.attacks [5];
		//Just so you can access the skill Images.
		regSkill.GetComponent<Image>().sprite =  currRegAtt.attIcon;
		specSkill.GetComponent<Image>().sprite =  currSpecAtt.attIcon;

		regSkillImage = regSkill;
		specSkillImage = specSkill;

		itemData.item [12].openIt = true;
		itemData.item [15].openIt = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ChangeRegAtt (int x) {
		
		/*As you increase the points (x) under Points the Regular skill Image will change as 
		 * well as the assigned Regular attack for the player evolving.*/
		if (x % 2 == 0) {
			if (regSkillImage.name == "Reg Skill_Image") {
				if (itemData.item [12].openIt == true) {
					if (Points.attack == 2) {
						currRegAtt = attData.attacks [1];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 4) {
						currRegAtt = attData.attacks [2];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 6) {
						currRegAtt = attData.attacks [3];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 8) {
						currRegAtt = attData.attacks [4];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					}
				} else if (itemData.item [13].openIt == true) {
					if (Points.attack == 2) {
						currRegAtt = attData.attacks [11];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 4) {
						currRegAtt = attData.attacks [12];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 6) {
						currRegAtt = attData.attacks [13];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 8) {
						currRegAtt = attData.attacks [14];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					}
				} else if  (itemData.item [14].openIt == true) {
					if (Points.attack == 2) {
						currRegAtt = attData.attacks [21];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 4) {
						currRegAtt = attData.attacks [22];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 6) {
						currRegAtt = attData.attacks [23];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					} else if (Points.attack == 8) {
						currRegAtt = attData.attacks [24];
						regSkillImage.GetComponent<Image> ().sprite = currRegAtt.attIcon;
					}
				}
			}
		}
	}

	public static void UseRegAtt (int x, Transform firePoint) {

		/*Will go on for how much the RegAtt can fire. First a gameobject will be created, 
		 *the name will be changed, its icon will be its sprite, it will get a rigibody, 
		 *a colider and a skillbullet. It will be assigned a direction depending on what 
		 *was passed from the player. It will be rescaled (because the placeholders we have
		 *are small) and it will come out of its firePoint position passed by the player.*/
		for (int i = 0; i < currRegAtt.amountFired; i++) {
			currRegAtt.CreateGameObject (x,firePoint);
		}
	}

	public static void ChangeSpecialAtt (int x) {

		/*As you increase the points (x) under Points the Special skill Image will change as 
		 * well as the assigned Special attack for the player evolving.*/
		if (x % 2 == 0) {
			if (specSkillImage.name == "Special Skill_Image") {
				if (itemData.item [15].openIt == true) {
					if (Points.skill == 2) {
						currSpecAtt = attData.attacks [6];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 4) {
						currSpecAtt = attData.attacks [7];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 6) {
						currSpecAtt = attData.attacks [8];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 8) {
						currSpecAtt = attData.attacks [9];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					}
				} else if (itemData.item [16].openIt == true) {
					if (Points.skill == 2) {
						currSpecAtt = attData.attacks [16];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 4) {
						currSpecAtt = attData.attacks [17];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 6) {
						currSpecAtt = attData.attacks [18];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 8) {
						currSpecAtt = attData.attacks [19];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					}
				} else if  (itemData.item [17].openIt == true){
					if (Points.skill == 2) {
						currSpecAtt = attData.attacks [26];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 4) {
						currSpecAtt = attData.attacks [27];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 6) {
						currSpecAtt = attData.attacks [28];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					} else if (Points.skill == 8) {
						currSpecAtt = attData.attacks [29];
						specSkillImage.GetComponent<Image> ().sprite = currSpecAtt.attIcon;
					}
				}
			}
		}
	}

	public static void UseSpecialAtt (int x, Transform firePoint) {

		/*This will use what ever the currSpecAtt information is, in order to determine the 
		 * fire rate, how much to shoot, how much mana is used, and what sprite to fire*/
		for (int i = 0; i < currSpecAtt.amountFired; i++) {
			currSpecAtt.CreateGameObject (x, firePoint);
		}
	}

}
