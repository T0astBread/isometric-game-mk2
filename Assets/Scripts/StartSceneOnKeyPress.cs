using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneOnKeyPress : MonoBehaviour
{
	public string key = "r";
	public string sceneName;
	public bool resetScore;

	void Update()
	{
		if (Input.GetKeyUp(this.key))
		{
			SceneManager.LoadScene(this.sceneName, LoadSceneMode.Single);

			if (this.resetScore)
			{
				GameObject.FindObjectOfType<ScoreKeeper>().ResetScore();
			}
		}
	}
}
