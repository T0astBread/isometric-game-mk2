using System;
using UnityEngine;

public static class AnimatorExtension
{
	public static void SetVector2(this Animator animator, string key, Vector2 value)
	{
		animator.SetFloat(key + "_x", value.x);
		animator.SetFloat(key + "_y", value.y);
	}

	public static Vector2 GetVector2(this Animator animator, string key)
	{
		return new Vector2(animator.GetFloat(key + "_x"), animator.GetFloat(key + "_y"));
	}

	public static void ModifyCounter(this Animator animator, string key, bool increment)
	{
		animator.SetInteger(key, animator.GetInteger(key) + (increment ? 1 : -1));
	}

	public static void IncrementCounter(this Animator animator, string key)
	{
		animator.ModifyCounter(key, true);
	}

	public static void DecrementCounter(this Animator animator, string key)
	{
		animator.ModifyCounter(key, false);
	}
}