using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Factory : MonoBehaviour
{
	public GameObject mech;
	public TMP_Text capacity;
	public Structure structure;
	public int qty = 0;
	public int maxLimit = 1;

	private float time;
	void Start()
	{
		structure = GetComponent<Structure>();
		time = GameManager.Instance.time;
		capacity.text = qty.ToString() + "/" + maxLimit.ToString();
	}

	void Update()
	{
		time += Time.deltaTime;
		if (time > 10)
		{
			if (qty < maxLimit)
			{
				qty++;
				capacity.text = qty.ToString() + "/" + maxLimit.ToString();
				GameObject newMech = Instantiate(mech, transform.position - new Vector3(0, 0.4f, 0), Quaternion.identity);
				newMech.GetComponent<ChronoNaut>().factory = gameObject.GetComponent<Factory>();
			}
			time = 0;

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
}