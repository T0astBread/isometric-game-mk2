using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackStateBehaviour : StateMachineBehaviour
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		SetMovementActive(animator, false);

		float knockbackStrength = animator.GetFloat("knockback_strength");
		if(!CheckKnockbackBounds(animator, ref knockbackStrength))
		{
			animator.SetTrigger("cancel_knockback");
			return;
		}

		var forceVec = (Vector2)animator.transform.position - animator.GetVector2("knockback_origin");
		forceVec = forceVec.normalized * knockbackStrength;

		Debug.Log("Applying knockback with strength " + knockbackStrength + " to " + animator.gameObject.name);
		
		animator.GetComponent<Rigidbody2D>().AddForce(forceVec);
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		SetMovementActive(animator, true);
	}

	private void SetMovementActive(Animator animator, bool active)
	{
		animator.ModifyCounter("movement_locks", !active);
		animator.ModifyCounter("velocity_write_locks", !active);
	}

	private bool CheckKnockbackBounds(Animator animator, ref float knockbackStrength)
	{
		var knockbackLimits = animator.gameObject.GetComponent<KnockbackLimits>();
		if(knockbackLimits != null)
		{
			if(knockbackStrength < knockbackLimits.minKnockbackStrength)
			{
				return false;
			}
			knockbackStrength = Mathf.Min(knockbackStrength, knockbackLimits.maxKnockbackStrength);
		}
		return true;
	}
}
