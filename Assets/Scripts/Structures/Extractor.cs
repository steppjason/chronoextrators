using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
	public Structure structure;
	private float time;

	public int resourceIncrease = 10;

	private void Start()
	{
		time = GameManager.Instance.time;
		structure = GetComponent<Structure>();
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time > 10)
		{
			GameManager.Instance.ResourceManager.chronoResource += resourceIncrease;
			GameManager.Instance.UIManager.chronoResourceText.text = GameManager.Instance.ResourceManager.chronoResource.ToString();
			time = 0;
		}

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
