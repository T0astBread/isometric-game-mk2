using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
	public const string DEFAULT_CAUSE_OF_DEATH = "For whatever reason";

	public string causeOfDeath = DEFAULT_CAUSE_OF_DEATH;

	private TextMeshProUGUI causeOfDeathLabel;

	void Start()
	{
		this.causeOfDeathLabel = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()
			.First(label => label.gameObject.name == "CauseOfDeathLabel");
		ChangeCauseOfDeath(this.causeOfDeath);
	}

	public void Show(string causeOfDeath = DEFAULT_CAUSE_OF_DEATH)
	{
		gameObject.SetActive(true);
		ChangeCauseOfDeath(causeOfDeath);
	}

	public void ChangeCauseOfDeath(string newValue)
	{
		this.causeOfDeath = newValue;
		this.causeOfDeathLabel.text = this.causeOfDeath;
		this.causeOfDeathLabel.gameObject.SetActive(true);
	}
}
