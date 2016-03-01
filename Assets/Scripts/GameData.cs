using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour 
{
	public static GameData gameData;

	public float volume = 0.5f;

	void Awake ()
	{
		if (gameData == null)
		{
			DontDestroyOnLoad (gameObject);
			gameData = this;
		}
		else if (gameData != this)
		{
			Destroy (gameObject);
		}
	}

	void Start () 
	{
		DontDestroyOnLoad (this);
	}

	void Update ()
	{
		GameObject player1 = GameObject.FindGameObjectWithTag ("Player");
		if (player1 != null)
		{
			AudioSource playerVolume = player1.GetComponent<AudioSource> ();
			playerVolume.audio.volume = volume;
		}

		GameObject player2 = GameObject.FindGameObjectWithTag ("Player2");
		if (player2 != null)
		{
			AudioSource playerVolume = player2.GetComponent<AudioSource> ();
			playerVolume.audio.volume = volume;
		}
		/*
		GameObject mainCamera = GameObject.Find ("Main Camera");
		if (mainCamera != null)
		{
			AudioSource volume = mainCamera.GetComponent<AudioSource> ();
			volume.audio.volume = sfxVol;
		}
		*/
	}
}