using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoNautCollider : MonoBehaviour
{
	private bool _invunerable;
	private float _invunerableTime;

	public ChronoNaut chronoNaut;
	public float invunerableLength = 1f;

	void Update()
	{
		CheckInvunerable();
	}

	void CheckInvunerable()
	{
		if (_invunerable)
		{
			_invunerableTime += Time.deltaTime;
			if (_invunerableTime > invunerableLength)
			{
				_invunerableTime = 0;
				_invunerable = false;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Enemy" && !_invunerable)
		{
			_invunerable = !_invunerable;
			chronoNaut.TakeDamage(other.GetComponent<Enemy>().attackDamage);
		}
	}
}
