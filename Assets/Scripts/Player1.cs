using UnityEngine;
using System.Collections;

[RequireComponent (typeof (P1Controller2D))]
public class Player1 : MonoBehaviour 
{
	/*
	public float movementSpeed;
	public float moveHorizontal;
	public float defaultSpeed;
	public float jumpVelocity;

	public bool facingRight = true;

	public bool grounded = false;
	public bool wallContact = false;
	public Transform groundCheckA;
	public Transform groundCheckB;
	public Transform leftWallCheckA;
	//public Transform leftWallCheckB;
	//public Transform rightWallCheckA;
	public Transform rightWallCheckB;
	public LayerMask whatIsGround;
	public LayerMask whatIsWall;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
*/
	public static Player1 player;

	P1Controller2D controller;

	public float movementSpeed = 5f;
	public float JumpHeight = 5f;
	public float timeToJumpApex = 0.5f;
	public float wallSlideSpeedMax = 1f;
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public bool facingRight = true;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;

	float velocityXSmoothing;
	float accelerationTimeAirborne = 0.175f;
	float accelerationTimeGrounded = 0;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private bool hasFired = false;

	void Awake ()
	{
		if (player == null)
		{
			DontDestroyOnLoad (gameObject);
			player = this;
		}
		else if (player != this)
		{
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		controller = GetComponent<P1Controller2D>();

		gravity = -(2 * JumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);

		gameObject.name = "Player1";
	}

	void Update ()
	{
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("P1Horizontal"), Input.GetAxisRaw ("P1Vertical"));
		int wallDirX = (controller.collisions.left)? -1: 1;

		float targetVelocityX = movement.x * movementSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);

		bool wallSliding = false;

		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
		{
			wallSliding = true;
			if (velocity.y < -wallSlideSpeedMax)
			{
				velocity.y = -wallSlideSpeedMax;
			}
		}

		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		if (Input.GetAxisRaw ("P1Fire1") != 0 && Time.time > nextFire && wallSliding == false)
		{
			if (hasFired == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				hasFired = true;
			}
		}

		if (Input.GetAxisRaw ("P1Fire1") == 0)
		{
			hasFired = false;
		}

		if (Input.GetButtonDown ("P1Jump"))
		{
			if (wallSliding == true)
			{
				if (wallDirX == movement.x)
				{
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				}
				else if (movement.x == 0)
				{
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				}
				else 
				{
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				}
			}

			if (controller.collisions.below)
			{
				velocity.y = jumpVelocity;
			}
		}

		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		//float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		if (movement.x > 0 && !facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 0, 0);
		}
		else if (movement.x < 0 && facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 180, 0);
		}
	}

	/*
	void Update () 
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded == true)
		{
			grounded = false;
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpVelocity));
		}

		//GetAxisRaw is used as it returns either 1 or 0 which results in snappier movement
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
	}

	void FixedUpdate ()
	{
		//grounded returns true when objects with layer selected for whatIsGround is detected in the area between groundCheckA and B
		//and when player's y velocity is 0
		grounded = Physics2D.OverlapArea (groundCheckA.position, groundCheckB.position, whatIsGround) && GetComponent<Rigidbody2D>().velocity.y == 0;
		wallContact = Physics2D.OverlapArea (leftWallCheckA.position, rightWallCheckB.position, whatIsWall);

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if (moveHorizontal > 0 &&!facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 0, 0);
		}
		else if (moveHorizontal < 0 &&facingRight)
		{
			Flip ();
			shotSpawn.rotation = Quaternion.Euler (0, 180, 0);
		}
	}
*/
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}