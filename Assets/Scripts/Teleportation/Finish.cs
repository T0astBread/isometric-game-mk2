using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Finish : Teleporter
{
	public override void Teleport()
	{
		var victoryScreen = Resources.FindObjectsOfTypeAll<VictoryScreen>()
			.Single(screen => screen.gameObject.scene.name != null);
		victoryScreen.gameObject.SetActive(true);

		DestroyAllEnemies();
		DisableMovement();
		DisableFurtherCharging();
	}

	private void DestroyAllEnemies()
	{
		foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			GameObject.Destroy(obj);
		}
	}

	private void DisableMovement()
	{
		GameObject.Find("Player").GetComponent<Animator>().IncrementCounter("movement_locks");
	}

	private void DisableFurtherCharging()
	{
		GetComponent<Animator>().SetBool("can_charge", false);
	}
}
