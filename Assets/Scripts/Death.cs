using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	public void Die()
	{
		DisableMovement();
		SendDieTrigger();
		Debug.Log(gameObject.name + " is dead");
	}

	private void DisableMovement()
	{
		var movementBehaviour = GetComponent<MovementControls>();
		if(movementBehaviour != null)
		{
			movementBehaviour.canMove = false;
		}
	}

	private void SendDieTrigger()
	{
		GetComponent<Animator>().SetTrigger("die");
	}
}
