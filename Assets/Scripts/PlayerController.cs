using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float movementSpeed;
	public float moveHorizontal;
	public float defaultSpeed;
	public float jumpVelocity;

	public bool grounded = false;
	public Transform groundCheckA;
	public Transform groundCheckB;
	public LayerMask whatIsGround;

	void Update () 
	{
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

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * movementSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}