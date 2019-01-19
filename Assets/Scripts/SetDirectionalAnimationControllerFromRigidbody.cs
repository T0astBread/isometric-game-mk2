using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDirectionalAnimationControllerFromRigidbody : MonoBehaviour
{
	public float threshold = .01f;

	private Rigidbody2D rigidbody;
	private DirectionalAnimationController directionalAnimationController;

	void Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
		this.directionalAnimationController = GetComponent<DirectionalAnimationController>();
	}

	void Update()
	{
		if(this.rigidbody.velocity.magnitude > this.threshold)
		{
			this.directionalAnimationController.LookAt(this.rigidbody.velocity);
		}
	}
}
