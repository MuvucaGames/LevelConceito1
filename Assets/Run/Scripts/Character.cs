using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float walkSpeed;
	public float runSpeed;

	private bool facingRight = true;
	private Rigidbody2D rb;
	private Animator animator;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		//Get the horizontal input
		float h = Input.GetAxis ("Horizontal");

		//Set velocity to the character based if he is pressing the run button
		//run button = left shift
		//Fire3 is setted on the InputManager of Unity
		if (Input.GetButton("Fire3")) {
			rb.velocity = new Vector2(runSpeed * h, rb.velocity.y);
		} else {
			rb.velocity = new Vector2(walkSpeed * h, rb.velocity.y);
		}

		//Call the Flip method when the player faces the opposite direction
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		//Set the parameter on the animator
		animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

		//Reload on the scene
		if (transform.position.y < -5)
			Application.LoadLevel (Application.loadedLevel);
	}

	//Flip the sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
