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
		this.causeOfDeathLabel = Resources.FindObjectsOfTypeAll<TextMeshProUGUI>()  // Select from all TextMeshPro labels (including prefabs)
			.Where(label => label.gameObject.scene.name != null)  // Filter out prefabs
			.Single(label => label.gameObject.name == "CauseOfDeathLabel");  // Find the CauseOfDeathLabel
		ChangeCauseOfDeath(this.causeOfDeath);
	}

	public void Show(string causeOfDeath = DEFAULT_CAUSE_OF_DEATH)
	{
		SpawnDarkBackdrop();
		ChangeCauseOfDeath(causeOfDeath);
		gameObject.SetActive(true);
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
		if(this.causeOfDeathLabel != null)
		{
			this.causeOfDeathLabel.text = this.causeOfDeath;
		}
	}
}
