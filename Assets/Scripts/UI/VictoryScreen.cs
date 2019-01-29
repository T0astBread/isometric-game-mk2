using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpawnBackdrop))]
public class VictoryScreen : MonoBehaviour
{
	void Start()
	{
		GetComponent<SpawnBackdrop>().Spawn();
	}
}
