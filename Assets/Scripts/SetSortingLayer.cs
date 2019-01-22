using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetSortingLayer : MonoBehaviour
{
	public string sortingLayer;

	void Start()
	{
		GetComponent<Renderer>().sortingLayerName = this.sortingLayer;
	}
}
