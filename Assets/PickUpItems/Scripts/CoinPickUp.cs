using UnityEngine;
using System.Collections;
using UnityStandardAssets;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;

public class CoinPickUp : MonoBehaviour {

	public int pointToAdd;

	void OnTriggerEnter2D (Collider2D other) {

		if (other.GetComponent<PlatformerCharacter2D> () == null)
			return;

		ScoreManager.AddPoints (pointToAdd);

		Destroy (gameObject);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
