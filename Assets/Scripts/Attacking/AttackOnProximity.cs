using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack)), RequireComponent(typeof(ChooseAttackType))]
public class AttackOnProximity : MonoBehaviour, ITargetBehaviour
{
	public GameObject target { get; set; }
	public float minDistanceForAttack = 1.5f;
	private float attackDelayMin = .1f;
	private float attackDelayMax = .25f;

	private Attack attackBehaviour;
	private ChooseAttackType chooseAttack;

	IEnumerator Start()
	{
		this.attackBehaviour = GetComponent<Attack>();
		this.chooseAttack = GetComponent<ChooseAttackType>();

		while(true)
		{
			float distance = Vector2.Distance(transform.position, target.transform.position);

			if(distance <= this.minDistanceForAttack)
			{
				yield return new WaitForSeconds(Random.Range(this.attackDelayMin, this.attackDelayMax));
				this.attackBehaviour.DoAttack(this.chooseAttack.Choose());
			}

			yield return null;
		}
	}

	void Update()
	{
	}
}
