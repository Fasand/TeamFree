using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControllerAlienPresident : MonoBehaviour {

	public float speed;
	public BodyguardController bodyguard;
	public PresidentController president;

	private Vector3 shootDirection;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		president = FindObjectOfType<PresidentController> ();
		bodyguard = FindObjectOfType<BodyguardController> ();
		shootDirection = (president.transform.position - transform.position).normalized;
	}

	void FixedUpdate () {


		GetComponent<Rigidbody2D> ().velocity = new Vector2 ((shootDirection.x)*speed,(shootDirection.y)*speed);
	}

	IEnumerator OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.tag == "President") {
			president.GetComponent<Animator> ().SetTrigger ("isDying");
			yield return new WaitForSeconds (0.1f);
			Destroy (other.gameObject);
			SceneManager.LoadScene ("Level1");
		}
		if (other.collider.tag == "Bodyguard") {
			bodyguard.GetComponent<Animator> ().SetTrigger ("isDying");
			yield return new WaitForSeconds (0.1f);
			Destroy (other.gameObject);
			SceneManager.LoadScene ("Level1");
		}

		if (!((other.collider.tag == "Alien") || other.collider.tag == "Bullet")) {
			Destroy (gameObject);
		}


	}
}
