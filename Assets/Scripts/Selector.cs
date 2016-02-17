using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {


	public GameObject[] select;
	public GameObject show;
	public int i =0;

	// Use this for initialization
	void Start () {
	
		Instantiate (select [i], transform.position, Quaternion.identity);
		//show.name = "showBlock";
	}

	void deleteOld()
	{
		show = GameObject.FindGameObjectWithTag ("Selected");
		GameObject.Destroy (show);
	}

	void showBlock(){

		deleteOld ();

	 Instantiate (select [i], transform.position, Quaternion.identity);
		//show.name = "showBlock";

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E) && i == 6) 
		{
			i = 0;
			showBlock ();
		}
	
		else if (Input.GetKeyDown (KeyCode.E) && i<=5 && i >= 0) 
		{
			i++;
			showBlock ();
		}
		
		else if (Input.GetKeyDown (KeyCode.Q) && i == 0)
		{
			i = 6;
			showBlock ();
		}

		else if (Input.GetKeyDown (KeyCode.Q) && i >= 1 && i <= 6) 
		{
			i--;
			showBlock ();
		}

	}
}
