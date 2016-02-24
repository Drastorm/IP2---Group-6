using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour 
{
	public float speed;
	
	void Start () 
	{
		gameObject.name = "Shot";
		GetComponent<Rigidbody2D>().velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D (Collider2D otherObject)
	{
		/*
		if (otherObject.gameObject.tag == "Enemy")
		{
			StartCoroutine (OnHit ());
		}
		*/
		if (otherObject.gameObject.tag == "Block" || otherObject.gameObject.tag == "Arena")
		{
			//StartCoroutine (OnHit ());
			Destroy (gameObject);
		}
		if (otherObject.gameObject.tag == "Player")
		{
			Player1.player.health--;
			Destroy (gameObject);
		}
		if (otherObject.gameObject.tag == "Player2")
		{
			Player2.player.health--;
			Destroy (gameObject);
		}
	}
	
	IEnumerator OnHit ()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy(gameObject);
	}
}