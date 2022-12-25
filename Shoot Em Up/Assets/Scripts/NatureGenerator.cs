using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] natureThings;
	[SerializeField] private float density;
	[SerializeField] private float speed;
	private List<GameObject> spawnedNature;
	private void Start()
	{
		spawnedNature = new List<GameObject>();
		FlipCoin();
	}
	private void Update()
	{
		if (spawnedNature.Count != 0)
		{
			for (int i = 0; i < spawnedNature.Count; i++)
			{
				if (spawnedNature[i].transform.position.z < -10)
				{
					Destroy(spawnedNature[i]);
					spawnedNature.RemoveAt(i);
				}
				else
				{
					spawnedNature[i].transform.Translate(Vector3.back * speed * Time.deltaTime);
				}
			}
		}
	}
	private void GenerateNature()
	{
		GameObject thing = Instantiate(natureThings[Random.Range(1, natureThings.Length)], new Vector3(Random.Range(-30f, 30f), 0f, 40f), new Quaternion(0f, 0f, 0f, 0f));
		spawnedNature.Add(thing);
	}

	private void FlipCoin()
	{
		if (Random.Range(0f, 1f) <= 1) GenerateNature();

		Invoke("FlipCoin", density/speed);
	}
}
