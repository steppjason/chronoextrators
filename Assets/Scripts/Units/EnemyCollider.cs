using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
	public Enemy enemy;
	public float attackRate = 0.5f;
	public int attackDamage = 1;

	float _attackRateTime = 0f;

	private void Update()
	{
		_attackRateTime += Time.deltaTime;
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (_attackRateTime > attackRate)
		{
			if (other.tag == "Structure")
			{
				enemy.moving = false;
				other.GetComponent<Structure>().TakeDamage(attackDamage);
				_attackRateTime = 0f;
			}

			if (other.gameObject.tag == "Chrononaut")
			{
				enemy.moving = false;
				other.gameObject.transform.parent.GetComponent<ChronoNaut>().TakeDamage(attackDamage);
				_attackRateTime = 0f;
			}

			if (other.gameObject.tag == "Mech")
			{
				enemy.moving = false;
				//other.transform.parent.GetComponent<Mech>().TakeDamage(attackDamage);
				_attackRateTime = 0f;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Chrononaut")
		{
			enemy.moving = false;
			other.gameObject.transform.parent.GetComponent<ChronoNaut>().TakeDamage(attackDamage);
			_attackRateTime = 0f;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		enemy.moving = true;
	}
}
