using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetPosition : MonoBehaviour
{
	public Vector2 feetOffset;
	public Vector2 feetPosition
	{
		get
		{
			return (Vector2)transform.position + this.feetOffset;
		}
	}
}
