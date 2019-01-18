using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{
	public GameObject target;
	public float maxDistance = 0;

	private MovementControls targetMovementControlBehaviour;

	void Start()
	{
		this.targetMovementControlBehaviour = this.target.GetComponent<MovementControls>();
	}

	void Update()
	{
		if(this.targetMovementControlBehaviour == null || this.targetMovementControlBehaviour.canMove)
		{
			var distanceVec = (Vector2)(this.target.transform.position - transform.position);
			var distance = distanceVec.magnitude;
			var distanceToMove = distance - this.maxDistance;

			if(distanceToMove > .001f)
			{
				transform.position += (Vector3)(distanceVec.normalized * distanceToMove);
			}
		}
	}
}
