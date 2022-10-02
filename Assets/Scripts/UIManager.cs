using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	public TMP_Text chronoResourceText;
	public TMP_Text depotResourceText;
	public TMP_Text refineryResourceText;
	public TMP_Text timerText;


	void Update()
	{
		//UpdateButtons();
	}

	void UpdateButtons()
	{
		int chronoResource = GameManager.Instance.ResourceManager.chronoResource;

		if (chronoResource < GameManager.Instance.ResourceManager.extractorStructure.resourceCost)
			GameManager.Instance.ResourceManager.extractorButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.extractorButton.interactable = true;

		if (chronoResource < GameManager.Instance.ResourceManager.depotStructure.resourceCost)
			GameManager.Instance.ResourceManager.depotButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.depotButton.interactable = true;

		if (chronoResource < GameManager.Instance.ResourceManager.barracksStructure.resourceCost)
			GameManager.Instance.ResourceManager.barracksButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.barracksButton.interactable = true;

		if (chronoResource < GameManager.Instance.ResourceManager.factoryStructure.resourceCost)
			GameManager.Instance.ResourceManager.factoryButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.factoryButton.interactable = true;

		if (chronoResource < GameManager.Instance.ResourceManager.refineryStructure.resourceCost)
			GameManager.Instance.ResourceManager.refineryButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.refineryButton.interactable = true;

		if (chronoResource < GameManager.Instance.ResourceManager.towerStructure.resourceCost)
			GameManager.Instance.ResourceManager.towerButton.interactable = false;
		else
			GameManager.Instance.ResourceManager.towerButton.interactable = true;
	}
}
