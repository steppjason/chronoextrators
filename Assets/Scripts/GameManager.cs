using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float time = 0f;

	public AudioManager AudioManager;
	public ResourceManager ResourceManager;
	public UIManager UIManager;

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
	}

	void Update()
	{
		time += Time.deltaTime;
		UIManager.timerText.text = (10 - time).ToString();
		if (time > 10)
			time = 0;
	}
}
