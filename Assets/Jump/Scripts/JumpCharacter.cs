using UnityEngine;
using System.Collections;

public class JumpCharacter : MonoBehaviour {

	public float walkSpeed;
	public float runSpeed;

	private float timeToJumpApex;
	public float maxJumpHeight = 4;
	public float minJumpHeight = 2;
	private float maxJumpVelocity;
	private float minJumpVelocity;

	public Transform groundCheck;
	private float groundRadius = 0.2f;
	private int groundLayer;

	private bool facingRight = true;
	private bool grounded = false;
	private Rigidbody2D rb;
	private Animator animator;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		animator = gameObject.GetComponent<Animator> ();

		groundLayer = 1 << 8;

		float gravity = Mathf.Abs (Physics2D.gravity.y);
		Debug.Log (gravity);

		timeToJumpApex = Mathf.Sqrt ((float)(2 * maxJumpHeight / gravity));
		maxJumpVelocity = (float)(gravity * timeToJumpApex);
		minJumpVelocity = Mathf.Sqrt((float)(2 * gravity * minJumpHeight));
	}

	void Update()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);
		animator.SetBool ("Ground", grounded);
		
		if (Input.GetKey (KeyCode.Space) && grounded) {
			Vector2 vel = new Vector2(rb.velocity.x, maxJumpVelocity);
			rb.velocity = vel;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			Vector2 vel = new Vector2(rb.velocity.x, minJumpVelocity);
			if(rb.velocity.y > vel.y)
				rb.velocity = vel;
		}
	}

	void FixedUpdate()
	{
		//Set the parameter vSpeed on the animator
		animator.SetFloat ("vSpeed", rb.velocity.y);
//---------------------------------------------------------------------------------------------------------------------
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
