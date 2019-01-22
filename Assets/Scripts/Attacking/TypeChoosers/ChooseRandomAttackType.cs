using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomAttackType : ChooseAttackType
{
	public override Attack.Type Choose()
	{
		int randomIndex = Mathf.FloorToInt(Random.Range(0, 3));
		if(randomIndex == 3) // Unity's randoms are inclusive-end. That sucks.
		{
			randomIndex = 2;
		}

		return Attack.FromIndex(randomIndex);
	}
}
