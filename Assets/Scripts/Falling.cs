using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
	private Animator animator;
	private Death deathBehaviour;
	private int groundTilesTouched = 0;

	void Start()
	{
		this.animator = GetComponentInParent<Animator>();
		this.deathBehaviour = GetComponentInParent<Death>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Ground")
		{
			this.groundTilesTouched++;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.name == "Ground")
		{
			this.groundTilesTouched--;

			if (this.groundTilesTouched == 0)
			{
				this.animator.SetBool("is_falling", true);
				this.animator.IncrementCounter("movement_locks");
				this.deathBehaviour.Die();
			}
		}
	}
}
