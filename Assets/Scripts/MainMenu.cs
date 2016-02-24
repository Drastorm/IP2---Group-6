using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	//Holds the unselected versions
	public Texture2D startUnsel;
	public Texture2D settingsUnsel;
	public Texture2D quitUnsel;

	//Holds the selected versions
	public Texture2D startSel;
	public Texture2D settingsSel;
	public Texture2D quitSel;

	//Variables to hold the graphics
	public Texture2D startHolder;
	public Texture2D settingsHolder;
	public Texture2D quitHolder;

	void OnGUI ()
	{
		//Defining the buttons - origins, width and height
		Rect startBtn = new Rect (Screen.width / 2 - 160, Screen.height / 2, 320, 50);
		Rect settingsBtn = new Rect (Screen.width / 2 - 160, Screen.height / 2 + 100, 320, 50);
		Rect quitBtn = new Rect (Screen.width / 2 - 160, Screen.height / 2 + 200, 320, 50);

		//Assigning graphics to the areas defined above
		GUI.DrawTexture (startBtn, startHolder, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (settingsBtn, settingsHolder, ScaleMode.StretchToFill, true, 0);
		GUI.DrawTexture (quitBtn, quitHolder, ScaleMode.StretchToFill, true, 0);

		//Simulating the buttons
		if (startBtn.Contains (Event.current.mousePosition))
		{
			//When the mouse is over the area defined as the start button (startBtn)
			//the graphic set to startSel is also set to startHolder 
			startHolder = startSel;
			if (Input.GetMouseButtonDown (0))
			{
				Application.LoadLevel ("GameLevel");
			}
		}
		else
		{
			//When the mouse is not over the start button area
			//the graphic set to startUnsel is also set to startHolder 
			startHolder = startUnsel;
		}

		if (settingsBtn.Contains (Event.current.mousePosition))
		{
			settingsHolder = settingsSel;
			if (Input.GetMouseButtonDown (0))
			{
				Application.LoadLevel ("Settings");
			}
		}
		else
		{
			settingsHolder = settingsUnsel;
		}

		if (quitBtn.Contains (Event.current.mousePosition))
		{
			quitHolder = quitSel;
			if (Input.GetMouseButtonDown (0))
			{
				Application.Quit ();
			}
		}
		else
		{
			quitHolder = quitUnsel;
		}
	}
}