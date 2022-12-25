using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string bulletName;
	[SerializeField] public bool physics;
    [SerializeField] private float speed;
    [SerializeField] public int damage;
	[SerializeField] private string deathMessage;
	public string damageTag;
	public Vector3 direction;
    private void SetDamage(int weaponDamage)
	{
        damage = weaponDamage;
	}
	private void Update()
	{
		if (Mathf.Abs(transform.position.z) >= 40f) Destroy(this.gameObject);
		if (!physics) transform.Translate(direction * Time.deltaTime * speed);
		else
		{
			GetComponent<Rigidbody>().AddForce(direction * speed);
			direction = Vector2.zero;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == damageTag)
		{
			Damage(other.gameObject);
			Destroy(this.gameObject);
		}
	}
	protected void Damage(GameObject target)
	{
		target.SendMessage("LastDamage", deathMessage);
		target.SendMessage("Hurt", damage);
	}
}
