using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StartSceneOnKeyPress))]
public class RestartOnKeyPress : MonoBehaviour
{
	void Start()
	{
		GetComponent<StartSceneOnKeyPress>().sceneName = gameObject.scene.name;
	}
}
