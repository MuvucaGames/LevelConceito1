using UnityEngine;
using System.Collections;

public class ReturnToLoader : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("LevelLoader");
		}
	}
}
