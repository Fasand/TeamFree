using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour {

	public string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other){
		Destroy (other.gameObject);
		if (other.tag == "President") {
			Destroy (gameObject);
			SceneManager.LoadScene (nextLevel);
		}
	}

}
