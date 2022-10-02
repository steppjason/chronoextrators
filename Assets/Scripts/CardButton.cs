using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
	public float fillAmount = 0f;
	public float rechargeTime = 10f;
	public bool isUsed = false;

	float time;

	Image cardImage;
	public Button button;
	public Structure structure;


	private void Start()
	{
		cardImage = GetComponent<Image>();
		UseCharge();
		button.interactable = false;
	}

	void Update()
	{
		if (isUsed)
		{
			time += Time.deltaTime;
			fillAmount = time / rechargeTime;
			if (fillAmount >= 1)
			{
				isUsed = false;
				fillAmount = 1;
			}
		}

		if(structure.resourceCost > GameManager.Instance.ResourceManager.chronoResource || fillAmount < 1)
			button.interactable = false;
		else
			button.interactable = true;

		cardImage.fillAmount = fillAmount;
	}

	public void UseCharge()
	{
		button.interactable = false;
		isUsed = true;
		fillAmount = 0;
		time = 0;
	}
}
