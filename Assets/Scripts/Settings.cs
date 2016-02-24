using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour 
{
	public Texture2D volume;

	public Texture2D mainMenuUnsel;
	public Texture2D mainMenuSel;

	public Texture2D mainMenuHolder;

	public GUIStyle sliderBar;
	public GUIStyle sliderThumb;
	public float soundVolume = 0.5f;
	//public float sfxVolume;
	//public AudioClip scroll;
	//public AudioClip confirmClick;
	//private bool scrollHasPlayed = false;

	void OnGUI ()
	{
		/*
		GameObject data = GameObject.Find ("GameData");
		if (data != null) 
		{
			DataRelations changes = data.GetComponent<DataRelations> ();

			musicVolume = changes.musicVol;
			sfxVolume = changes.sfxVol;

			musicVolume = GUI.HorizontalSlider (new Rect(Screen.width / 2 - 300, Screen.height / 2 - 75, 100, 10), musicVolume, 0.00f, 1.00f);
			sfxVolume = GUI.HorizontalSlider (new Rect(Screen.width / 2 - 300, Screen.height / 2 + 50, 100, 10), sfxVolume, 0.00f, 1.00f);

			changes.musicVol = musicVolume;
			changes.sfxVol = sfxVolume;
		}
		*/
		Rect volumeLbl = new Rect (Screen.width / 2 - 160, Screen.height / 2 - 200, 320, 50);
		soundVolume = GUI.HorizontalSlider (new Rect(Screen.width / 2 - 160, Screen.height / 2 - 100, 320, 50), soundVolume, 0.00f, 1.00f, sliderBar, sliderThumb);
		Rect mainMenuBtn = new Rect (Screen.width / 2 - 160, Screen.height / 2 + 200, 320, 50);

		GUI.DrawTexture (volumeLbl, volume, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (mainMenuBtn, mainMenuHolder, ScaleMode.StretchToFill, true, 0);

		if (mainMenuBtn.Contains (Event.current.mousePosition))
		{
			mainMenuHolder = mainMenuSel;
			if (Input.GetMouseButtonDown (0))
			{
				Application.LoadLevel ("MainMenu");
			}
		}
		else
		{
			mainMenuHolder = mainMenuUnsel;
		}
	}
}