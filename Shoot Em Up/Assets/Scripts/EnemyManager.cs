using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField] private GameObject XWing;
	[SerializeField] private GameObject TIE;
	[SerializeField] private List<GameObject> spawnedEnemy;
	[SerializeField] private GameObject Biplane;

	[SerializeField] private Transform[] biplanePoints;
	[SerializeField] private Transform[] TIEPoints;
	private int currentDifficulty = 1;
	[SerializeField] private int difficultyLeft;

	[SerializeField] private BonusManager player;
	private void Start()
	{
		SpawnWave(currentDifficulty);
	}
	private void Update()
	{
		for (int i = 0; i < spawnedEnemy.Count; i++)
		{
			if (spawnedEnemy[i] == null)
			{
				if (difficultyLeft > 0)
				{
					if (i < 5) SpawnEnemy(Biplane, biplanePoints[i].position);
					else SpawnEnemy(TIE, TIEPoints[2].position);
					difficultyLeft--;
				}
				spawnedEnemy.RemoveAt(i);
			}
			else if (spawnedEnemy[i].transform.position.z < 0)
			{
				if (difficultyLeft > 0)
				{
					if (i < 5) SpawnEnemy(Biplane, biplanePoints[i].position);
					else SpawnEnemy(TIE, TIEPoints[2].position);
					difficultyLeft--;
				}
				spawnedEnemy[i].SendMessage("Death");
			}
		}
		if (spawnedEnemy.Count == 0)
		{
			currentDifficulty++;
			player.SendMessage("GetRandomBonus");
			SpawnWave(currentDifficulty);
		}
	}
	private void EntityDied(int index)
	{
		Destroy(spawnedEnemy[index]);
		spawnedEnemy.RemoveAt(index);
	}
	private void SpawnWave(int difficulty)
	{
		int dif = difficulty;

		for (int i = 0; i < difficulty && i < 5; i++)
		{
			SpawnEnemy(Biplane, biplanePoints[i].position);
		}
		difficultyLeft = difficulty - 6;

		if (difficulty > 5) SpawnEnemy(TIE, TIEPoints[2].position);
	}
	private void SpawnEnemy(GameObject enemy, Vector3 pos)
	{
		GameObject thing = Instantiate(enemy, pos, transform.rotation);
		thing.transform.SetParent(null);
		spawnedEnemy.Add(thing);
	}
}
