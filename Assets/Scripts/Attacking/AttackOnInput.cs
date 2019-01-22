using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class AttackOnInput : MonoBehaviour
{
	private Attack attack;

	void Start()
	{
		this.attack = GetComponent<Attack>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			this.attack.DoAttack(Attack.Type.DEFENSE);
		}
		else if(Input.GetMouseButtonDown(0))
		{
			this.attack.DoAttack(Attack.Type.FORCE);
		}
		else if(Input.GetMouseButtonDown(1))
		{
			this.attack.DoAttack(Attack.Type.MAGIC);
		}
	}
}
