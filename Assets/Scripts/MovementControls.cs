using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{

	public float movementSpeed = 5f;
	public bool canMove = true;

	private Rigidbody2D rigidbody;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
		this.animator = GetComponent<Animator>();
	}

	void Update()
	{
		Vector2 velocity;

		if (this.canMove)
		{
			var velX = Input.GetAxis("Horizontal");
			var velY = Input.GetAxis("Vertical");

			velocity = new Vector2(velX, velY);
			velocity = velocity.normalized * this.movementSpeed;
		}
		else
		{
			velocity = Vector2.zero;
		}
		
		UpdateRigidBody(velocity);
		UpdateAnimator(velocity);
	}

	private void UpdateRigidBody(Vector2 velocity)
	{
		this.rigidbody.velocity = velocity;
	}

	private void UpdateAnimator(Vector2 velocity)
	{
		this.animator.SetFloat("velocity_x", velocity.x);
		this.animator.SetFloat("velocity_y", velocity.y);
	}
}
