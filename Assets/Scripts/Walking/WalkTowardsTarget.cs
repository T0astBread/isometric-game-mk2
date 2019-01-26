using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(FeetPosition))]
public class WalkTowardsTarget : MonoBehaviour
{
	public Vector2 target;
	public bool moveToTarget = true;
	public float movementSpeed = 5;
	public float stopDistance = 1;

	private Animator animator;
	private new Rigidbody2D rigidbody;
	private FeetPosition feet;

	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.rigidbody = GetComponent<Rigidbody2D>();
		this.feet = GetComponent<FeetPosition>();
	}

	void Update()
	{
		if(this.animator.GetInteger("movement_locks") <= 0)
		{
			PointVelocityToTarget();
			TurnVelocityToStayGrounded();
		}
		else if(this.animator.GetInteger("velocity_write_locks") <= 0)
		{
			this.rigidbody.velocity = Vector2.zero;
		}
	}

	private void PointVelocityToTarget()
	{
		Vector2 newVelocity = Vector2.zero;
		if (this.moveToTarget)
		{
			Vector2 distanceVec = this.target - (Vector2)transform.position;
			if (distanceVec.magnitude > this.stopDistance)
			{
				newVelocity = distanceVec.normalized * this.movementSpeed;
			}
		}
		this.rigidbody.velocity = newVelocity;
	}

	private void TurnVelocityToStayGrounded()
	{
		int degreesRotated = 0;
		int degreesPerRotation = 5;
		while(!WillBeGrounded() && degreesRotated < 360)
		{
			degreesRotated += degreesPerRotation;
			this.rigidbody.velocity = this.rigidbody.velocity.Rotate(degreesPerRotation);
		}
	}

	private bool WillBeGrounded()
	{
		var raycastOrigin2D = this.feet.feetPosition + this.rigidbody.velocity.normalized * .1f; // where the feet will be in .1 units
		var raycastOrigin = new Vector3(raycastOrigin2D.x, raycastOrigin2D.y, 2);
		var ray = new Ray(raycastOrigin, Vector3.back);

		int layerMask = 1 << LayerMask.NameToLayer("Ground");

		var hit = Physics2D.GetRayIntersection(ray, 5, layerMask);
		bool willBeGrounded = hit.collider != null;

		Debug.DrawLine(this.feet.feetPosition, raycastOrigin2D, willBeGrounded ? Color.green : Color.red);

		return willBeGrounded;
	}
}
