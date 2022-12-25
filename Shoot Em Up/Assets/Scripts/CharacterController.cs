using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Entity
{
	[SerializeField] private BonusManager bm;
	private float timer = 0f;
	public float rpm = 60f;
	
	private void Update()
	{
		Move(Input.GetAxis("Horizontal"), 0);
		CanShoot();
		if (Input.GetMouseButton(1)) Grenade();
	}
	private void CanShoot()
	{
		if (timer >= 60 / rpm)
		{
			Attack();
			timer = 0f;
		}
		else timer += Time.deltaTime;
	}
}
