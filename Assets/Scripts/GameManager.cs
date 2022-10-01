using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float time = 0f;
	public int groundEnemyCount;
	public int GROUND_ENEMIES = 400;

	public int enemiesPerWave = 0;
	public float enemyIncrease = 0.5f;

	public GameObject groundEnemy;
	public GameObject groundEnemyPool;
	public GameObject airEnemy;

	public AudioManager AudioManager;
	public ResourceManager ResourceManager;
	public UIManager UIManager;

	GameObject[] _groundEnemies;
	int _nextGroundEnemy;

	GameObject[] _airEnemies;

	void GameInstance()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void Awake()
	{
		GameInstance();
		AudioManager = GetComponent<AudioManager>();
		ResourceManager = GetComponent<ResourceManager>();
		UIManager = GetComponent<UIManager>();
	}

	void Start()
	{
		UIManager.chronoResourceText.text = ResourceManager.chronoResource.ToString();
		UIManager.depotResourceText.text =
			ResourceManager.depotResourceUsed + "/" + ResourceManager.depotResource.ToString();
		UIManager.refineryResourceText.text =
			ResourceManager.refineryResourceUsed + "/" + ResourceManager.refineryResource.ToString();

		InstantiateGroundEnemies();
	}

	void Update()
	{
		time += Time.deltaTime;
		UIManager.timerText.text = (10 - time).ToString();
		if (time > 10)
		{
			SpawnGroundEnemies();
			enemyIncrease += 0.75f;
			Debug.Log(Mathf.Pow(1.1f, enemyIncrease));
			enemiesPerWave = Mathf.RoundToInt(Mathf.Pow(1.1f, enemyIncrease));
			Debug.Log(enemiesPerWave);
			time = 0;
		}
	}

	void InstantiateGroundEnemies()
	{
		_groundEnemies = new GameObject[GROUND_ENEMIES];
		for (int i = 0; i < GROUND_ENEMIES; i++)
		{
			_groundEnemies[i] = Instantiate(groundEnemy, new Vector3(0, 0, 0), Quaternion.identity);
			_groundEnemies[i].transform.parent = groundEnemyPool.transform;
			_groundEnemies[i].SetActive(false);
		}
	}

	void SpawnGroundEnemies()
	{
		for (int i = 0; i < enemiesPerWave; i++)
		{
			if (groundEnemyCount < GROUND_ENEMIES)
			{
				GetAvailableGroundEnemy();
				if (_nextGroundEnemy == -1) return;
				GameObject newEnemy = _groundEnemies[_nextGroundEnemy];
				newEnemy.transform.position = GetRandomPoint();
				newEnemy.SetActive(true);
			}
		}
	}

	void GetAvailableGroundEnemy()
	{
		if (_nextGroundEnemy == -1) _nextGroundEnemy = 0;
		for (int i = _nextGroundEnemy; i < _groundEnemies.Length; i++)
		{
			if (!_groundEnemies[i].gameObject.activeInHierarchy)
			{
				_nextGroundEnemy = i;
				return;
			}
		}
		_nextGroundEnemy = -1;
	}

	Vector3 GetRandomPoint()
	{
		int quad = Random.Range(0, 4);
		int corner = Random.Range(0, 2);
		float x = 0;
		float y = 0;

		Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (direction.y > 0 && direction.x == 0)
		{
			x = Random.Range(-10, Screen.width + 10);
			y = Screen.height + 10;
		}
		else if (direction.x > 0 && direction.y == 0)
		{
			x = Screen.width + 10;
			y = Random.Range(-10, Screen.height + 10);
		}
		else if (direction.y < 0 && direction.x == 0)
		{
			x = Random.Range(-10, Screen.width + 10);
			y = -10;
		}
		else if (direction.x < 0 && direction.y == 0)
		{
			x = -10;
			y = Random.Range(-10, Screen.height + 10);
		}
		else if (direction.x > 0 && direction.y > 0)
		{
			if (corner == 0)
			{
				x = Screen.width + 10;
				y = Random.Range(-10, Screen.height + 10);
			}
			else
			{
				x = Random.Range(-10, Screen.width + 10);
				y = Screen.height + 10;
			}
		}
		else if (direction.x > 0 && direction.y < 0)
		{
			if (corner == 0)
			{
				x = Screen.width + 10;
				y = Random.Range(-10, Screen.height + 10);
			}
			else
			{
				x = Random.Range(-10, Screen.width + 10);
				y = -10;
			}
		}
		else if (direction.x < 0 && direction.y < 0)
		{
			if (corner == 0)
			{
				x = -10;
				y = Random.Range(-10, Screen.height + 10);
			}
			else
			{
				x = Random.Range(-10, Screen.width + 10);
				y = -10;
			}
		}
		else if (direction.x < 0 && direction.y > 0)
		{
			if (corner == 0)
			{
				x = -10;
				y = Random.Range(-10, Screen.height + 10);
			}
			else
			{
				x = Random.Range(-10, Screen.width + 10);
				y = Screen.height + 10;
			}
		}
		else if (direction.x == 0 && direction.y == 0)
		{
			if (quad == 0)
			{
				x = Random.Range(-10, Screen.width + 10);
				y = -10;
			}
			else if (quad == 1)
			{
				x = Screen.width + 10;
				y = Random.Range(-10, Screen.height + 10);
			}
			else if (quad == 2)
			{
				x = Random.Range(-10, Screen.width + 10);
				y = Screen.height + 10;
			}
			else
			{
				x = -10;
				y = Random.Range(-10, Screen.height + 10);
			}
		}


		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
		Vector3 randomPoint = new Vector3(point.x, point.y, 0);
		return randomPoint;
	}
}
