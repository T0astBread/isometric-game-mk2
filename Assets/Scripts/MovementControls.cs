using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{

	public float movementSpeed = 5f;
	public bool canMove = true;

	private Animator animator;
	private Rigidbody2D rigidbody;

	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		var animatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(this.animator.GetLayerIndex("Base Layer"));
		bool isAttacking = animatorStateInfo.IsTag("Attacking");

		Vector2 velocity = Vector2.zero;

		if (!isAttacking && this.canMove)
		{
			var velX = Input.GetAxis("Horizontal");
			var velY = Input.GetAxis("Vertical");

			velocity = new Vector2(velX, velY);
			velocity = velocity.normalized * this.movementSpeed;
		}

		UpdateRigidBody(velocity);
	}

	private void UpdateRigidBody(Vector2 velocity)
	{
		this.rigidbody.velocity = velocity;
	}
}
