using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControllerAlienBodyguard : MonoBehaviour {

	public float speed;
	public BodyguardController bodyguard;

	private Vector3 shootDirection;

	// Use this for initialization
	void Start ()
	{
		bodyguard = FindObjectOfType<BodyguardController> ();
		shootDirection = (bodyguard.transform.position - transform.position).normalized;

	}

	void FixedUpdate () {


		GetComponent<Rigidbody2D> ().velocity = new Vector2 ((shootDirection.x)*speed,(shootDirection.y)*speed);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if ((other.collider.tag == "President") || (other.collider.tag == "Bodyguard")) {
			Destroy (other.gameObject);
			SceneManager.LoadScene ("Level1");
		}

		if (!((other.collider.tag == "Alien") || other.collider.tag == "Bullet")) {
			Destroy (gameObject);
		}


	}
}
