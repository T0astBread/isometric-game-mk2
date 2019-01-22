using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectConnection : MonoBehaviour
{
	public GameObject effectCircle;
	public GameObject effectRay;
	public GameObject target1, target2;

	private GameObject circle1Inst, circle2Inst, rayInst;

	void Start()
	{
		this.circle1Inst = CreateCircle(this.target1);
		this.circle2Inst = CreateCircle(this.target2);
		this.rayInst = CreateRay();
	}

	private GameObject CreateCircle(GameObject target)
	{
		var circle = GameObject.Instantiate(this.effectCircle);
		circle.GetComponent<StickToTarget>().target = target;
		return circle;
	}

	private GameObject CreateRay()
	{
		var ray = GameObject.Instantiate(this.effectRay);
		var lineBetweenTargetsBehaviour = ray.GetComponent<LineBetweenTargets>();
		lineBetweenTargetsBehaviour.t1 = this.target1;
		lineBetweenTargetsBehaviour.t2 = this.target2;
		return ray;
	}
}
