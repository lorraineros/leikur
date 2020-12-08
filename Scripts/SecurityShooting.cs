using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityShooting : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Transform Player;
	public int distance = 5;
	public GameObject[] player;

	float fireRate;
	float nextFire;

	void Start()
    {
		fireRate = 0.5f;
		nextFire = Time.time;
    }

	// Update is called once per frame
	void Update()
	{
		player = GameObject.FindGameObjectsWithTag("Player");
		if (Vector2.Distance(Player.position, transform.position) <= distance && (player.Length != 0))
		{
			// Ef 
			if (Time.time > nextFire)
			{
				// Skjótta 
				Shoot();
				nextFire = Time.time + fireRate;
			}
		}
	}

	void Shoot()
	{
		// Spawn kúlu í firepoin
		Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
	}
}
