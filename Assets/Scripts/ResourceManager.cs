using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
	public int chronoResource = 0;
	public int depotResource = 0;
	public int refineryResource = 0;

	public Button extractorButton;
	public Button depotButton;
	public Button barracksButton;
	public Button factoryButton;
	public Button refineryButton;
	public Button towerButton;

	public Structure extractorStructure;
	public Structure depotStructure;
	public Structure barracksStructure;
	public Structure factoryStructure;
	public Structure refineryStructure;
	public Structure towerStructure;

	void Update()
	{
		UpdateButtons();
	}

	void UpdateButtons()
	{
		if (chronoResource < extractorStructure.resourceCost)
			extractorButton.interactable = false;
		else
			extractorButton.interactable = true;

		if (chronoResource < depotStructure.resourceCost)
			depotButton.interactable = false;
		else
			depotButton.interactable = true;

		if (chronoResource < barracksStructure.resourceCost)
			barracksButton.interactable = false;
		else
			barracksButton.interactable = true;

		if (chronoResource < factoryStructure.resourceCost)
			factoryButton.interactable = false;
		else
			factoryButton.interactable = true;

		if (chronoResource < refineryStructure.resourceCost)
			refineryButton.interactable = false;
		else
			refineryButton.interactable = true;

		if (chronoResource < towerStructure.resourceCost)
			towerButton.interactable = false;
		else
			towerButton.interactable = true;
	}
}
