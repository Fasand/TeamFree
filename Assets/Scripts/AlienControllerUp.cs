using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienControllerUp : MonoBehaviour {

	public BodyguardController bodyguard;
	public PresidentController president;
	public GameObject bulletBodyguard;
	public GameObject bulletPresident;
	public float fireRate;
	public GameObject firePos;

	private float turnedR;
	private bool allowFire;
	private Vector3 origFirePos;

	// Use this for initialization
	void Start () {
		bodyguard = FindObjectOfType<BodyguardController> ();
		president = FindObjectOfType<PresidentController> ();
		allowFire = true;
		origFirePos = firePos.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		firePos.transform.position = origFirePos;

		RaycastHit2D hitB = Physics2D.Raycast (transform.position, (bodyguard.transform.position - transform.position), Mathf.Infinity);
		RaycastHit2D hitP = Physics2D.Raycast (transform.position, (president.transform.position - transform.position), Mathf.Infinity);

		if (hitP.collider == president.GetComponent<BoxCollider2D>()) {
			StartCoroutine (Fire (president.gameObject));
		} 
		if (hitB.collider == bodyguard.GetComponent<BoxCollider2D>()) {
			StartCoroutine (Fire (bodyguard.gameObject));
		} 

	}
		

	//OnCollisionEnter2D (Collision2D other){
		//speed = -speed;
	//}

	IEnumerator Fire(GameObject g)
	{
		if ((g.tag == "Bodyguard" && allowFire)) {
			allowFire = false;
			if (bodyguard.transform.position.x < transform.position.x) {
				print (firePos.transform.position.x);
				firePos.transform.position = new Vector3 (firePos.transform.position.x-0.5f, firePos.transform.position.y);
				print (firePos.transform.position.x);
			}
			Instantiate (bulletBodyguard,firePos.transform.position, transform.rotation);
			yield return new WaitForSeconds (fireRate);
			allowFire = true;
		} 
		if (g.tag == "President" && allowFire) {
			allowFire = false;
			if (president.transform.position.x < transform.position.x) {
				print (firePos.transform.position.x);
				firePos.transform.position = new Vector3 (firePos.transform.position.x-0.5f, firePos.transform.position.y);

				print (firePos.transform.position.x);
			}
			Instantiate (bulletPresident,firePos.transform.position, transform.rotation);
			yield return new WaitForSeconds (fireRate);
			allowFire = true;
		}
	}
}
