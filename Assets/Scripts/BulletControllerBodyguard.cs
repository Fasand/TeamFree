using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControllerBodyguard : MonoBehaviour {

	public float speed;
	public BodyguardController bodyguard;
	public PresidentController president;

	// Use this for initialization
	void Start () {
		president = FindObjectOfType<PresidentController> ();
		bodyguard = FindObjectOfType<BodyguardController> ();
		if (bodyguard.turnedR < 0f) {
			speed = -speed;
		}
	}

	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.tag == "President") {

			Destroy (other.gameObject);
			SceneManager.LoadScene ("Level1");
		}
		if (other.collider.tag == "Alien") {
			Destroy (other.gameObject);
		}

		if (!((other.collider.tag == "Bodyguard") || other.collider.tag == "Bullet")) {
			Destroy (gameObject);
		}


}
}
