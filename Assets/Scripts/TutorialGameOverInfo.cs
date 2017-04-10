using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TutorialGameOverInfo : MonoBehaviour 
{
	public GameObject overlay;

	public void ShowGameOverScreen()
	{
		Time.timeScale = 0f;
		AudioListener.volume = 0f;
		overlay.SetActive (true);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
		
	public void ReStartGame()
	{		
		//重新加载游戏场景，unity5中引入了SceneManager来进行场景管理
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
