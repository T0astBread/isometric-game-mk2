using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Death : MonoBehaviour
{
	public bool activateDeathScreen;

	private Animator animator;
	private DeathScreen deathScreen;
	private bool isDead;

	void Start()
	{
		this.animator = GetComponent<Animator>();

		this.deathScreen = Resources.FindObjectsOfTypeAll<DeathScreen>()  // Get the first DeathScreen that's not a prefab (detects inactive objects)
			.First(ds => ds.gameObject.scene.name != null);  // This is to check if it's not a prefab but an instance
	}

	public void Die(string causeOfDeath = DeathScreen.DEFAULT_CAUSE_OF_DEATH)
	{
		if (this.isDead)
			return;
		this.isDead = true;
		
		DisableMovement();
		SendDieTrigger();
		ActivateDeathScreen(causeOfDeath);
		Debug.Log(gameObject.name + " is dead");
	}

	private void DisableMovement()
	{
		this.animator.IncrementCounter("movement_locks");
	}

	private void SendDieTrigger()
	{
		this.animator.SetBool("is_dead", true);
	}

	private void ActivateDeathScreen(string causeOfDeath)
	{
		if (this.activateDeathScreen)
		{
			this.deathScreen.Show(causeOfDeath);
		}
	}
}
