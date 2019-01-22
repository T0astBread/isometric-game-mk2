using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
	public static bool IsAttackingOrDying(Animator animator)
	{
		var animatorStateInfo = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer"));
		return animatorStateInfo.IsTag("Attacking") || animatorStateInfo.IsTag("Dying");
	}
}