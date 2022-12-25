using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletObject;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    [SerializeField] private int damage;
    [SerializeField] private float accuracy = 1;
    [SerializeField] private int bulletsPerShot = 1;
    [SerializeField] private float rpm = 180;
    [SerializeField] private string damageTag;
    private float timer = 0;

    private ParticleSystem ps;

    private Transform weaponHolder;

    private SoundManager sm;

	private void Awake()
	{
        ps = shootingPoint.GetComponent<ParticleSystem>();
        sm = GameObject.Find("Main Camera").GetComponent<SoundManager>();
    }

	private void Update()
	{
        audioSource.volume = sm.soundVolume;
        if (!CanShoot()) timer += Time.deltaTime;
    }
    private bool CanShoot()
	{
        return (timer >= 60 / rpm);
    }
    private Vector2 Destination()
	{
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 destination = transform.TransformDirection(mousePos - shootingPoint.position);
        
        return destination.normalized;
	}
    private Vector3 ShootingDirection(bool physics)
	{
        return shootingPoint.position - transform.position;
    }
	public void Shoot()
	{
        if (CanShoot())
        {
            for (int i = 0; i < bulletsPerShot; i++)
			{            
                audioSource.PlayOneShot(shootSound);
                Shot();
			}
            //ps.Play();
            timer = 0;
        }
	}
    private void Shot()
	{
        Vector3 direction = ShootingDirection(bulletObject.GetComponent<Bullet>().physics);

        Bullet bullet = Instantiate(bulletObject, shootingPoint.position, new Quaternion(0f, 0f, 0f, 0f)).GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.direction = direction;
        bullet.damageTag = damageTag;
    }
    private void SetBulletsPerShot(int num)
	{
        bulletsPerShot = num;
	}
}
