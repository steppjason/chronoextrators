using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoNautRange : MonoBehaviour 
{
	public ChronoNaut chronoNaut;
	public List<Collider2D> enemyColliders = new List<Collider2D>();

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
			enemyColliders.Add(other);
	}
}
