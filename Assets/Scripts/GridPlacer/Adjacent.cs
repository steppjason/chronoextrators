using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjacent : MonoBehaviour
{
	public GridPlacer gridPlacer;

	void OnTriggerStay2D(Collider2D other)
	{
		gridPlacer.adjacent = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		gridPlacer.adjacent = false;
	}
}
