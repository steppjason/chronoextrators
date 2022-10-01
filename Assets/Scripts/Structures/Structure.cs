using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Structure : MonoBehaviour
{
	public int resourceCost = 10;
	public float health = 10;
	public float maxHealth = 10;
	public Image healthBar;

	private RectTransform rectTransform;
	void Start()
	{
		health = maxHealth;
		healthBar.fillAmount = health / maxHealth;
	}

	void Update()
	{
		healthBar.fillAmount = health / maxHealth;

		if (healthBar.fillAmount <= 0.7f && healthBar.fillAmount >= 0.3f)
			healthBar.color = new Color(1, 1, 0, 1);
		else if (healthBar.fillAmount < 0.3f)
			healthBar.color = new Color(1, 0, 0, 1);
		else
			healthBar.color = new Color(0, 1, 0, 1);
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	public void Die()
	{
		gameObject.SetActive(false);
	}
}
