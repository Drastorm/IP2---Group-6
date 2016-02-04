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
		if (otherObject.gameObject.tag == "Block")
		{
			//StartCoroutine (OnHit ());
			Destroy(gameObject);
		}
	}
	
	IEnumerator OnHit ()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy(gameObject);
	}
}