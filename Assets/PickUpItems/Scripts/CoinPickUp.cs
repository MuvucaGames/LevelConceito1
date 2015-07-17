using UnityEngine;
using System.Collections;

public class CoinPickUp : MonoBehaviour {

	public int pointToAdd;

	void OnTriggerEnter2D (Collider other) {

		//if (other.GetComponent<PlatformerCharacter2D> () == null)
			//return;

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
