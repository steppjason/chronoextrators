using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public EnemyRange enemyRange;

	public float DEFAULT_HEALTH = 4f;
	public int attackDamage = 1;
	public float moveSpeed = 0.25f;
	public float flashDuration = 0.05f;
	public float _health;
	public bool hasTarget = false;

	public bool moving = true;


	[SerializeField] SpriteRenderer sprite;

	GameObject core;
	public GameObject _target;
	Animator animator;

	public bool _isDead = false;

	Shader _whiteFlash;
	Shader _defaultShader;

	Coroutine _coFlashWhite;
	Coroutine _coKnockback;

	void Start()
	{
		core = GameObject.Find("Core");
		animator = GetComponent<Animator>();
		_target = core;
		_whiteFlash = Shader.Find("GUI/Text Shader");
		_defaultShader = sprite.material.shader;
		_health = DEFAULT_HEALTH;
	}

	void Update()
	{
		if (!_isDead)
		{
			CheckTarget();
			if(moving && _target != null)
				Move();
		}

		if (gameObject == null || !gameObject.activeInHierarchy)
			StopAllCoroutines();
	}

	public void DealDamage(int damage)
	{
		_health -= damage;
		if (_health <= 0)
			Die();
		else
			Hit();
	}

	public void Die()
	{
		_isDead = true;
		sprite.material.shader = _defaultShader;
		animator.SetBool("Dying", true);
	}

	public void SetInactive()
	{
		_health = DEFAULT_HEALTH;
		gameObject.SetActive(false);
	}

	void CheckTarget()
	{
		if (enemyRange.targetColliders.Count > 0)
		{
			if (enemyRange.targetColliders[0].gameObject.activeInHierarchy)
			{
				_target = enemyRange.targetColliders[0].gameObject;
			}
			else
				enemyRange.targetColliders.Remove(enemyRange.targetColliders[0]);
		}
		else
		{
			if(core != null)
				_target = core;
			else
				_target = null;
		}

	}

	void Move()
	{
		animator.SetBool("Moving", true);
		Vector3 direction = (_target.transform.position - transform.position).normalized;
		if(direction.x > 0)
			sprite.flipX = false;
		else
			sprite.flipX = true;

		transform.position = transform.position + direction * moveSpeed * Time.deltaTime;
	}

	void Hit()
	{
		// GameManager.Instance.audioManager.PlaySFX(1, hitSounds[0]);
		if (_coFlashWhite != null)
			StopCoroutine(_coFlashWhite);
		_coFlashWhite = StartCoroutine(coFlashWhite());
	}

	IEnumerator coFlashWhite()
	{
		sprite.material.shader = _whiteFlash;
		yield return new WaitForSeconds(flashDuration);
		sprite.material.shader = _defaultShader;
	}

}
