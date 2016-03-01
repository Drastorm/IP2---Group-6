using UnityEngine;
using System.Collections;

public class P1BowRotate : MonoBehaviour 
{
	public Player1 player;

	void Update () 
	{
		float angle = Mathf.Atan2 (Input.GetAxis ("P1VerticalRStick") * (player.facingRight? 1 : -1), Input.GetAxis ("P1HorizontalRStick")) * Mathf.Rad2Deg;
		//float angle = Mathf.Atan2 (Input.GetAxis ("P1VerticalRStick") * (player.facingRight? 1: -1), Input.GetAxis ("P1HorizontalRStick") * (player.facingRight? 1: -1)) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler ((player.facingRight? 0 : 180), 0, (player.facingRight? angle : -angle));
		transform.rotation = Quaternion.Euler ((player.facingRight? 0 : 180), 0, angle);

		/*
		if (player.facingRight == false && angle == 0)
		{
			transform.rotation = Quaternion.Euler (0, 180, angle);
		}
		/*
		if (player.facingRight == false && angle > 0 || angle < 0)
		{
			float invertedAngle = Mathf.Atan2 (Input.GetAxis ("P1VerticalRStick") * -1, Input.GetAxis ("P1HorizontalRStick")) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler (180, 0, invertedAngle);
		}
		/*
		var pos = Camera.main.WorldToScreenPoint(transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		*/
	}
}