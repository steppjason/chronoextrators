using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridPlacer : MonoBehaviour
{

	private SpriteRenderer _sprite;
	private bool isEnabled = true;

	public bool colliding;
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
			if (!colliding)
				Instantiate(currentSelection, gameObject.transform.position, Quaternion.identity);
			else
				Debug.Log("PLAY ERROR SOUND");
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
		if (colliding)
			_sprite.color = new Color(1, 0, 0, 1);
		else
			_sprite.color = new Color(0, 1, 0, 1);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		colliding = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		colliding = false;
	}

	public void ChangeSelection(GameObject nextSelection)
	{
		currentSelection = nextSelection;
	}

	public void ToggleCursor()
	{
		isEnabled = !isEnabled;
	}
}
