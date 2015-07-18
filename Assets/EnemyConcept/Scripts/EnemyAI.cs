using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private float enemySpeed = 5.0f;

	[SerializeField]
	private Transform playerTransform;
	
	private Rigidbody2D enemyRigidBody2D;

	void Start () {
		enemyRigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		float horizontalMovement = 0f;
		if (playerTransform.position.x < gameObject.transform.position.x)
			horizontalMovement = -1f;
		else if (playerTransform.position.x > gameObject.transform.position.x)
			horizontalMovement = 1f;
		enemyRigidBody2D.AddForce(Vector2.right * enemySpeed * horizontalMovement);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Player"))
			Application.LoadLevel (Application.loadedLevelName);
	}
}
