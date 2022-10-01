using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
	public Structure structure;

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
