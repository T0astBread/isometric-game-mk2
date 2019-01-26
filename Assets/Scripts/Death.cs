using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		this.animator = GetComponent<Animator>();
	}

	public void Die()
	{
		DisableMovement();
		SendDieTrigger();
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
}
