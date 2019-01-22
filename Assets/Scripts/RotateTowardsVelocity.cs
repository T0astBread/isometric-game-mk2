using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsVelocity : MonoBehaviour
{
	private new Rigidbody2D rigidbody;

	void Start()
	{
		this.rigidbody = GetComponentInParent<Rigidbody2D>();
	}

	void Update()
	{
		if (this.rigidbody.velocity.sqrMagnitude > 0)
		{
			var velocityAngle = Vector2.SignedAngle(Vector2.up, this.rigidbody.velocity);
			transform.rotation = Quaternion.AngleAxis(velocityAngle, Vector3.forward);
		}
	}
}
