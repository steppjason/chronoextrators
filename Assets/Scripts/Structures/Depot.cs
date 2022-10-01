using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depot : MonoBehaviour
{
	public int resourceAmount = 5;

	public float time = 0;

	void Start()
	{
		GameManager.Instance.ResourceManager.depotResource += resourceAmount;
		GameManager.Instance.UIManager.depotResourceText.text =
			GameManager.Instance.ResourceManager.depotResourceUsed + "/" + GameManager.Instance.ResourceManager.depotResource.ToString();
	}

	void Destroy()
	{
		GameManager.Instance.ResourceManager.depotResource -= resourceAmount;
		GameManager.Instance.UIManager.depotResourceText.text =
			GameManager.Instance.ResourceManager.depotResourceUsed + "/" + GameManager.Instance.ResourceManager.depotResource.ToString();

		// Destroy(gameObject);
	}
}
