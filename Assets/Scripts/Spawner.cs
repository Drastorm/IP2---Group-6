using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Groups
	public GameObject[] groups;
	public int i =0;
	public float x;

	// Use this for initialization
	void Start () {
		x = -5.0f;
	}

	public void spawnNext()
	{
		Instantiate (groups [i], transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E) && i == 6) 
		{
			i = 0;
			//showBlock ();
		}
		
		else if (Input.GetKeyDown (KeyCode.E) && i<=5 && i >= 0) 
		{
			i++;
			//showBlock ();
		}
		
		else if (Input.GetKeyDown (KeyCode.Q) && i == 0)
		{
			i = 6;
			//showBlock ();
		}
		
		else if (Input.GetKeyDown (KeyCode.Q) && i >= 1 && i <= 6) 
		{
			i--;
		}

		else if (Input.GetKeyDown (KeyCode.Space) && (Time.time - x) > 4.5f)
		{
			spawnNext ();
			x = Time.time;
		}
	}
}
