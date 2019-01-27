using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DeathScreen : MonoBehaviour
{
	public const string DEFAULT_CAUSE_OF_DEATH = "For whatever reason";

	public string causeOfDeath = DEFAULT_CAUSE_OF_DEATH;
	public GameObject darkBackdropPrefab;

	private TextMeshProUGUI causeOfDeathLabel;
	private bool backdropHasBeenSpawned;

	void Start()
	{
		this.causeOfDeathLabel = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()
			.First(label => label.gameObject.name == "CauseOfDeathLabel");
		ChangeCauseOfDeath(this.causeOfDeath);
	}

	public void Show(string causeOfDeath = DEFAULT_CAUSE_OF_DEATH)
	{
		SpawnDarkBackdrop();
		gameObject.SetActive(true);
		ChangeCauseOfDeath(causeOfDeath);
	}

	private void SpawnDarkBackdrop()
	{
		if(!this.backdropHasBeenSpawned)
		{
			this.backdropHasBeenSpawned = true;
			var backdrop = GameObject.Instantiate(this.darkBackdropPrefab, Vector3.zero, Quaternion.AngleAxis(0, Vector3.right));
			backdrop.GetComponent<StickToTarget>().target = GameObject.Find("Player");
		}
	}

	public void ChangeCauseOfDeath(string newValue)
	{
		this.causeOfDeath = newValue;
		this.causeOfDeathLabel.text = this.causeOfDeath;
		this.causeOfDeathLabel.gameObject.SetActive(true);
	}
}
