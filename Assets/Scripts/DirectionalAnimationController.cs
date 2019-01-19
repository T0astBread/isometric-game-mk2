using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAnimationController : MonoBehaviour
{
	public RuntimeAnimatorController northEastAC, northWestAC, southEastAC, southWestAC;
	public float threshold = .01f;

	private Rigidbody2D rigidbody;
	private Animator animator;
	private RuntimeAnimatorController[] controllers;

	void Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
		this.animator = GetComponent<Animator>();
		this.controllers = new RuntimeAnimatorController[] {
			this.northEastAC,
			this.northWestAC,
			this.southEastAC,
			this.southWestAC
		};
	}

	void Update()
	{
		if (this.rigidbody.velocity.magnitude > this.threshold)
		{
			int directionIndex = 0;
			directionIndex += this.rigidbody.velocity.x > 0 ? 1 : 0;
			directionIndex += this.rigidbody.velocity.y > 0 ? 0 : 2;
			this.animator.runtimeAnimatorController = this.controllers[directionIndex];
		}
	}
}
