using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalkTowardsTarget)), ExecuteInEditMode]
public class Follow : MonoBehaviour
{
	public GameObject target;


	private WalkTowardsTarget walkTowardsTargetBehaviour;
	private Animator targetAnimator;

	void Start()
	{
		this.walkTowardsTargetBehaviour = GetComponent<WalkTowardsTarget>();
		ChangeTarget(this.target);
	}

	void OnEnable()
	{
		this.walkTowardsTargetBehaviour.enabled = true;
	}

	void OnDisable()
	{
		this.walkTowardsTargetBehaviour.enabled = false;
	}

	void Update()
	{
		bool shouldFollow = this.target != null && (this.targetAnimator == null || this.targetAnimator.GetInteger("movement_locks") <= 0);
		if (shouldFollow)
		{
			this.walkTowardsTargetBehaviour.target = this.target.transform.position;
		}
		this.walkTowardsTargetBehaviour.moveToTarget = shouldFollow;
	}

	public void ChangeTarget(GameObject target)
	{
		this.target = target;
		if(this.target != null)
		{
			this.targetAnimator = this.target.GetComponent<Animator>();
		}
	}
}
