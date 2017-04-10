using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static float score;
	public GameController gameOver;
	public GameObject highestScore;

	Text newHighScore;
	Text text;

	void Awake ()
	{
		//初始化得分
		text = GetComponent <Text> ();
		score = 0;

		newHighScore = highestScore.GetComponent <Text> ();
	}

	void Update ()
	{
		if (!gameOver.gameOver) {
			text.text = "Score: " + (int)score;
		} else {
			//游戏结束时显示
			newHighScore.text = "Your Score: " + (int)score;
		}
	}

}
