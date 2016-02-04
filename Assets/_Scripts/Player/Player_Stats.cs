using UnityEngine;
using System.Collections;

public class Player_Stats : MonoBehaviour {
//	public GameObject Blood;
//
//	Leveling_System ls;
//	public static int max_Blood;
//	public static int currBlood = 0;
//
//	public static int max_Love;
//	public static int currLove = 0;
//
//	public static int max_Exp;
//	public static int currExp =0;
//	public GameObject bloodBar;
//	public GameObject loveBar;
//	public GameObject expBar;
//
//
//	// Use this for initialization
//	void Start () {
//		//stat = gameObject.GetComponent<Stats>();
//		ls = gameObject.GetComponent<Leveling_System>();
//		max_Blood = ls.currentLevel.Blood;
//		max_Love  = ls.currentLevel.Love;
//		print(max_Blood);
//
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//	[ContextMenu("Blood")]
//	public void BloodEffect(){
//		float rot = Random.Range(0,360);
//		GameObject go =  Instantiate(Blood,transform.position,Quaternion.Euler(0, 0,rot)) as GameObject;
//		go.transform.SetParent(this.transform);
//	}
//	public void DecreaseHealth() {
//		if (currBlood <= 0) {
//			currBlood = 0;
//			//GetComponent<SoundEffects>().PlaySound (2);
//			CancelInvoke();
//		} else {
//			currBlood -= 25;
//			if(currBlood <= (max_Blood/2)) {
//				//GetComponent<SoundEffects>().PlaySound (1);
//			}
//		}
//		int tempBlood = currBlood / max_Blood;
//
//	}
//
//	void DecreaseMagic() {
//		if (currLove <= 0) {
//			currLove = 0;
//		} else {
//			currLove -= 25;
//		}
//		int tempLove = currLove / max_Love;
//
//	}
//
//	void IncreaseExp() {
//		if (currExp >= max_Exp) {
//			currExp = max_Exp;
//		} else {
//			currExp += 10;
//		}
//		int tempExp = currExp / max_Exp;
//	
//	}
//
//
//	public void Hit(int dmg){
//		print ("player hit");
//		if (currBlood <= 0) {
//			currBlood = 0;
//		} else {
//			currBlood -= dmg;
//		}
//	int tempBlood = currBlood / max_Blood;
//
//	}


}
