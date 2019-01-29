using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTeleporter : Teleporter
{
	public LocalTeleporter target;

	public override void Teleport()
	{
		if (this.lastIntersector != null && this.target != null)
		{
			var targetPos = this.target.transform.position;
			this.lastIntersector.transform.position = new Vector3(targetPos.x, targetPos.y, this.lastIntersector.transform.position.z);
		}
	}
}
