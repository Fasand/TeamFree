﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;
	public BodyguardController bodyguard;

	// Use this for initialization
	void Start () {
		bodyguard = FindObjectOfType<BodyguardController> ();
		if (bodyguard.turnedR < 0f) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.tag == "President") {
			Destroy (other.gameObject);
		}


		Destroy (gameObject);


}
}