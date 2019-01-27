using System;
using System.Collections;
using System.Collections.Generic;
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
		this.deathScreen = Resources.FindObjectsOfTypeAll<DeathScreen>()[0];
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
		this.animator.SetTrigger("die");
	}

	private void ActivateDeathScreen(string causeOfDeath)
	{
		if (this.activateDeathScreen)
		{
			this.deathScreen.Show(causeOfDeath);
		}
	}
}
