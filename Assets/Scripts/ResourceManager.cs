using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
	public int chronoResource = 0;
	public int depotResource = 0;
	public int refineryResource = 0;

	public int depotResourceUsed = 0;
	public int refineryResourceUsed = 0;

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

}
