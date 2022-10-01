using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour 
{
	public int resourceAmount = 5;

	void Start()
	{
		GameManager.Instance.ResourceManager.refineryResource += resourceAmount;
		GameManager.Instance.UIManager.refineryResourceText.text =
			GameManager.Instance.ResourceManager.refineryResourceUsed + "/" + GameManager.Instance.ResourceManager.refineryResource.ToString();
	}

	void Destroy()
	{
		GameManager.Instance.ResourceManager.refineryResource -= resourceAmount;
		GameManager.Instance.UIManager.refineryResourceText.text =
			GameManager.Instance.ResourceManager.refineryResourceUsed + "/" + GameManager.Instance.ResourceManager.refineryResource.ToString();
	}
}
