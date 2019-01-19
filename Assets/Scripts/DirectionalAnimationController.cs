using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAnimationController : MonoBehaviour
{
	public RuntimeAnimatorController northEastAC, northWestAC, southEastAC, southWestAC;

	private Animator animator;
	private RuntimeAnimatorController[] controllers;

	void Start()
	{
		this.animator = GetComponent<Animator>();
		this.controllers = new RuntimeAnimatorController[] {
			this.northEastAC,
			this.northWestAC,
			this.southEastAC,
			this.southWestAC
		};
	}

	public void LookAt(Vector2 directionToLookAt)
	{
		int directionIndex = 0;
		directionIndex += directionToLookAt.x > 0 ? 0 : 1;
		directionIndex += directionToLookAt.y > 0 ? 0 : 2;
		this.animator.runtimeAnimatorController = this.controllers[directionIndex];
	}
}
