using UnityEngine;
using System.Collections;

[RequireComponent (typeof (P2Controller2D))]
public class Player2 : MonoBehaviour 
{
	public static Player2 player;
	public Respawn respawn;
	
	P2Controller2D controller;

	public Transform playerSprite;
	public int health = 3;
	public float movementSpeed;
	public float JumpHeight;
	public float timeToJumpApex = 0.5f;
	public float wallSlideSpeedMax = 1f;
	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;
	public bool facingRight = false;
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

	public AudioClip fire;
	public AudioClip jump;
	
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
		GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");
		respawn = respawnPoint.GetComponent<Respawn> ();

		gravity = -(2 * JumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		
		gameObject.name = "Player2";
	}
	
	void Update ()
	{
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("P2HorizontalLStick"), Input.GetAxisRaw ("P2VerticalLStick"));
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
				audio.PlayOneShot (fire);
			}
		}
		
		if (Input.GetAxisRaw ("P2Fire1") == 0)
		{
			hasFired = false;
		}

		/*
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
		*/
		if (Input.GetButtonDown ("P2Jump"))
		{
			if (wallSliding == true)
			{
				if (wallDirX == movement.x)
				{
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
					audio.PlayOneShot (jump);
				}
				else if (movement.x == 0)
				{
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
					audio.PlayOneShot (jump);
				}
				else 
				{
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
					audio.PlayOneShot (jump);
				}
			}
			
			if (controller.collisions.below)
			{
				velocity.y = jumpVelocity;
				audio.PlayOneShot (jump);
			}
		}
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		if (movement.x > 0 && !facingRight)
		{
			Flip ();
		}
		else if (movement.x < 0 && facingRight)
		{
			Flip ();
		}

		if (health <= 0)
		{
			respawn.P2StartRespawn ();
			Destroy (gameObject);
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		playerSprite.localScale *= -1;
	}
}