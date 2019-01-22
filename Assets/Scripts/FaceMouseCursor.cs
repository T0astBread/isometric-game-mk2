using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DirectionalAnimationController))]
public class FaceMouseCursor : MonoBehaviour
{
	private DirectionalAnimationController directionalAnimationController;

	void Start()
	{
		this.directionalAnimationController = GetComponent<DirectionalAnimationController>();
	}

	void Update()
	{
		var mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var relMousePosition = mousePositionInWorld - transform.position;
		this.directionalAnimationController.LookAt(relMousePosition);

		Debug.DrawLine(transform.position, mousePositionInWorld, Color.yellow);
	}
}
