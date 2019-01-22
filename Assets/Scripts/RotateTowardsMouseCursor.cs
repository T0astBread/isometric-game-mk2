using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouseCursor : MonoBehaviour
{
	void Update()
	{
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		var mouseAngle = Vector2.SignedAngle(Vector2.up, mousePosition);

		transform.rotation = Quaternion.AngleAxis(mouseAngle, Vector3.forward);
	}
}
