using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	public void Die()
	{
		DisableMovement();
		Debug.Log("Dead");
	}

	private void DisableMovement()
	{
		var movementBehaviour = GetComponent<MovementControls>();
		if(movementBehaviour != null)
		{
			movementBehaviour.canMove = false;
		}
	}
}
