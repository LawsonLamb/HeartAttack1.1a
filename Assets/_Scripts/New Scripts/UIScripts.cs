using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class UIScripts : MonoBehaviour {

	public GameObject sack;
	bool sackactivity = false;

	Player player;
	GameObject database;
	ItemData itemData;
	AttackDatabase attData;
	/// <summary>
	///  COULD BE PUT IN ONE SCRIPT AND REUSED
	/// </summary>
	public Text coinText;
	public Image coinIcon;
	Item coin;

	public Text waterballonText;
	public Image waterballonIcon;
	Item waterballon;

	public Text keyText;
	public Image keyIcon;
	Item key;

	public Text heartKeyText;
	public Image heartKeyIcon;
	Item heartKey;

	public Image healthBar;
	public Image magicBar;
	public Image specialBar;

	public Text statText;

	public GameObject statusWin;
	public Text pointText;

	public GameObject attackStatusArea;
	GameObject attackButton;
	public int attPoints; //Increases regular attack

	public GameObject heartStatusArea;
	GameObject heartButton;
	public int hpPoints;

	public GameObject skillStatusArea;
	GameObject skillButton;
	public int skPoints; //Increase specail attack

	public GameObject speedStatusArea;
	GameObject speedButton;
	public int spPoints;

	GameObject amountBar;
	Text pointDisplay;

	public Image permIcon;
	public Sprite transparent;
	List<Image> icons = new List<Image> ();

	public Image regSkill;
	public Attacks currRegSkill;

	public Image specSkill;
	public Attacks currSpecSkill;

	Item make;

	public GameObject playerPos;
	public RectTransform playerHealth;
	public RectTransform canvasRect;
	Vector3 viewportPoint;
	Vector3 healthBarPos;

	public Text bossUIName;
	Boss foeBoss;

	public GameObject cupid; 

	public bool pause;
	public GameObject pauseButton;
	public GameObject pauseUI;

	// Use this for initialization
	void Start () {
	
		database = GameObject.FindGameObjectWithTag ("Database");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		foeBoss = GameObject.FindGameObjectWithTag ("Boss").GetComponent<Boss> ();

		attData = database.GetComponent<AttackDatabase> ();
		itemData = database.GetComponent<ItemData> ();

		sack.SetActive (sackactivity);

		for (int i = 0; i < 5; i++) {
			Image newIcon = Instantiate (permIcon);
			newIcon.transform.SetParent (sack.transform);
			newIcon.transform.localPosition = new Vector3 (-40, 50 - (i * 25), 0);
			newIcon.sprite = transparent;
			icons.Add (newIcon);
		}

		SackUpdate ();

		attackButton = attackStatusArea.transform.GetChild(2).gameObject;
		heartButton = heartStatusArea.transform.GetChild(2).gameObject;
		skillButton = skillStatusArea.transform.GetChild(2).gameObject;
		speedButton = speedStatusArea.transform.GetChild(2).gameObject;

		currRegSkill = attData.attacks [0];
		regSkill.sprite = currRegSkill.attIcon;

		currSpecSkill = attData.attacks [5];
		specSkill.sprite = currSpecSkill.attIcon;

		itemData.item [12].openIt = true;
		itemData.item [15].openIt = true;

		/*
		viewportPoint = Camera.main.WorldToViewportPoint(playerPos.transform.position);
		healthBarPos = new Vector2 (
			((viewportPoint.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
			((viewportPoint.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
		playerHealth.anchoredPosition = healthBarPos;
*/
		pause = false;
		pauseButton.SetActive (true);
		pauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//Just a display so I can check status stuff.
		statText.text = "Your Current Stats are: " + "\n M.Dmg: " + player.mDmg  + "\n Dmg: " + player.dmg
			+ "\n Defense: " + player.def  + "\n Speed: " + player.speed + "\n Lv: " + player.currlv 
			+ "\n Exp: " + player.currExp;
		
		if (statusWin.activeSelf == true) {
			pointText.text = player.points + "/30";
		}

		if (player.points <= 0) {
			attackButton.SetActive (false);
			heartButton.SetActive (false);
			skillButton.SetActive (false);
			speedButton.SetActive (false);
		} else {
			if (attPoints < 8) {
				attackButton.SetActive (true);
			} else {
				attackButton.SetActive (false);
			}
			if (hpPoints < 8) {
				heartButton.SetActive (true);
			} else {
				heartButton.SetActive (false);
			}
			if (skPoints < 8) {
				skillButton.SetActive (true);
			} else {
				skillButton.SetActive (false);
			}
			if (spPoints < 8) {
				speedButton.SetActive (true);
			} else {
				speedButton.SetActive (false);
			}
		}

		//UpdateHealthBarPosition ();

		if(Input.GetKeyDown (KeyCode.P)) {
			PauseButton();
		}

		if (pause) {
			Time.timeScale = 0;
			pauseButton.SetActive (false);
			pauseUI.SetActive (true);
		} else {
			Time.timeScale = 1;
			pauseButton.SetActive (true);
			pauseUI.SetActive (false);
			if (Input.GetKeyDown (KeyCode.E)) {
				sackactivity = !sackactivity;
				sack.SetActive (sackactivity);
			}
		}

	}

	void UpdateHealthBarPosition() {
		Vector3 barPos = new Vector3 (playerPos.transform.position.x, playerPos.transform.position.y + 2);
		viewportPoint = Camera.main.WorldToViewportPoint(barPos);
		healthBarPos = new Vector2 (
			((viewportPoint.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)),
			((viewportPoint.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
		playerHealth.anchoredPosition = healthBarPos;
	}

	public void SackUpdate(){

		/*Takes the Display for each item and updates them according to the 
		amount they have in stock. Also formats it in a x### mannor.*/
		coin = itemData.GetItemByID (7);
		coinText.text = string.Format("{0:x00#}", coin.Stock);
		coinIcon.sprite = coin.Icon;

		waterballon = itemData.GetItemByID (8);
		waterballonText.text = string.Format("{0:x00#}", waterballon.Stock);
		waterballonIcon.sprite = waterballon.Icon;

		key = itemData.GetItemByID (0);
		keyText.text = string.Format("{0:x00#}", key.Stock);
		keyIcon.sprite = key.Icon;

		heartKey = itemData.GetItemByID (1);
		heartKeyText.text = string.Format("{0:x00#}", heartKey.Stock);
		heartKeyIcon.sprite = heartKey.Icon;

	}

	public void TakeDamage(float dmg) {
		if (player.health > 0) {
			player.health -= dmg;
			float displayHealth = player.health / player.maxHealth;
			healthBar.transform.localScale = new Vector3 (displayHealth, 1, 1);
			//healthBar.transform.localPosition = new Vector2 (healthBar.transform.localPosition.x + (20 / dmg), 0);
			player.GetComponent<SoundEffects> ().PlaySound (0);
		} else {
			//Application.LoadLevel (4);
			SceneManager.LoadScene (4);
			//print ("You Have Died");
		}
	}

	public void RestoreHealth(float heal) {
		if (player.health < player.maxHealth) {
			player.health += heal;
			float displayHealth = player.health / player.maxHealth;
			healthBar.transform.localScale = new Vector3 (displayHealth, 1, 1);
		//	healthBar.transform.localPosition = new Vector2 (healthBar.transform.localPosition.x - (-20 / heal), 0);
		}
	}

	public void UseMagic(float cost){
		if (player.magic > 0) {
			player.magic -= cost;
			float displayMagic = player.magic / player.maxMagic;
			magicBar.transform.localScale = new Vector3 (1, displayMagic, 1);
			//magicBar.transform.localPosition = new Vector2 (magicBar.transform.localPosition.x + (30 / cost), 0);
			player.GetComponent<SoundEffects> ().PlaySound (1);
			player.UseRegularAttack ();
		} else {
			//print ("You are out of magic");
		}
	}

	public void RestoreMagic(float restore) {
		if (player.magic < player.maxMagic) {
			player.magic += restore;
			float displayMagic = player.magic / player.maxMagic;
			magicBar.transform.localScale = new Vector3 (1, displayMagic, 1);
		//	magicBar.transform.localPosition = new Vector2 (magicBar.transform.localPosition.x - (30 / restore), 0);
		} else {
		}
	}

	public void UseSpecial() {
		player.energy -= player.energy;
		float displayEnergy = player.energy / player.maxEnergy;
		specialBar.transform.localScale = new Vector3 (1, displayEnergy, 1);
	//	specialBar.transform.localPosition = new Vector2 (-150, 0);
		if ((currSpecSkill.attID >= 25) && (currSpecSkill.attID <= 29)) {
			cupid.SetActive (true);
		}
		player.UseSpecialAttack ();
	}

	public void RestoreSpecial(float restore) {
		if (player.energy < player.maxEnergy) {
			player.coolDown += 1;
			player.energy += restore;
			float displayEnergy = player.energy / player.maxEnergy;
			specialBar.transform.localScale = new Vector3 (1, displayEnergy, 1);
		//	specialBar.transform.localPosition = new Vector2 (specialBar.transform.localPosition.x - (30 / restore), 0);
		} else {
			player.coolDown = 0;
			specialBar.color = Color.green;
			player.specialCoolDown = false;
		}
	}

	public void AddPermIcon (Item permItem) {

		//Creates a Perm Item Icon on the right hand side of the screen.
		for (int i = 0; i < 5; i++) {
			if ((icons [i].sprite == null) || (icons [i].sprite == transparent)) {
				icons [i].sprite = permItem.Icon;
				return;
			}
		}
	}

	public void AttackButton () {

		//Find the bar for attack
		amountBar = attackStatusArea.transform.GetChild(0).gameObject;

		//Find the display for attack points
		pointDisplay = attackStatusArea.transform.GetChild(1).GetComponent<Text>();

		//Increase attack points and decrease player points
		attPoints += 1;
		player.points -= 1;

		//Every two points change your attack, but always increase your stats
		if (attPoints % 2 == 0) {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
			ChangeRegAtt (attPoints);
		} else {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
		}

		for (int a = 0; a < attPoints; a++) {
			amountBar.transform.GetChild (a).GetComponent<Image> ().color = Color.green;
		}
			
		pointDisplay.text = attPoints + "/8";

		//only do able if attack points is below 8
		if ((attPoints >= 8) || player.points <= 0) {
			attackButton.SetActive (false);
		}
	}

	public void HeartButton() {

		//Find the bar for attack
		amountBar = heartStatusArea.transform.GetChild(0).gameObject;

		//Find the display for attack points
		pointDisplay = heartStatusArea.transform.GetChild(1).GetComponent<Text>();

		//Increase attack points and decrease player points
		hpPoints += 1;
		player.points -= 1;

		//Every two points change your attack, but always increase your stats
		if (hpPoints % 2 == 0) {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
			player.maxHealth += 100;
		} else {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
		}

		for (int a = 0; a < hpPoints; a++) {
			amountBar.transform.GetChild (a).GetComponent<Image> ().color = Color.green;
		}

		pointDisplay.text = hpPoints + "/8";

		//only do able if attack points is below 8
		if ((hpPoints >= 8) || player.points <= 0) {
			heartButton.SetActive (false);
		}
	}

	public void SkillButton() {

		//Find the bar for attack
		amountBar = skillStatusArea.transform.GetChild(0).gameObject;

		//Find the display for attack points
		pointDisplay = skillStatusArea.transform.GetChild(1).GetComponent<Text>();

		//Increase attack points and decrease player points
		skPoints += 1;
		player.points -= 1;

		//Every two points change your attack, but always increase your stats
		if (skPoints % 2 == 0) {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
			ChangeSpecAtt (skPoints);
			player.maxEnergy -= 10;
		} else {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
		}

		for (int a = 0; a < skPoints; a++) {
			amountBar.transform.GetChild (a).GetComponent<Image> ().color = Color.green;
		}

		pointDisplay.text = skPoints + "/8";

		//only do able if attack points is below 8
		if ((skPoints >= 8) || player.points <= 0) {
			skillButton.SetActive (false);
		}
	}

	public void SpeedButton() {

		//Find the bar for attack
		amountBar = speedStatusArea.transform.GetChild(0).gameObject;

		//Find the display for attack points
		pointDisplay = speedStatusArea.transform.GetChild(1).GetComponent<Text>();

		//Increase attack points and decrease player points
		spPoints += 1;
		player.points -= 1;

		//Every two points change your attack, but always increase your stats
		if (spPoints % 2 == 0) {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
			player.maxMagic += 100;
		} else {
			player.UpdateStatus (attPoints, hpPoints, skPoints, spPoints);
		}

		for (int a = 0; a < spPoints; a++) {
			amountBar.transform.GetChild (a).GetComponent<Image> ().color = Color.green;
		}

		pointDisplay.text = spPoints + "/8";

		//only do able if attack points is below 8
		if ((spPoints >= 8) || player.points <= 0) {
			speedButton.SetActive (false);
		}
	}

	public void ChangeRegAtt (int points) {

		if (itemData.item[12].openIt == true) {
			if (attPoints == 2) {
				currRegSkill = attData.attacks [1];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 4) {
				currRegSkill = attData.attacks [2];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 6) {
				currRegSkill = attData.attacks [3];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 8) {
				currRegSkill = attData.attacks [4];
				regSkill.sprite = currRegSkill.attIcon;
			}
		} else if (itemData.item[13].openIt == true) {
			if (attPoints == 2) {
				currRegSkill = attData.attacks [11];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 4) {
				currRegSkill = attData.attacks [12];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 6) {
				currRegSkill = attData.attacks [13];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 8) {
				currRegSkill = attData.attacks [14];
				regSkill.sprite = currRegSkill.attIcon;
			}
		} else if (itemData.item[14].openIt == true) {
			if (attPoints == 2) {
				currRegSkill = attData.attacks [21];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 4) {
				currRegSkill = attData.attacks [22];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 6) {
				currRegSkill = attData.attacks [23];
				regSkill.sprite = currRegSkill.attIcon;
			} else if (attPoints == 8) {
				currRegSkill = attData.attacks [24];
				regSkill.sprite = currRegSkill.attIcon;
			}
		}
	}

	public void ChangeSpecAtt (int points) {

		if (itemData.item[15].openIt == true) {
			if (skPoints == 2) {
				currSpecSkill = attData.attacks [6];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 4) {
				currSpecSkill = attData.attacks [7];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 6) {
				currSpecSkill = attData.attacks [8];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 8) {
				currSpecSkill = attData.attacks [9];
				specSkill.sprite = currSpecSkill.attIcon;
			}
		} else if (itemData.item[16].openIt == true) {
			if (skPoints == 2) {
				currSpecSkill = attData.attacks [16];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 4) {
				currSpecSkill = attData.attacks [17];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 6) {
				currSpecSkill = attData.attacks [18];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 8) {
				currSpecSkill = attData.attacks [19];
				specSkill.sprite = currSpecSkill.attIcon;
			}
		} else if (itemData.item[17].openIt == true) {
			if (skPoints == 2) {
				currSpecSkill = attData.attacks [26];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 4) {
				currSpecSkill = attData.attacks [27];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 6) {
				currSpecSkill = attData.attacks [28];
				specSkill.sprite = currSpecSkill.attIcon;
			} else if (skPoints == 8) {
				currSpecSkill = attData.attacks [29];
				specSkill.sprite = currSpecSkill.attIcon;
			}
		}
	}

	public void BossTakeDamage(float dmg, Image currBar) {
		if (foeBoss.health > 0) {
			foeBoss.health -= dmg;
			foeBoss.barHealth -= dmg;
			float displayHealth = foeBoss.barHealth / 100;
			currBar.transform.localScale = new Vector3 (displayHealth, 1, 1);
			currBar.transform.localPosition = new Vector2 (currBar.transform.localPosition.x + (20 / dmg), 0);
			if (currBar.transform.localScale.x <= 0) {
				foeBoss.barCount -= 1;
				foeBoss.barHealth = foeBoss.health / foeBoss.barCount;
				Destroy (currBar.gameObject);
			}
		} 
		if (foeBoss.health <= 0) {
			print ("Boss is Dead");
			Destroy (foeBoss.gameObject);
			player.LevelManager (50);
			player.enemyKillCount += 1;
		}
	}

	public void PauseButton () {
		pause = !pause;
	}

	public void RestartButton () {
		//Application.LoadLevel (Application.loadedLevel);
		SceneManager.LoadScene (SceneManager.GetActiveScene().ToString());

	}

	public void MainMenuButton() {
		//Application.LoadLevel (0);
		SceneManager.LoadScene (0);
	}

	public void QuitButton() {
		Application.Quit();
	}
}
