using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScoreOnDeath : MonoBehaviour
{
	private Animator animator;

	IEnumerator Start()
	{
		this.animator = GetComponent<Animator>();

		yield return new WaitUntil(() => this.animator.GetBool("is_dead"));
		GameObject.FindObjectOfType<ScoreKeeper>().ResetScore();
	}
}
