using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Factory : MonoBehaviour
{
	public TMP_Text capacity;
	public Structure structure;
	public int qty;
	public int maxLimit;

	void Start()
	{
		structure = GetComponent<Structure>();
	}

	void Update()
	{
		if (structure.health <= 0)
		{
			Destroy();
		}
	}

	void Destroy()
	{
		structure.Die();
	}
}
