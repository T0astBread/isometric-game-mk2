using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorVelocityFromRigidbody : MonoBehaviour
{
	private Animator animator;
	private Rigidbody2D rigidbody;

	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		this.animator.SetFloat("velocity_x", this.rigidbody.velocity.x);
		this.animator.SetFloat("velocity_y", this.rigidbody.velocity.y);
	}
}
