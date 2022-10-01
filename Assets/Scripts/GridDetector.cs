using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDetector : MonoBehaviour
{
	public GridPlacer gridPlacer;

	void OnTriggerEnter2D(Collider2D other)
	{
		gridPlacer.colliding = false;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		gridPlacer.colliding = true;
	}
}
