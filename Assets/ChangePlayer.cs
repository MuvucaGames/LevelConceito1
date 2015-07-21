using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityEngine.UI;

public class ChangePlayer : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject player1Text;
	GameObject player2Text;
	GameObject dkText;
	GameObject broText;
	// Use this for initialization
	void Start () {
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
		player1Text = GameObject.Find ("Player1Text");
		player2Text = GameObject.Find ("Player2Text");
		dkText = GameObject.Find ("ModeDonkeyKong");
		broText = GameObject.Find ("ModeBroforce");

		player1.GetComponent<PlatformerCharacterFollower> ().SetObjectToFollow (player2);
		player2.GetComponent<PlatformerCharacterFollower> ().SetObjectToFollow (player1);
	}

	void SetPlayer(bool first)
	{
		bool control = first;
		bool follow = !first;


		player1.GetComponent<Platformer2DUserControl> ().enabled = control;
		player1.GetComponent<PlatformerCharacterFollower> ().enabled = follow;
		player1Text.GetComponent<Text> ().color = first ? Color.red : Color.white;
		
		player2.GetComponent<Platformer2DUserControl> ().enabled = !control;
		player2.GetComponent<PlatformerCharacterFollower> ().enabled = !follow;
		player2Text.GetComponent<Text>().color = first ? Color.white : Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SetPlayer (true);
//			player1.GetComponent<Platformer2DUserControl> ().enabled = true;
//			player1.GetComponent<PlatformerCharacterFollower> ().enabled = false;
//			player1Text.GetComponent<Text>().color = Color.red;
//
//			player2.GetComponent<Platformer2DUserControl> ().enabled = false;
//			player2.GetComponent<PlatformerCharacterFollower> ().enabled = true;
//			player2Text.GetComponent<Text>().color = Color.white;
		}
		else if( Input.GetKeyDown(KeyCode.Alpha2)) {
			SetPlayer (false);
//			player1.GetComponent<Platformer2DUserControl> ().enabled = false;
//			player1.GetComponent<PlatformerCharacterFollower> ().enabled = true;
//			player1Text.GetComponent<Text>().color = Color.white;
//
//			player2.GetComponent<Platformer2DUserControl> ().enabled = true;
//			player2.GetComponent<PlatformerCharacterFollower> ().enabled = false;
//			player2Text.GetComponent<Text>().color = Color.red;
		}

	}
}
