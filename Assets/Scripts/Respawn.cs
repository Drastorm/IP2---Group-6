using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;

	public void P1StartRespawn ()
	{
		StartCoroutine (P1Respawn ());
	}

	public void P2StartRespawn ()
	{
		StartCoroutine (P2Respawn ());
	}
	
	IEnumerator P1Respawn ()
	{
		yield return new WaitForSeconds (1f);
		Instantiate(player1, transform.position, transform.rotation);
	}

	IEnumerator P2Respawn ()
	{
		yield return new WaitForSeconds (1f);
		Instantiate(player2, transform.position, transform.rotation);
	}
}