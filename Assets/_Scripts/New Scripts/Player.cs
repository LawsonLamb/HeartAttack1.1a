using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject database;
	UIScripts displays;
	Vector3 pos;
	Item buff = new Item();

	public float dmg = 7f;
	public float defib = 0f;

	public float mDmg = 10f;
	public float aVera = 0f;

	public float def = 1.0f;
	public float pMaker = 0f;

	public float speed = .05f;
	public float adren = 0f;

	public int points = 0;

	public float health = 100;
	public float maxHealth;
	public float magic = 100;
	public float maxMagic;
	public float energy = 100;
	public float maxEnergy;

	public int enemyKillCount;
	public bool tranfusionActive = false;

	float magicTimer = 5.0f;
	float resetMagicTimer;

	float specialTimer = 20.0f;
	float resetSpecialTimer;
	public bool specialCoolDown = false;

	float buffTimer;
	float resetBuffTimer;

	public int currlv = 0;
	public int currExp = 0;
	public int maxExp = 50;

	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();

		maxHealth = health;
		maxMagic = magic;
		maxEnergy = energy;

		resetMagicTimer = magicTimer;
		resetSpecialTimer = specialTimer;

		//Used to allow the player to move around on the screen.
		pos = gameObject.transform.position;

	}

	// Update is called once per frame
	void Update () {

		PlayerMovement ();

		if (tranfusionActive == true) {
			Transfusion ();
		}

		RegularAttack ();
		SpecialAttack ();

		//Any Buff items that were picked up, so they can be cooled down.
		if (buff.openIt == true) {
			buffTimer -= 0.05f;
			CoolDownBuff ();
		}
	}

	void RegularAttack() {

		/*Handles the use of regular attacks*/
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		}

		magicTimer -= 0.05f;
		if (magicTimer <= 0) {
			displays.RestoreMagic (10);
			magicTimer = resetMagicTimer;
		}
		print (magic);
	}

	void SpecialAttack() {

		/*Handels the use of special skill*/
		if (specialCoolDown == false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				displays.UseSpecial ();
				specialTimer = resetSpecialTimer;
				specialCoolDown = true;
			}
		} else {
			specialTimer -= 0.05f;
			if (specialTimer <= 0) {
				displays.RestoreSpecial (10);
				specialTimer = resetSpecialTimer;
			}
		}
	}

	public void UpdateStatus (int att, int hp, int sk, int sp) {

		//Takes the coresponding att (attack), hp (heart), sk (skill), and sp (speed) and Updates the player stats when called.
		dmg =  (7 + defib) + (att * 3f);

		def = (1.0f + pMaker) + (hp * 0.5f);

		resetMagicTimer = 5f - (sk * 0.5f);
		mDmg = (10 + aVera) + (sk * 5f);

		speed = (0.05f + adren) + (sp * 0.05f);
		resetSpecialTimer = 20f - (sp * 0.625f);

	}

	void CreateWaterBallons (Item item) {
		/*Makes the bomb active and creates a new gameobject and names it Dropped Bomb*/
		item.openIt = true;
		item.item = new GameObject();
		item.item.gameObject.name = "Dropped " + item.Name;
		item.item.AddComponent<SpriteRenderer> ().sprite = item.Icon;
		item.item.AddComponent<BoxCollider2D> ();
		item.item.AddComponent<Rigidbody2D> ();
		item.item.AddComponent<WaterBalloons> ();
		item.item.transform.localScale = new Vector3 (5, 5, 1);
		//firePoint = gameObject.transform.GetChild (3).gameObject.transform;
		//item.item.transform.localPosition = firePoint.position;
	}

	void PlayerMovement () {

		//Just a basic way for the player to move around the screen.
		if (Input.GetKey (KeyCode.W)) {
			pos.y += speed;
		} else if (Input.GetKey (KeyCode.A)) {
			pos.x -= speed;
		} else if (Input.GetKey (KeyCode.S)) {
			pos.y -= speed;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x += speed;
		} else {
		}

		gameObject.transform.position = pos;

	}

	void CoolDownBuff () {
		/*Cool downs the buffs from items*/

		if (buffTimer >= 0) {
			//If cool down was called but you still have time in your timer nothing will happen
		} else {
			/*Once the timer hits zero it will check with buff was activated and return your 
			 *stats back to how they should be without the buff. It will also rest the buff 
			 *items information.*/
			if (buff.ID == 3) {
				speed -= buff.Change;
			} else if (buff.ID == 4) {
				def -= buff.Change;
			} else if (buff.ID == 5) {
				dmg -= buff.Change;
			} else {
				mDmg -= buff.Change;
			}
			buff.openIt = false;
			buff.Duration = resetBuffTimer;
		}
	}

	void Transfusion () {
		/*Once you pick this up after 10 enemy kills you will restore half health.*/
		if (enemyKillCount == 10) {
			displays.RestoreHealth (10);
			enemyKillCount = 0;
			print ("Health stolen");
		}
		print ("Haven't stolen health");
	}

	void UseRegularAttack() {
	}

	void UseSpecialAttack() {
	}

	public void LevelManager(int expInc) {

		currExp += expInc;
		if (currExp >= maxExp) {
			currlv += 1;
			maxExp = 50 + (125 * currlv);
			currExp = 0;
			if (currlv <= 10) {
				points += 3;
			}
		}

	}
}
