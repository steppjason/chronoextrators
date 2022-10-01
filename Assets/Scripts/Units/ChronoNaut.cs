using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoNaut : MonoBehaviour
{
	public int health;
	public Vector3 spawnPoint = new Vector3(0, 0, 0);
	public float radius = 0.1f;
	public float moveSpeed = 0.2f;
	public Vector3 targetPos;

	public bool shooting;

	private float _wanderTime;

	void Start()
	{
		ChangeTarget();
	}

	void Update()
	{
		if(!shooting)
			Wander();
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	public void Wander()
	{
		_wanderTime += Time.deltaTime;
		if (_wanderTime > 3)
		{
			_wanderTime = 0;
			ChangeTarget();
		}

		float distance = Vector2.Distance(transform.position, targetPos);
		if (distance > 0.1f)
		{
			Vector3 direction = spawnPoint - targetPos;
			direction.Normalize();
			Debug.Log(direction);
			transform.position = transform.position + direction.normalized * moveSpeed * Time.deltaTime;
		}
	}

	public void ChangeTarget()
	{
		targetPos = new Vector3(spawnPoint.x + Random.Range(-radius, radius), spawnPoint.y + Random.Range(-radius, radius), gameObject.transform.position.z);
	}
}
