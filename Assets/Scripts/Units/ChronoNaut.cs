using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoNaut : MonoBehaviour
{

	public ChronoNautCollider chronoNautCollider;
	public ChronoNautRange chronoNautRange;

	public int health;
	public Vector3 spawnPoint = new Vector3(0, 0, 0);
	public float wanderRadius = 0.1f;
	public float moveSpeed = 0.2f;
	public int attackDamage = 1;
	public float fireRate = 0.5f;
	public float flashDuration = 0.05f;

	public Barracks barracks;
	public Factory factory;

	[Space(50)]
	public Vector3 targetPos;
	public bool hasTarget = false;
	public bool shooting;
	public bool moving;

	[SerializeField] SpriteRenderer sprite;


	bool firstRun = true;
	float _wanderTime;
	float _weaponFireElapsedTime = 0.5f;
	Animator _animator;
	GameObject _enemyTarget;

	Shader _whiteFlash;
	Shader _defaultShader;

	GameObject _target;
	Coroutine _coFireAI;
	Coroutine _coFlashWhite;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_whiteFlash = Shader.Find("GUI/Text Shader");
		_defaultShader = sprite.material.shader;
	}

	void Start()
	{
		ChangeTarget();
		spawnPoint = transform.position;
	}

	void Update()
	{
		AI();
		SetAnimation();

		_weaponFireElapsedTime += Time.deltaTime;
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
			Die();
		else
			Hit();
	}

	void SetAnimation()
	{
		_animator.SetBool("Shooting", shooting);
		_animator.SetBool("Moving", moving);
	}

	void Wander()
	{
		if (!shooting)
		{
			moving = true;
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

				if (direction.x > 0)
					sprite.flipX = true;
				else
					sprite.flipX = false;

				transform.position = transform.position + direction.normalized * moveSpeed * Time.deltaTime;
			}
		}
		else
			moving = false;

	}

	void ChangeTarget()
	{
		targetPos = new Vector3(spawnPoint.x + Random.Range(-wanderRadius, wanderRadius),
														spawnPoint.y + Random.Range(-wanderRadius, wanderRadius),
														gameObject.transform.position.z);
	}

	void AI()
	{
		Wander();
		ChangeEnemy();
		if (_target != null && _target.activeInHierarchy)
		{
			shooting = true;
			if (_weaponFireElapsedTime > fireRate)
			{
				_weaponFireElapsedTime = 0;
				_target.transform.parent.GetComponent<Enemy>().DealDamage(attackDamage);
			}
		}
		else
		{
			_target = null;
			shooting = false;
		}
	}

	void ChangeEnemy()
	{
		if (chronoNautRange.enemyColliders.Count > 0)
		{
			if (chronoNautRange.enemyColliders[0].gameObject.activeInHierarchy)
			{
				_target = chronoNautRange.enemyColliders[0].gameObject;
			}
			else
				chronoNautRange.enemyColliders.Remove(chronoNautRange.enemyColliders[0]);
		}
	}

	void Hit()
	{
		// GameManager.Instance.audioManager.PlaySFX(1, hitSounds[0]);
		if (_coFlashWhite != null)
			StopCoroutine(_coFlashWhite);
		_coFlashWhite = StartCoroutine(coFlashWhite());
	}

	void Die()
	{

		if (barracks != null)
		{
			GameManager.Instance.ResourceManager.depotResourceUsed--;
			GameManager.Instance.UIManager.depotResourceText.text =
				GameManager.Instance.ResourceManager.depotResourceUsed + "/" + GameManager.Instance.ResourceManager.depotResource.ToString();
			barracks.qty--;
			barracks.capacity.text = barracks.qty.ToString() + "/" + barracks.maxLimit.ToString();
		}

		if (factory != null)
		{
			GameManager.Instance.ResourceManager.refineryResourceUsed--;
			GameManager.Instance.UIManager.refineryResourceText.text =
				GameManager.Instance.ResourceManager.refineryResourceUsed + "/" + GameManager.Instance.ResourceManager.refineryResource.ToString();
			factory.qty--;
			factory.capacity.text = factory.qty.ToString() + "/" + factory.maxLimit.ToString();
		}

		gameObject.SetActive(false);
	}

	IEnumerator coFlashWhite()
	{
		sprite.material.shader = _whiteFlash;
		yield return new WaitForSeconds(flashDuration);
		sprite.material.shader = _defaultShader;
	}

}
