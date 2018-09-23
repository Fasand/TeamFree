using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D (Collision2D other){
		if ((other.collider.tag == "President") && (Input.GetKey("up")) && (gameObject.transform.position.y > other.transform.position.y)){
			other.collider.enabled = false;
			other.transform.position = new Vector3 (other.transform.position.x,gameObject.transform.position.y+0.7f );
			other.collider.enabled = true;
		}
		if ((other.collider.tag == "President") && (Input.GetKey("down")) && (gameObject.transform.position.y < other.transform.position.y)){
				other.collider.enabled = false;
				other.transform.position = new Vector3 (other.transform.position.x,gameObject.transform.position.y-0.7f );
				other.collider.enabled = true;
			}
}
}
