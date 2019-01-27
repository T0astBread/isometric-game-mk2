using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HighScoreLabel : MonoBehaviour
{
	private ScoreKeeper scoreKeeper;
	private TextMeshProUGUI label;

	void Start()
	{
		this.scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
		this.label = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		this.label.text = this.scoreKeeper.highScore.ToString();
	}
}
