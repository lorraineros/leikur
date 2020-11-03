using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;

	// Update is called once per frame
	void Update()
	{
		// Ef ýtt á space
		if (Input.GetButtonDown("Fire1"))
		{
			// Skjótta 
			Shoot();
		}
	}

	void Shoot()
	{
		// Spawn kúlu í firepoin
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
