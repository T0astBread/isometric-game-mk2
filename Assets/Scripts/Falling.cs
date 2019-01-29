using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
	private const float DEATH_TIMEOUT = .1f;

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
				StartCoroutine(StartDeathTimer());
			}
		}
	}

	private IEnumerator StartDeathTimer()
	{
		Debug.Log(gameObject.name + " is not grounded - starting death timer");

		float waitStartTime = Time.time;
		yield return new WaitUntil(() => Time.time - waitStartTime > DEATH_TIMEOUT || this.groundTilesTouched > 0);

		Debug.Log("Death timer on " + gameObject.name + " stopped");

		if (this.groundTilesTouched == 0)
		{
			Debug.Log(gameObject.name + " has not touched ground since the start of the death timer - it will die now");
			Die();
		}
	}

	private void Die()
	{
		this.animator.SetBool("is_falling", true);
		this.animator.IncrementCounter("movement_locks");
		this.deathBehaviour.Die("Consumed by the depths");
	}
}
