using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyPress : MonoBehaviour
{
	public string key = "r";
	public bool resetScore;

	void Update()
	{
		if (Input.GetKeyUp(this.key))
		{
			SceneManager.LoadScene(gameObject.scene.name, LoadSceneMode.Single);

			if (this.resetScore)
			{
				GameObject.FindObjectOfType<ScoreKeeper>().ResetScore();
			}
		}
	}
}
