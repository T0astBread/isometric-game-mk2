using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int maxHp;

	private int _hp;
	public int hp
	{
		get { return _hp; }
		set
		{
			_hp = value;
			if(_hp <= 0) {
				_hp = 0;
				DieIfPossible();
			}
		}
	}

	public float relativeHp
	{
		get
		{
			return (float) this.hp / this.maxHp;
		}
	}

	void Start()
	{
		this.hp = this.maxHp;
	}

	private void DieIfPossible()
	{
		var death = GetComponent<Death>();
		if(death != null)
		{
			death.Die("Died in battle");
		}
	}
}
