using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityBullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public Transform player;
	Vector2 moveDirection;


	//Skjótta
	void Start()
	{
		this.player = GameObject.FindWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
		moveDirection = (player.transform.position - transform.position).normalized * speed;
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy(gameObject, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
        {
			Debug.Log("Hitt");
			Destroy(gameObject);
        }
	}

}