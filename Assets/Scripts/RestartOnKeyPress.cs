using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnKeyPress : MonoBehaviour
{
	public string key = "r";

	void Update()
	{
		if (Input.GetKeyUp(this.key))
		{
			SceneManager.LoadScene("LevelScene", LoadSceneMode.Single);
		}
	}
}
