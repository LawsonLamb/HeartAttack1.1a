using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	GameObject database;
	UIScripts displays;
	Specials spec;
	ItemData itemData;
	Vector3 pos;
	private float SkillRotation;
	private PlayerDirection player_direction;
	private Vector2 VecDirection;
	private float animSpeed =0.0f;
	public Animator anim;
	public Item buff = new Item();
	//COULD BE PUT IN A STATS STRUCT
	#region Stats
	public float dmg = 7f;
	public float defib = 0f;

	public float mDmg = 10f;
	public float aVera = 0f;

	public float def = 1.0f;
	public float pMaker = 0f;

	public float speed = 2.0f;
	public float adren = 0f;

	public float health = 100;
	public float maxHealth;
	public float magic = 100;
	public float maxMagic;
	public float energy = 100;
	public float maxEnergy;
	#endregion
	public int enemyKillCount;
	public bool tranfusionActive = false;

	#region Timers
	float magicTimer = 5.0f;
	float resetMagicTimer;

	float specialTimer = 20.0f;
	float resetSpecialTimer;
	public bool specialCoolDown = false;

	public float buffTimer;
	float resetBuffTimer;
	#endregion

	#region CurrentInfo
	public int currlv = 1;
	public int currExp = 0;
	public int maxExp = 50;
	public int points;

	public int coolDown;
	#endregion
	public Transform firePoint;
	public GameObject blood;
	int direction;
	// Use this for initialization
	void Start () {

		database = GameObject.FindGameObjectWithTag ("Database");
		displays = GameObject.FindGameObjectWithTag ("Background").GetComponent<UIScripts> ();
		spec = GameObject.FindGameObjectWithTag ("Background").GetComponent<Specials> ();
		itemData = database.GetComponent<ItemData> ();
		maxHealth = health;
		maxMagic = magic;
		maxEnergy = energy;
		anim = GetComponent<Animator> ();
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

		if (Input.GetKeyDown (KeyCode.Q)) {
			if (itemData.item[8].Stock > 0) {
				CreateWaterBallons(itemData.item[8]);
			}
		}
	}

	void RegularAttack() {

		/*Handles the use of regular attacks*/
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			ChangeDirection(0);
			displays.UseMagic (10);
			player_direction = PlayerDirection.UP;
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			player_direction = PlayerDirection.DOWN;
			ChangeDirection(1);
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			player_direction = PlayerDirection.LEFT;
			ChangeDirection(3);
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			player_direction = PlayerDirection.RIGHT;
			ChangeDirection(2);
			displays.UseMagic (10);
			magicTimer = resetMagicTimer;
		}
		SetDirection ();

		magicTimer -= 0.05f;
		if (magicTimer <= 0) {
			displays.RestoreMagic (10);
			magicTimer = resetMagicTimer;
		}
	}

	void SpecialAttack() {

		/*Handels the use of special skill*/
		if (specialCoolDown == false) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				displays.UseSpecial ();
				displays.specialBar.color = Color.gray;
				specialTimer = resetSpecialTimer;
				specialCoolDown = true;
			}
		} else {
			specialTimer -= 0.05f;
			if (specialTimer <= 0) {
				displays.RestoreSpecial (10);
				if (coolDown == spec.coolFactor) {
					spec.RemoveSkill (displays.currSpecSkill);
				}
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
		item.item = new GameObject();
		item.item.gameObject.name = "Dropped " + item.Name;
		item.item.AddComponent<SpriteRenderer> ().sprite = item.Icon;
		item.item.AddComponent<BoxCollider2D> ();
		item.item.AddComponent<Rigidbody2D> ();
		item.item.AddComponent<WaterBalloons> ();
		item.item.transform.localScale = new Vector3 (5, 5, 1);
		item.openIt = true;
		item.Stock -= 1;
		displays.SackUpdate ();
		//firePoint = gameObject.transform.GetChild (3).gameObject.transform;
		//item.item.transform.localPosition = firePoint.position;
	}

	void PlayerMovement () {

		//Just a basic way for the player to move around the screen.
		if (Input.GetKey (KeyCode.W)) {
			animSpeed = 1.0f;
			SetAnimDirection(1.0f);
			pos.y = speed;
			pos.x = 0;
		} else if (Input.GetKey (KeyCode.A)) {
			animSpeed = 1.0f;
			SetAnimDirection(0.0f);
			GetComponent<SpriteRenderer>().flipX = true;
			pos.x = -speed;
			pos.y = 0;
		} else if (Input.GetKey (KeyCode.S)) {
			
			animSpeed = 1.0f;
			SetAnimDirection(-1.0f);
			pos.y = -speed;
			pos.x = 0;
		} else if (Input.GetKey (KeyCode.D)) {
			pos.x = speed;
			pos.y = 0;
			SetAnimDirection (0.0f);
			GetComponent<SpriteRenderer>().flipX = false;
			animSpeed = 1.0f;
		} else {
			pos.x = 0;
			pos.y = 0;
			animSpeed = 0.0f;
		}

		SetAnimSpeed(animSpeed);
		transform.Translate (pos.x*Time.deltaTime,pos.y * Time.deltaTime, 0);

		//gameObject.transform.position = pos;
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

	void ChangeDirection (int direct) {
		switch (direct) {
		case 0:
			firePoint.localPosition = new Vector2 (0, 1.5f);
			direction = 0;
			VecDirection = Vector2.up;
			SkillRotation = 90.0f;

			break;
		case 1:
			firePoint.localPosition = new Vector2 (0, -1.5f);

			firePoint.localRotation = new Quaternion (0, 0, 90, 0);

			VecDirection = Vector2.down;
			SkillRotation = -90.0f;
		
			direction = 1;
			break;
		case 2:
			firePoint.localPosition = new Vector2 (1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 0, 270, 0);
			VecDirection = Vector2.left;
			SkillRotation = 0.0f;

			direction = 2;
			break;
		case 3:
			firePoint.localPosition = new Vector2 (-1.5f, 0);
			firePoint.localRotation = new Quaternion (0, 0, 180, 0);
			VecDirection = Vector2.right;
			SkillRotation = 180.0f;
			direction = 3;
			break;
		}
	}

	public void UseRegularAttack() {
		blood.GetComponent<SkillBullet> ().direction = direction;
		Instantiate (blood,this.transform.position,Quaternion.Euler(0,0,SkillRotation) );
	}

	public void UseSpecialAttack() {
		spec.wasActive = true;
		spec.ActivateSkill (displays.currSpecSkill);
	}

	public void LevelManager(int expInc) {

		currExp += expInc;
		if (currExp >= maxExp) {
			currlv += 1;
			maxExp = 50 + (125 * (currlv - 1));
			currExp = 0;
			if (currlv <= 11) {
				points += 3;
			}
		}

	}
	void SetDirection(){

		switch (player_direction) {
		case PlayerDirection.UP:
			VecDirection = Vector2.up;
			SkillRotation = 0.0f;

			break;
		case PlayerDirection.DOWN:
			VecDirection = Vector2.down;
			SkillRotation = 180.0f;


			break;
		case PlayerDirection.RIGHT:
			VecDirection = Vector2.right;
			SkillRotation = -90.0f;


			break;
		case PlayerDirection.LEFT:
			VecDirection = Vector2.left;
			SkillRotation = 90.0f;
			break;
		}
	}

	void SetAnimDirection(float direction){
		anim.SetFloat ("Direction", direction);


	}
	void SetAnimSpeed(float speed){
		anim.SetFloat ("Speed",speed);


	}



}
