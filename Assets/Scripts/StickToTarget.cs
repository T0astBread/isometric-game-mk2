using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTarget : MonoBehaviour
{
	public GameObject target;
	public Vector2 offset;
	public float maxDistance;

	private Rigidbody2D rigidbody;
	private Animator targetAnimator;

	void Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();
		ChangeTarget(target);
	}

	void Update()
	{
		// if (this.targetAnimator == null || this.targetAnimator.GetBool("can_move"))
		// {
			var distanceVec = (Vector2)(this.target.transform.position - transform.position) + this.offset;
			float distance = distanceVec.magnitude;
			float distanceToMove = distance - this.maxDistance;

			if (distanceToMove > .01f)
			{
				distanceVec = distanceVec.normalized * distanceToMove;
				transform.position += new Vector3(distanceVec.x, distanceVec.y, 0);
			}
		// }
	}

	public void ChangeTarget(GameObject target)
	{
		this.target = target;
		this.targetAnimator = this.target.GetComponent<Animator>();
	}
}
