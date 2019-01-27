using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
	private int _score;
	public int score
	{
		get { return _score; }
		set
		{
			_score = value;
			UpdateHighScoreIfNeeded();
		}
	}

	public int highScore { get; private set; }

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		this.highScore = PlayerPrefs.GetInt("high_score");
	}

	void OnApplicationQuit()
	{
		Debug.Log("Saving highscore to PlayerPrefs...");
		UpdateHighScoreInPlayerPrefs();
	}

	public void AddToScore(int amount)
	{
		int prevScore = this.score;
		this.score += amount;
		Debug.Log("Added " + amount + " to score resulting in a total of " + this.score + " (previously " + prevScore + ")");
	}

	// public void DivideScore(float divisor)
	// {
	// 	int prevScore = this.score;
	// 	this.score = Mathf.FloorToInt(this.score / divisor);
	// 	Debug.Log("Divided score by " + divisor + " resulting in a new score of " + this.score + " (previously " + prevScore + ")");
	// }

	public bool HighScoreIsOvertaken()
	{
		return this.score > this.highScore;
	}

	private void UpdateHighScoreInPlayerPrefs()
	{
		PlayerPrefs.SetInt("high_score", this.highScore);
	}

	private void UpdateHighScoreIfNeeded()
	{
		if(HighScoreIsOvertaken())
		{
			this.highScore = this.score;
		}
	}
}
