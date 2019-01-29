using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalTeleporter : Teleporter
{
	public string sceneName;

	public override void Teleport()
	{
		SceneManager.LoadScene(this.sceneName, LoadSceneMode.Single);
	}
}
