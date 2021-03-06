﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{

	public float movementSpeed = 5f;

	private Animator animator;
	private Rigidbody2D rigidbody;

	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Vector2 velocity = Vector2.zero;

		// if (!Utils.IsAttackingOrDying(this.animator) && this.canMove)
		if (this.animator.GetInteger("movement_locks") <= 0)
		{
			var velX = Input.GetAxis("Horizontal");
			var velY = Input.GetAxis("Vertical");

			velocity = new Vector2(velX, velY);
			velocity = velocity.normalized * this.movementSpeed;
		}

		if(this.animator.GetInteger("velocity_write_locks") <= 0)
		{
			UpdateRigidBody(velocity);
		}
	}

	private void UpdateRigidBody(Vector2 velocity)
	{
		this.rigidbody.velocity = velocity;
	}
}
