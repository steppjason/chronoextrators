using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barracks : MonoBehaviour
{
	public Structure structure;
	public GameObject chronoNaut;
	public int maxLimit = 5;

	public TMP_Text capacity;

	private float time;
	public int qty = 0;

	private void Start()
	{
		time = GameManager.Instance.time;
		capacity.text = qty.ToString() + "/" + maxLimit.ToString();
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time > 10)
		{
			if (qty < maxLimit &&
						GameManager.Instance.ResourceManager.depotResourceUsed < GameManager.Instance.ResourceManager.depotResource)
			{
				qty++;
				capacity.text = qty.ToString() + "/" + maxLimit.ToString();
				GameManager.Instance.ResourceManager.depotResourceUsed++;
				GameManager.Instance.UIManager.depotResourceText.text =
						GameManager.Instance.ResourceManager.depotResourceUsed + "/" + GameManager.Instance.ResourceManager.depotResource.ToString();
				GameObject newChrononaut = Instantiate(chronoNaut, transform.position - new Vector3(0, 0.4f, 0), Quaternion.identity);
				newChrononaut.GetComponent<ChronoNaut>().barracks = gameObject.GetComponent<Barracks>();
			}
			time = 0;
		}

		if (structure.health <= 0)
		{
			Destroy();
		}
	}

	void Destroy()
	{
		structure.Die();
	}


}
