using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HealthBar : MonoBehaviour
{
	public float width;

	private Health health;
	private LineRenderer lineRenderer;

	void Start()
	{
		this.health = GetComponentInParent<Health>();
		this.lineRenderer = GetComponent<LineRenderer>();
	}

	void Update()
	{
		this.lineRenderer.SetPositions(new Vector3[] {
			GetStartPosition(),
			GetEndPosition()
		});
	}

	private Vector3 GetStartPosition()
	{
		return transform.position - GetHalfWidth();
	}

	private Vector3 GetEndPosition()
	{
		return transform.position + new Vector3(GetRelativeSize(), 0, 0) - GetHalfWidth();
	}

	private Vector3 GetHalfWidth()
	{
		return new Vector3(this.width / 2f, 0, 0);
	}

	private float GetRelativeSize()
	{
		return this.width * this.health.relativeHp;
	}
}
