using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnProximity : MonoBehaviour
{
	public GameObject target;
	public float maxDistanceToStartFollowing = 2.5f;
	public float minDistanceToStopFollowing = 7;
	public string normalWalkingBehaviourName;

	private bool isFollowing = false;
	private Follow followBehaviour;
	private MonoBehaviour normalWalkingBehaviour;

	void Start()
	{
		this.followBehaviour = GetComponent<Follow>();
		
		foreach (var monoBehaviour in GetComponents<MonoBehaviour>())
		{
			if(monoBehaviour.GetType().FullName == this.normalWalkingBehaviourName)
			{
				this.normalWalkingBehaviour = monoBehaviour;
			}
		}

		ChangeTarget(this.target);
	}

	void Update()
	{
		var distanceVec = this.target.transform.position - transform.position;
		float distance = distanceVec.magnitude;

		this.isFollowing = this.isFollowing ? // Are we following target?
			distance < this.minDistanceToStopFollowing : // If yes, should we stop?
			distance <= this.maxDistanceToStartFollowing; // If no, should we start?

		this.followBehaviour.enabled = this.isFollowing;
		if(this.normalWalkingBehaviour != null)
		{
			this.normalWalkingBehaviour.enabled = !this.isFollowing;
		}

		if(this.isFollowing)
		{
			Debug.DrawLine(transform.position, this.target.transform.position, Color.red);
		}
	}

	public void ChangeTarget(GameObject target)
	{
		this.followBehaviour.ChangeTarget(target);
	}
}
