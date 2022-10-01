using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridPlacer : MonoBehaviour
{

	private SpriteRenderer _sprite;
	private bool isEnabled = true;

	public bool colliding;
	public bool adjacent;
	public Tilemap tilemap;
	public GameObject currentSelection;

	void Start()
	{
		_sprite = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		DisplayCursor();
		PlaceStructure();
		ChangeColor();
	}

	void PlaceStructure()
	{
		if (Input.GetMouseButtonDown(0) && isEnabled)
		{
			int resource = GameManager.Instance.ResourceManager.chronoResource;
			int resourceCost = currentSelection.GetComponent<Structure>().resourceCost;

			if (colliding)
				Debug.Log("PLAY COLLIDING ERROR");
			else if (resource < resourceCost)
				Debug.Log("INSUFFICIENT RESOURCES ERROR");
			else if (!adjacent)
				Debug.Log("NOT ADJACENT");
			else
			{
				GameManager.Instance.ResourceManager.chronoResource -= currentSelection.GetComponent<Structure>().resourceCost;
				GameManager.Instance.UIManager.chronoResourceText.text = GameManager.Instance.ResourceManager.chronoResource.ToString();
				Instantiate(currentSelection, gameObject.transform.position, Quaternion.identity);
			}
		}
	}

	void DisplayCursor()
	{
		if (isEnabled)
		{
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3Int cellPos = tilemap.WorldToCell(worldPos);
			Vector3 cellCenter = tilemap.GetCellCenterWorld(cellPos);
			gameObject.transform.position = new Vector3(cellCenter.x, cellCenter.y, 0);
		}
		else
		{
			gameObject.transform.position = new Vector3(-1000, -1000, 0);
		}
	}

	void ChangeColor()
	{
		if (!adjacent || colliding || currentSelection.GetComponent<Structure>().resourceCost > GameManager.Instance.ResourceManager.chronoResource)
			_sprite.color = new Color(1, 0, 0, 1);
		else
			_sprite.color = new Color(0, 1, 0, 1);
	}

	public void ChangeSelection(GameObject nextSelection)
	{
		currentSelection = nextSelection;
		_sprite.sprite = currentSelection.GetComponent<SpriteRenderer>().sprite;
	}

	public void DisableCursor()
	{
		isEnabled = false;
	}

	public void EnableCursor()
	{
		isEnabled = true;
	}
}
