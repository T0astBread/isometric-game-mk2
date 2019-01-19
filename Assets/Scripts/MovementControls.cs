using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{

	public float movementSpeed = 5f;
	public bool canMove = true;

	private Rigidbody2D rigidbody;

	void Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
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
	}

	private void UpdateRigidBody(Vector2 velocity)
	{
		this.rigidbody.velocity = velocity;
	}
}
