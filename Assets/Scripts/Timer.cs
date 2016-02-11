using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float timeLimit;
	//public int mSeconds;
	float seconds;
	float minutes;
	
	void OnGUI()
	{
		timeLimit -= (Time.deltaTime / 2) ;

		minutes = Mathf.Floor(timeLimit / 60);
		seconds = Mathf.Floor(timeLimit - minutes * 60);

		if(minutes < 0) 
		{
			minutes = 0;
			seconds = 0;
		}

		GUI.Label(new Rect(Screen.width / 2 - 50, 10, 2500, 30), string.Format ("{0:0}:{1:00}", minutes, seconds));
		/*
		timeLimit -= (Time.deltaTime / 2);

		minutes = Mathf.Floor (timeLimit / 60);
		seconds = timeLimit % 60;

		if(seconds > 59)
		{
			seconds = 59;
		}
		
		if(minutes < 0) 
		{
			minutes = 0;
			seconds = 0;
		}

		GUI.Label(new Rect(Screen.width / 2 - 50, 10, 2500, 25), string.Format ("{0:0}:{1:00}", minutes, seconds));
		//seconds -= (int)(Time.time);
		//seconds = seconds % 60;
		//print (minutes);
		/*
		GUI.skin.label.font = font;
		GUI.skin.label.fontSize = 25;
		GUI.color = Color.white;

		mSeconds = (int)(timeLimit -= Time.time * 1000);
		mSeconds = mSeconds % 1000;
		seconds = (int)(timeLimit -= Time.deltaTime % 60);
		minutes = (int)(timeLimit -= Time.deltaTime / 60);*/
	}
}