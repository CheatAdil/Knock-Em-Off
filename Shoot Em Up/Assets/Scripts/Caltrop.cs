using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrop : Bullet
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Entity")
		{
			collision.gameObject.SendMessage("SlowDown");
			Damage(collision.gameObject);
			Destroy(this.gameObject);
		}
	}
}
