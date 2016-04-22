using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Boss : MonoBehaviour {

	Foes thisfoe;
	FoeDatabase foeData;
	UIScripts displays;
	Physical attributes;
	public float health;
	public float maxHealth;
	bool bossIsActive;
	List<Image> barList = new List<Image>();
	public int barCount;
	public float barHealth;
	public Image initBar;
	public Image barArea;
	Image currBar;
	Player player;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		foeData = GameObject.FindGameObjectWithTag ("Database").GetComponent<FoeDatabase> ();
		attributes = gameObject.GetComponent<Physical> ();
		bossIsActive = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (bossIsActive) {
			thisfoe = foeData.GetFoeByName (gameObject.name);
			attributes.SetFoeStats (thisfoe);

			displays.bossUIName.text = attributes.name;
			health = attributes.health;
			maxHealth = health;

			barCount = (int)health / 100;
			barHealth = health / barCount;
			for (int i = 0; i < barCount; i++) {
				Image newBar = Instantiate (initBar);
				newBar.name = "Boss Health_Bar" + i;
				newBar.transform.SetParent (barArea.transform);
				newBar.transform.localScale = new Vector3 (1, 1, 1);
				newBar.transform.localPosition = new Vector3 (-270, 0, 0);
				if (i == 0) {
					newBar.color = Color.red;
				} else if (i == 1) {
					newBar.color = Color.yellow;
				} else if (i == 2) {
					newBar.color = Color.green;
				} else if (i == 3) {
					newBar.color = Color.blue;
				} else if (i == 4) {
					newBar.color = Color.gray;
				} else if (i == 5) {
					newBar.color = Color.black;
				}
				barList.Add (newBar);
			}
			bossIsActive = false;
		}
		attributes.health = health;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Blood") {
			if (barList [0] != null) {
				currBar = barList [(barCount - 1)];
			}
			displays.BossTakeDamage (player.dmg, currBar);
		}
	}
}
