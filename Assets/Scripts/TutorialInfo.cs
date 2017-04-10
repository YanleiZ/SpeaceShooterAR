using UnityEngine;
using UnityEngine.UI;

public class TutorialInfo : MonoBehaviour 
{

	public GameObject overlay;

	void Awake()
	{
			ShowLaunchScreen();
	
	}
		
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
        AudioListener.volume = 0f;
	    overlay.SetActive (true);
	}
		
	public void QuitGame()
	{
		Application.Quit ();
	}
		
	public void StartGame()
	{		
		overlay.SetActive (false);
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
	}

}
