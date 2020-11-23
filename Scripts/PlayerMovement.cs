using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;
	public Animator animator;
	public GameObject gameOver;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	void Start () 
	{
		gameOver.SetActive(false);
	}

	void Update () 
	{

		// Ef ýtt á örvatakkan eða wasd, leikmaður hreyfir
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			// Spila jump animation
			animator.SetBool("IsJumping", true);
		}

	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

	void OnCollisionEnter2D (Collision2D other)
    {
	//ef óvinur snerti leikmann
		if (other.gameObject.tag == "Enemy")
        {
			// game over
			gameOver.SetActive(true);
			// leikmaður hverfur
			gameObject.SetActive(false);
        }
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		// ef borð staðist 
		if (other.gameObject.tag == "Finish")
		{
			// birta næsta borð (next scene)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		//ef leikmaður dettur 
		if (other.gameObject.tag == "Death")
		{
			// game over
			gameOver.SetActive(true);
			// leikmaður hverfur
			gameObject.SetActive(false);
		}
	}


}
