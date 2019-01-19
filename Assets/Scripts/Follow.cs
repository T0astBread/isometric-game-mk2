using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalkTowardsTarget))]
public class Follow : MonoBehaviour
{
	public GameObject target;


	private WalkTowardsTarget walkTowardsTargetBehaviour;
	private MovementControls targetMovementControls;

	void Start()
	{
		this.walkTowardsTargetBehaviour = GetComponent<WalkTowardsTarget>();
		ChangeTarget(this.target);
	}

	void Update()
	{
		bool shouldFollow = this.target != null && (this.targetMovementControls == null || this.targetMovementControls.canMove);
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
			this.targetMovementControls = this.target.GetComponent<MovementControls>();
		}
	}
}
