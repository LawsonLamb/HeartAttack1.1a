using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	Text credit;
	Vector2 pos;
	// Use this for initialization
	void Start () {

		credit = GetComponent<Text> ();
		pos = gameObject.transform.localPosition;
		pos.y = -590;
		gameObject.transform.localPosition = pos;
		CreditText ();
	}
	
	// Update is called once per frame
	void Update () {
	
		pos.y += 1;

		if (pos.y >= 590) {
			pos.y = -590;
		}
		gameObject.transform.localPosition = pos;

	}

	void CreditText () {
		credit.text = "Heart Attack \n\n" +
			"Brought to you from the minds of\nOluwakayode Akingbade & Lawson Lamb \n\n" +
			"Lead Artist:\nBen Russell\n\n" +
			"Other Artist:\nStephen Scoville & Oluwakayode Akingbade\n\n" +
			"Music created by:\n\n" +
			"Sound Effects by:\n\n" +
			"Lead Coder:\nLawson Lamb\n\n" +
			"Other Coders:\nOluwakayode Akingbade\n\n" +
			"Game Design & Concept by:\nOluwakayode Akingbade & Lawson Lamb\n\n" +
			"Class:\nKennesaw State University CGDD 4814 Capstone\n\n";
	}

	public void ReturnButton() {
		Application.LoadLevel (0);
	}
}
