using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(SpawnBackdrop))]
public class DeathScreen : MonoBehaviour
{
	public const string DEFAULT_CAUSE_OF_DEATH = "For whatever reason";

	public string causeOfDeath = DEFAULT_CAUSE_OF_DEATH;

	private TextMeshProUGUI causeOfDeathLabel;

	void Start()
	{
		this.causeOfDeathLabel = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()  // Select from all TextMeshPro labels (including prefabs)
			.Where(label => label.gameObject.scene.name != null)  // Filter out prefabs
			.Single(label => label.gameObject.name == "CauseOfDeathLabel");  // Find the CauseOfDeathLabel
		ChangeCauseOfDeath(this.causeOfDeath);
	}

	public void Show(string causeOfDeath = DEFAULT_CAUSE_OF_DEATH)
	{
		GetComponent<SpawnBackdrop>().Spawn();
		ChangeCauseOfDeath(causeOfDeath);
		gameObject.SetActive(true);
	}

	public void ChangeCauseOfDeath(string newValue)
	{
		this.causeOfDeath = newValue;
		if(this.causeOfDeathLabel != null)
		{
			this.causeOfDeathLabel.text = this.causeOfDeath;
		}
	}
}
