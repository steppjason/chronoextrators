using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor : MonoBehaviour
{
	private float time;

	public int RESOURCE_INCREASE = 10;

	private void Start()
	{
		time = GameManager.Instance.time;
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time > 10)
		{
			GameManager.Instance.ResourceManager.chronoResource += RESOURCE_INCREASE;
			GameManager.Instance.UIManager.chronoResourceText.text = GameManager.Instance.ResourceManager.chronoResource.ToString();
			time = 0;
		}
	}
}
