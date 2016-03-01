using UnityEngine;
using System.Collections;

public class P2BowRotate : MonoBehaviour 
{
	public Player2 player;
	
	void Update () 
	{
		float angle = Mathf.Atan2 (Input.GetAxis ("P2VerticalRStick") * (player.facingRight? 1 : -1), Input.GetAxis ("P2HorizontalRStick")) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ((player.facingRight? 0 : 180), 0, angle);

		/*
		if (player.facingRight == false && angle == 0)
		{
			transform.rotation = Quaternion.Euler (0, 180, angle);
		}
		*/
	}
}