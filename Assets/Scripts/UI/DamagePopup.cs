using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
	public int damagePointsToShow = 0;

	void Start()
	{
		GetComponentInChildren<TMPro.TextMeshProUGUI>().text = this.damagePointsToShow.ToString();
	}
}
