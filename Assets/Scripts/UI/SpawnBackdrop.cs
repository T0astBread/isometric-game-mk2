using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBackdrop : MonoBehaviour
{
	public GameObject backdropPrefab;

	private bool backdropHasBeenSpawned;

	public void Spawn()
	{
		if(!this.backdropHasBeenSpawned)
		{
			this.backdropHasBeenSpawned = true;
			var backdrop = GameObject.Instantiate(this.backdropPrefab, Vector3.zero, Quaternion.AngleAxis(0, Vector3.right));
			backdrop.GetComponent<StickToTarget>().target = GameObject.Find("Player");
		}
	}
}
