using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BodyguardController : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.
	public GameObject bullet;
	public float fireRate;
	public float turnedR;

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private bool moving;
	private bool allowFire;


	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
		turnedR = 1;
		allowFire = true;
	}

	void Update(){
		if ((Input.GetKey(KeyCode.Space)) && (allowFire)) {
			StartCoroutine (Fire());
		}
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{

		Vector2 velocity = rb2d.velocity;

		moving = false;

		if (Input.GetKey("w"))
		{
			velocity.y = speed;
			velocity.x = 0;
			moving = true;
		}
		if (Input.GetKey("s"))
		{
			velocity.y = -speed;
			velocity.x = 0;
			moving = true;
		}

		if (Input.GetKey("d"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = 0;
			velocity.x = speed;
			moving = true;
		}
		if (Input.GetKey("a"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = 0;
			velocity.x = -speed;
			moving = true;
		}
		if (Input.GetKey("w") && Input.GetKey("d"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = speed*0.75f;
			velocity.x = speed*0.75f;
			moving = true;
		}
		if (Input.GetKey("w") && Input.GetKey("a"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = speed*0.75f;
			velocity.x = -speed*0.75f;
			moving = true;
		}

		if (Input.GetKey("s") && Input.GetKey("d"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = -speed*0.75f;
			velocity.x = speed*0.75f;
			moving = true;
		}
		if (Input.GetKey("s") && Input.GetKey("a"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = -speed*0.75f;
			velocity.x = -speed*0.75f;
			moving = true;
		}

		if (Input.GetKey ("r")) {
			SceneManager.LoadScene ("Level1");
		}

		if (!moving)
		{
			velocity.y = 0;
			velocity.x = 0;
		}

		rb2d.velocity = velocity;


	}
	IEnumerator Fire()
		{
		 	allowFire = false;
		    Vector3 firePoint = new Vector3 (transform.position.x+(0.8f*turnedR), transform.position.y); 
		    Instantiate (bullet, firePoint, transform.rotation);
		    yield return new WaitForSeconds(fireRate);
			allowFire = true;
		}

}