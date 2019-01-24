using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Attack : MonoBehaviour
{
	public float baseAttackDuration = 1;
	public int baseDamage = 1;
	public GameObject effectConnectionRedPrefab, effectConnectionGreenPrefab, effectConnectionBluePrefab;
	public GameObject damagePopupPrefab;

	private Health health;
	private Collider2D attackHitbox;
	private Animator animator;
	private FaceMouseCursor faceMouseCursorBehaviour;
	private EffectConnection effectConnectionRed, effectConnectionGreen, effectConnectionBlue;
	private GameObject worldSpaceCanvas;

	private Collider2D[] hitBuffer = new Collider2D[100];
	private int targetsHit;

	private Stack<Type> latestAttacks = new Stack<Type>();

	void Start()
	{
		this.health = GetComponent<Health>();
		this.attackHitbox = transform.Find("AttackHitbox").GetComponent<Collider2D>();
		this.animator = GetComponent<Animator>();
		this.faceMouseCursorBehaviour = GetComponent<FaceMouseCursor>();
		this.worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas");

		this.effectConnectionRed = this.effectConnectionRedPrefab.GetComponent<EffectConnection>();
		this.effectConnectionGreen = this.effectConnectionGreenPrefab.GetComponent<EffectConnection>();
		this.effectConnectionBlue = this.effectConnectionBluePrefab.GetComponent<EffectConnection>();
	}

	public void RecieveAttack(Attack attacker, Type attackType, int damage)
	{
		int attackComparison = 0;

		if (this.latestAttacks.Count != 0)
		{
			var referenceAttack = this.latestAttacks.Pop();
			attackComparison = CompareAttacks(attackType, referenceAttack);
		}

		if (attackComparison == 0)
		{
			// Take damage
			RecieveDamage(damage);
		}
		else if (attackComparison > 0)
		{
			// Take damage * 1.5
			damage = Mathf.RoundToInt(damage * 1.5f);
			RecieveDamage(damage);
		}
		else if (attackComparison < 0)
		{
			// Deal damage * 1.5
			damage = Mathf.RoundToInt(damage * 1.5f);
			attacker.RecieveDamage(damage);
		}
	}

	public void RecieveDamage(int damage)
	{
		this.health.hp -= damage;
		ShowDamageVisuals(damage);
		Debug.Log(gameObject.name + " took " + damage + " damage!");
	}

	private void ShowDamageVisuals(int damage)
	{
		var damagePopup = GameObject.Instantiate(this.damagePopupPrefab, transform.position, Quaternion.Euler(0, 0, 0));
		damagePopup.GetComponent<DamagePopup>().damagePointsToShow = damage;
		damagePopup.transform.parent = this.worldSpaceCanvas.transform;
	}

	public void DoAttack(Type type)
	{
		StartCoroutine(DoAttackAsync(type));
	}

	public IEnumerator DoAttackAsync(Type type)
	{
		if (CanAttack())
		{
			SetFaceMouseCursorEnabled(false);
			PerformTargetHitCollision();
			DealDamage(type);

			this.latestAttacks.Push(type);

			var effectsForType = GetEffectsForType(type);
			StartCoroutine(UpdateAnimator(type, this.baseAttackDuration));
			yield return ShowAttackVisuals(effectsForType, this.baseAttackDuration);

			SetFaceMouseCursorEnabled(true);
		}
	}

	private bool CanAttack()
	{
		var animatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(this.animator.GetLayerIndex("Base Layer"));
		return animatorStateInfo.IsName("Idling") || animatorStateInfo.IsName("Walking");
	}

	private void SetFaceMouseCursorEnabled(bool enabled)
	{
		if (this.faceMouseCursorBehaviour != null)
		{
			this.faceMouseCursorBehaviour.enabled = enabled;
		}
	}

	private void PerformTargetHitCollision()
	{
		var contactFilter = new ContactFilter2D();
		contactFilter.SetLayerMask(LayerMask.GetMask(new string[] { "AttackRecievingHitbox" }));
		contactFilter.useTriggers = true;
		this.targetsHit = this.attackHitbox.OverlapCollider(contactFilter, this.hitBuffer);
		for (int i = this.targetsHit; i < this.hitBuffer.Length; i++)
		{
			this.hitBuffer[i] = null;
		}
	}

	private void ForEachTargetHit(Action<GameObject> targetAction)
	{
		int targetsHit = this.targetsHit;
		GameObject target;
		for (int i = 0; i < targetsHit; i++)
		{
			target = this.hitBuffer[i].gameObject;
			if (target.transform.parent.gameObject != gameObject)
			{
				targetAction(target);
			}
		}
	}

	private void DealDamage(Type attackType)
	{
		ForEachTargetHit(target => // Target is the AttackRecievingHitbox
			target.transform.parent.gameObject.GetComponent<Attack>().RecieveAttack(this, attackType, this.baseDamage)
		);
	}

	private EffectConnection GetEffectsForType(Type attackType)
	{
		switch (attackType)
		{
			case Type.FORCE:
				return this.effectConnectionRed;
			case Type.MAGIC:
				return this.effectConnectionGreen;
			case Type.DEFENSE:
				return this.effectConnectionBlue;
			default:
				return this.effectConnectionRed;
		}
	}

	private IEnumerator UpdateAnimator(Type attackType, float attackDuration)
	{
		this.animator.SetInteger("active_attack_type", IndexOf(attackType));
		this.animator.SetFloat("active_attack_duration", 1 / attackDuration);
		yield return new WaitForSeconds(attackDuration);
		this.animator.SetInteger("active_attack_type", -1);
	}

	private IEnumerator ShowAttackVisuals(EffectConnection effectsForType, float attackDuration)
	{
		var circlePrefab = effectsForType.effectCircle;
		var circle = GameObject.Instantiate(circlePrefab, transform.position, transform.rotation);
		circle.GetComponent<StickToTarget>().target = gameObject;

		yield return new WaitForSeconds(attackDuration);

		GameObject.Destroy(circle);
	}

	public static int IndexOf(Type type)
	{
		switch (type)
		{
			case Type.FORCE:
				return 0;
			case Type.MAGIC:
				return 1;
			case Type.DEFENSE:
				return 2;
			default:
				return -1;
		}
	}

	public static Type FromIndex(int index)
	{
		switch (index)
		{
			case 0:
				return Type.FORCE;
			case 1:
				return Type.MAGIC;
			case 2:
				return Type.DEFENSE;
			default:
				throw new ArgumentOutOfRangeException("There is no attack type for index " + index);
		}
	}

	public static int CompareAttacks(Type attackType1, Type attackType2)
	{
		if (attackType1 == null || attackType2 == null || attackType1 == attackType2)
			return 0;
		else
			return AttackBeatsOther(attackType1, attackType2) ? 1 : -1;
	}

	public static bool AttackBeatsOther(Type attack, Type otherAttack)
	{
		return attack == Type.FORCE && otherAttack == Type.MAGIC ||
			attack == Type.MAGIC && otherAttack == Type.DEFENSE ||
			attack == Type.DEFENSE && otherAttack == Type.FORCE;
	}

	public enum Type
	{
		FORCE, MAGIC, DEFENSE
	}
}
