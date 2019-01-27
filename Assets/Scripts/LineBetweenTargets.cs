using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineBetweenTargets : MonoBehaviour
{
	public GameObject t1, t2;

	private LineRenderer lineRenderer;
	private List<GameObject> targets;
	private List<Animator> targetAnimators;
	private List<Vector3> targetFeetOffsets;

	void Start()
	{
		this.lineRenderer = GetComponent<LineRenderer>();

		this.targets = new List<GameObject> { this.t1, this.t2 };
		this.targetAnimators = this.targets
			.Select(target => target.GetComponent<Animator>())
			.Where(animator => animator != null)
			.ToList();
		this.targetFeetOffsets = this.targets
			.Select(target => new
			{
				target,
				feet = target.GetComponent<FeetPosition>()
			})
			.Select(o => o.feet == null ? Vector3.zero : (Vector3)o.feet.feetOffset)
			.ToList();
	}

	void Update()
	{
		if (AllTargetsCanMove())
		{
			var positions = new Vector3[this.targets.Count];
			for (int i = 0; i < positions.Length; i++)
			{
				positions[i] = this.targets[i].transform.position + this.targetFeetOffsets[i];
			}
			this.lineRenderer.SetPositions(positions);
		}
	}

	private bool AllTargetsCanMove()
	{
		return this.targetAnimators.All(animator => animator.GetInteger("movement_locks") <= 0);
	}
}
