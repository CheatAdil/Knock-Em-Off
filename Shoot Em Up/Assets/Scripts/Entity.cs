using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private string entityName;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health;

	private Rigidbody2D rb;

	[SerializeField] private float movementSpeed; //Standard speed

	[SerializeField] private Weapon[] gun;
	public int weaponCount;
	[SerializeField] private GameObject grenade;

	[SerializeField] private GameObject courpse;

	[SerializeField] private SpriteRenderer[] sprite;

	[SerializeField] private GameObject explosion;
	private string deathMessage = "has died";
	private float speed; //Actual speed

	private int lastDamage;
	private void Awake()
	{
		health = maxHealth;
		speed = movementSpeed;
		rb = GetComponent<Rigidbody2D>();
	}
	protected void Attack()
	{
		for (int i = 0; i < weaponCount && i < gun.Length; i++)
			gun[i].Shoot();
	}
	protected void Grenade()
	{
		grenade.transform.GetChild(0).SendMessage("Shoot");
	}
	protected void Move(float x = 0, float y = 0)
	{
		Vector2 movement = new Vector2(x, y);
		transform.Translate(movement.normalized * speed * Time.deltaTime);
		if(transform.position.x > 20f)
		{
			Vector3 pos = transform.position;
			pos.x = 20f;
			transform.position = pos;
		}
		else if (transform.position.x < -20f)
		{
			Vector3 pos = transform.position;
			pos.x = -20f;
			transform.position = pos;
		}

		Vector3 posi = transform.position;
		transform.position = new Vector3(posi.x, 5f, posi.z);
	}
	private void LastDamage(string message)
	{
		deathMessage = message;
	}
	private void Hurt(int damage)
	{
		health -= damage;
		if (health <= 0) Death();
		for (int i = 0; i < sprite.Length; i++)
		{
			sprite[i].color = Color.red;
		}
		Invoke("ChangeColor", .3f);
	}
	private void ChangeColor()
	{
		for (int i = 0; i < sprite.Length; i++)
		{
			sprite[i].color = Color.white;
		}
	}
	private void Death()
	{
		Instantiate(explosion, transform.position, transform.rotation);
		Debug.Log(entityName + " " + deathMessage);
		Destroy(this.gameObject);
	}
	private void SlowDown()
	{
		if (speed > movementSpeed * 0.5f)	speed -= movementSpeed * 0.1f;
		if (speed <= movementSpeed * 0.5f)	speed = movementSpeed * 0.5f;
	}
}
