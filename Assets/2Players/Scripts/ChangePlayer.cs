using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	Text player1Text;
	Text player2Text;
	Text dualControlText;
	GameObject helpText;
	// Use this for initialization
	void Start () {
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player1Text = GameObject.Find ("Player1Text").GetComponent<Text> ();
		player2Text = GameObject.Find ("Player2Text").GetComponent<Text> ();
		dualControlText = GameObject.Find ("DualControlText").GetComponent<Text> ();
		helpText = GameObject.Find ("HelpText");

		player1.GetComponent<PlatformerCharacterFollower> ().SetObjectToFollow (player2);
		player2.GetComponent<PlatformerCharacterFollower> ().SetObjectToFollow (player1);

		SetPlayer (true);
	}

	void SetPlayer(bool first)
	{
		bool control = first;
		bool follow = !first;

		player1.GetComponent<Platformer2DUserControl> ().enabled = control;
		player1.GetComponent<PlatformerCharacterFollower> ().enabled = follow;
		player1.GetComponent<Platformer2DDualControl> ().enabled = false;
		player1Text.color = first ? Color.red : Color.white;
		
		player2.GetComponent<Platformer2DUserControl> ().enabled = !control;
		player2.GetComponent<PlatformerCharacterFollower> ().enabled = !follow;
		player2.GetComponent<Platformer2DDualControl> ().enabled = false;
		player2Text.color = first ? Color.white : Color.red;

		dualControlText.color = Color.white;
		helpText.SetActive (false);
	}

	void SetDualMode()
	{
		//disable all other scripts
		player1.GetComponent<Platformer2DUserControl> ().enabled = false;
		player1.GetComponent<PlatformerCharacterFollower> ().enabled = false;

		player2.GetComponent<Platformer2DUserControl> ().enabled = false;
		player2.GetComponent<PlatformerCharacterFollower> ().enabled = false;

		//set colors
		player1Text.color = Color.white;
		player2Text.color = Color.white;
		dualControlText.color = Color.red;

		player1.GetComponent<Platformer2DDualControl> ().enabled = true;
		player1.GetComponent<Platformer2DDualControl> ().SetMode (true);
		player2.GetComponent<Platformer2DDualControl> ().enabled = true;
		player2.GetComponent<Platformer2DDualControl> ().SetMode (false);

		helpText.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SetPlayer (true);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SetPlayer (false);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SetDualMode();
		}
	}
}
