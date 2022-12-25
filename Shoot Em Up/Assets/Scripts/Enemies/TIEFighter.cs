using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIEFighter : Entity
{
	private GameObject player;
	private void Start()
	{
		player = GameObject.Find("Player");
	}
	private float DirectionToObjective(Transform objective)
	{
		float x = transform.position.x - objective.position.x;
		return x;
	}
	private void Update()
	{
		if (transform.position.z > 35) Move(0f, 1f);
		if (player != null)
		{
			Move(DirectionToObjective(player.transform), 0f);
			Attack();
		}
	}
}
