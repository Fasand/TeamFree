using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour {

	public BodyguardController bodyguard;
	public PresidentController president;
	public GameObject bulletBodyguard;
	public GameObject bulletPresident;
	public float fireRate;
	public GameObject firePos;

	private float turnedR;
	private bool allowFire;
	private Vector3 origFirePos;
	private Animator animator;

	// Use this for initialization
	void Start () {
		bodyguard = FindObjectOfType<BodyguardController> ();
		president = FindObjectOfType<PresidentController> ();
		animator = GetComponent<Animator> ();
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
			animator.SetTrigger ("isShooting");
			StartCoroutine (Fire (president.gameObject));
		} 
		if (hitB.collider == bodyguard.GetComponent<BoxCollider2D>()) {
			animator.SetTrigger ("isShooting");
			StartCoroutine (Fire (bodyguard.gameObject));
		} 

	}


	IEnumerator Fire(GameObject g)
	{
		if ((g.tag == "Bodyguard" && allowFire)) {
			allowFire = false;
			if (bodyguard.transform.position.x < transform.position.x) {
				firePos.transform.position = new Vector3 (firePos.transform.position.x-0.5f, firePos.transform.position.y);
			}
			Instantiate (bulletBodyguard,firePos.transform.position, transform.rotation);
			yield return new WaitForSeconds (fireRate);
			allowFire = true;
		} 
		if (g.tag == "President" && allowFire) {
			allowFire = false;
			if (president.transform.position.x < transform.position.x) {
				firePos.transform.position = new Vector3 (firePos.transform.position.x-0.5f, firePos.transform.position.y);
			}
			Instantiate (bulletPresident,firePos.transform.position, transform.rotation);
			yield return new WaitForSeconds (fireRate);
			allowFire = true;
		}
	}
}
