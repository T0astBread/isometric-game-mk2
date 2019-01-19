using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalk : MonoBehaviour
{
	public float sleepTimeMin = .3f;
	public float sleepTimeMax = 3;
	public float walkTimeMin = 1;
	public float walkTimeMax = 3;
	public float walkSpeed = 3;
	public Vector2 feetOffset = Vector2.zero;

	private Rigidbody2D rigidbody;

	IEnumerator Start()
	{
		this.rigidbody = GetComponent<Rigidbody2D>();

		while(true)
		{
			float sleepTime = Random.Range(this.sleepTimeMin, this.sleepTimeMax);
			yield return new WaitForSeconds(sleepTime);

			float walkAngle = Random.Range(0, 360);
			this.rigidbody.velocity = Vector2.up.Rotate(walkAngle) * this.walkSpeed;

			float walkTime = Random.Range(this.walkTimeMin, this.walkTimeMax);
			yield return new WaitForSeconds(walkTime);

			this.rigidbody.velocity = Vector2.zero;
		}
	}

	void Update()
	{
		var feetPosition = (Vector2)transform.position + this.feetOffset;
		var raycastOrigin2D = feetPosition + this.rigidbody.velocity.normalized * .1f; // where the feet will be in .1 units

		var raycastOrigin = new Vector3(raycastOrigin2D.x, raycastOrigin2D.y, 2);
		var ray = new Ray(raycastOrigin, Vector3.back);

		int layerMask = 1 << LayerMask.NameToLayer("Ground");

		var hit = Physics2D.GetRayIntersection(ray, 5, layerMask);
		Color debugLineColor = Color.green;
		if(hit.collider == null)
		{
			this.rigidbody.velocity *= -.8f;
			debugLineColor = Color.red;
		}

		Debug.DrawLine(feetPosition, raycastOrigin2D, debugLineColor);
	}
}
