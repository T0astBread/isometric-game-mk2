using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		this.animator = GetComponent<Animator>();
	}

	public void ApplyKnockback(Vector2 origin, float strength)
	{
		this.animator.SetVector2("knockback_origin", origin);
		this.animator.SetFloat("knockback_strength", strength);
		this.animator.SetTrigger("knock_back");
	}
}
