using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AttackManager : MonoBehaviour {

	public GameObject regSkill;
	public GameObject specSkill;

	static GameObject regSkillImage;
	static GameObject specSkillImage;

	public static AttackDatabase attData;

	public static Attacks currRegAtt;
	public static Attacks currSpecAtt;
	// Use this for initialization
	void Start () {

		//Just so you can access the skill Images.
		regSkillImage = regSkill;
		specSkillImage = specSkill;

		/*What the deafult Regular attack and Special Attacks are this is what the player 
		 * will be attacking with from start.*/
		attData = transform.gameObject.GetComponent<AttackDatabase>();
		currRegAtt = attData.attacks [0];
		currSpecAtt = attData.attacks [5];

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ChangeRegAtt (int x) {
		
		/*As you increase the points (x) under Points the Regular skill Image will change as 
		 * well as the assigned Regular attack for the player evolving.*/
		if (x % 2 == 0) {
			if (regSkillImage.name == "Reg Skill_Image") {
				if (regSkillImage.GetComponent<Image> ().color == Color.white) {
					regSkillImage.GetComponent<Image> ().color = Color.cyan;
					currRegAtt = attData.attacks [1];
				} else if (regSkillImage.GetComponent<Image> ().color == Color.cyan) {
					regSkillImage.GetComponent<Image> ().color = Color.blue;
					currRegAtt = attData.attacks [2];
				} else if (regSkillImage.GetComponent<Image> ().color == Color.blue) {
					regSkillImage.GetComponent<Image> ().color = Color.red;
					currRegAtt = attData.attacks [3];
				} else {
					regSkillImage.GetComponent<Image> ().color = Color.magenta;
					currRegAtt = attData.attacks [4];
				}
			}
		}

	}

	public static void UseRegAtt () {

		/*This will use what ever the currRegAtt information is, in order to determine the 
		 * fire rate, how much to shoot, how much mana is used, and what sprite to fire*/
	}

	public static void ChangeSpecialAtt (int x) {

		/*As you increase the points (x) under Points the Special skill Image will change as 
		 * well as the assigned Special attack for the player evolving.*/
		if (x % 2 == 0) {
			if (specSkillImage.name == "Special Skill_Image") {
				if (specSkillImage.GetComponent<Image> ().color == Color.white) {
					specSkillImage.GetComponent<Image> ().color = Color.cyan;
					currSpecAtt = attData.attacks [6];
				} else if (specSkillImage.GetComponent<Image> ().color == Color.cyan) {
					specSkillImage.GetComponent<Image> ().color = Color.blue;
					currSpecAtt = attData.attacks [7];
				} else if (specSkillImage.GetComponent<Image> ().color == Color.blue) {
					specSkillImage.GetComponent<Image> ().color = Color.red;
					currSpecAtt = attData.attacks [8];
				} else {
					specSkillImage.GetComponent<Image> ().color = Color.magenta;
					currSpecAtt = attData.attacks [9];
				}
			}
		}

	}

	public static void UseSpecialAtt () {

		/*This will use what ever the currSpecAtt information is, in order to determine the 
		 * fire rate, how much to shoot, how much mana is used, and what sprite to fire*/
	}

}
