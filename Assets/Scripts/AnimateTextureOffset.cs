using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateTextureOffset : MonoBehaviour
{
	public float speed = 1f;

	private Renderer renderer;

	void Start()
	{
		this.renderer = GetComponent<Renderer>();
	}

	void Update()
	{
		this.renderer.material.SetTextureOffset("_MainTex", new Vector2(Time.time * this.speed, 0));
	}
}
