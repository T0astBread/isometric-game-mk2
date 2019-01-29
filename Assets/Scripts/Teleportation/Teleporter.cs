using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Teleporter : MonoBehaviour
{
	private Animator animator;
	protected GameObject lastIntersector;

	void Start()
	{
		this.animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		this.lastIntersector = collider.gameObject.GetComponentInParent<CanBeTeleported>().gameObject;
		this.animator.SetBool("is_intersecting", true);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		this.animator.SetBool("is_intersecting", false);
	}
	
	public abstract void Teleport();
}
