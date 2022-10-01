using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
	public Structure structure;
	public int resourceAmount = 5;

	void Start()
	{
		structure = GetComponent<Structure>();
		GameManager.Instance.ResourceManager.refineryResource += resourceAmount;
		GameManager.Instance.UIManager.refineryResourceText.text =
			GameManager.Instance.ResourceManager.refineryResourceUsed + "/" + GameManager.Instance.ResourceManager.refineryResource.ToString();
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
		GameManager.Instance.ResourceManager.refineryResource -= resourceAmount;
		GameManager.Instance.UIManager.refineryResourceText.text =
			GameManager.Instance.ResourceManager.refineryResourceUsed + "/" + GameManager.Instance.ResourceManager.refineryResource.ToString();
		structure.Die();
	}

}

