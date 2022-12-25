using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
	private int number = 0;
	private float timer;
	[SerializeField] private SpriteRenderer sr;
	private void Update()
	{
		if (timer < 0.1f) timer += Time.deltaTime;
		else
		{
			ChangeSprite();
			timer = 0;
		}
	}
	private void ChangeSprite()
	{
		number++;
		if (number < sprites.Length) sr.sprite = sprites[number];
		else Destroy(this.gameObject);
	}
}
