using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
	public Enemy enemy;
	public List<Collider2D> targetColliders = new List<Collider2D>();

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Structure" ||
				other.gameObject.tag == "Chrononaut" ||
				other.gameObject.tag == "Mech")
			targetColliders.Add(other);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Structure" ||
				other.gameObject.tag == "Chrononaut" ||
				other.gameObject.tag == "Mech")
			targetColliders.Remove(other);
	}
}
