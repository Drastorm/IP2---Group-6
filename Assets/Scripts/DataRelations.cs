using UnityEngine;
using System.Collections;

public class DataRelations : MonoBehaviour 
{
	public float musicVol = 0.5f;
	public float sfxVol = 0.5f;
	public bool showTimer = true;
	public bool showInstructions = true;

	void Start () 
	{
		DontDestroyOnLoad (this);
	}

	void Update ()
	{
		GameObject player = GameObject.Find ("Player");
		if (player != null)
		{

			AudioSource playerVolume = player.GetComponent<AudioSource> ();
			playerVolume.audio.volume = sfxVol;
		}

		GameObject mainCamera = GameObject.Find ("Main Camera");
		if (mainCamera != null)
		{
			AudioSource volume = mainCamera.GetComponent<AudioSource> ();
			volume.audio.volume = sfxVol;
		}

		GameObject backgroundMusic = GameObject.Find ("BackgroundMusic");
		if (backgroundMusic != null)
		{
			AudioSource musicVolume = backgroundMusic.GetComponent<AudioSource> ();
			musicVolume.audio.volume = musicVol;
		}

		audio.volume = musicVol;
	}
}