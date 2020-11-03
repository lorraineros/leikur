using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public float speed = 0.5f;
    public Transform Player;
    public int distance = 7;
    bool facingRight;
    public int health = 100;

    // Óvinur skaðast og deyja ef hp er minna en 0
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Snúa
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }

    // Update is called once per frame
    void Update()
    {
        // Tilfærsla
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        // óvinur eltir leikman ef fjarlæg milli þeirra er of stutt
        if (Vector2.Distance(Player.position, transform.position) <= distance)
        {
            transform.position += (displacement * speed * Time.deltaTime);
            // Þegar speed er hærri en 0.01, spila walk animation
            // Láta óvinur að labba
            animator.SetFloat("Speed", 1);
            // Ef leikmaður er á hægra megin og óvinur er ekki að horfa á hann, snúa óvini
            if (Player.position.x > transform.position.x && !facingRight)
                Flip();
            if (Player.position.x < transform.position.x && facingRight)
                Flip();
        }
        else if (Vector2.Distance(Player.position, transform.position) > distance)
        {
            // Idle
            animator.SetFloat("Speed", 0);
        }

    }
}