using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindGameObjectAndSetAsTarget : MonoBehaviour
{
	public string targetObjectName;

	void Start()
	{
		GameObject target = GameObject.Find(this.targetObjectName);

		GetComponents<MonoBehaviour>()
			.Where(c => c is ITargetBehaviour)
			.ToList()
			.ForEach(c => (c as ITargetBehaviour).target = target);
	}
}
