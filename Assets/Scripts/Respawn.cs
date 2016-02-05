using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
	public GameObject player;

	public void StartRespawn ()
	{
		StartCoroutine (RespawnPlayer ());
	}
	
	IEnumerator RespawnPlayer ()
	{
		yield return new WaitForSeconds (1f);
		Instantiate(player, transform.position, transform.rotation);
	}
}