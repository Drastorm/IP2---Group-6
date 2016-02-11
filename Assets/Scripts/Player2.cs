using UnityEngine;
using System.Collections;

[RequireComponent (typeof (P2Controller2D))]
public class Player2 : MonoBehaviour 
{
	public static Player2 player;
	
	P2Controller2D controller;
	
	public float movementSpeed;
	public float JumpHeight;
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
		controller = GetComponent<P2Controller2D>();
		
		gravity = -(2 * JumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		//print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
		
		gameObject.name = "Player2";
	}
	
	void Update ()
	{
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("P2Horizontal"), Input.GetAxisRaw ("P2Vertical"));
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
		
		if (Input.GetAxisRaw ("P2Fire1") != 0 && Time.time > nextFire && wallSliding == false)
		{
			if (hasFired == false)
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				hasFired = true;
			}
		}
		
		if (Input.GetAxisRaw ("P2Fire1") == 0)
		{
			hasFired = false;
		}
		
		if (Input.GetButtonDown ("P2Jump"))
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

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}