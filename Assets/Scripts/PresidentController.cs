using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PresidentController : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float turnedR = 1;
	private bool moving;

	// Use this for initialization
	void Start()
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		Vector2 velocity = rb2d.velocity;

		moving = false;

		if (Input.GetKey("up"))
		{
			velocity.y = speed;
			velocity.x = 0;
			moving = true;
		}
		if (Input.GetKey("down"))
		{
			velocity.y = -speed;
			velocity.x = 0;
			moving = true;
		}

		if (Input.GetKey("right"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = 0;
			velocity.x = speed;
			moving = true;
		}
		if (Input.GetKey("left"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = 0;
			velocity.x = -speed;
			moving = true;
		}
		if (Input.GetKey("up") && Input.GetKey("right"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = speed*0.75f;
			velocity.x = speed*0.75f;
			moving = true;
		}
		if (Input.GetKey("up") && Input.GetKey("left"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = speed*0.75f;
			velocity.x = -speed*0.75f;
			moving = true;
		}

		if (Input.GetKey("down") && Input.GetKey("right"))
		{
			if (turnedR < 0) {
				turnedR = -turnedR;
			}
			velocity.y = -speed*0.75f;
			velocity.x = speed*0.75f;
			moving = true;
		}
		if (Input.GetKey("down") && Input.GetKey("left"))
		{
			if (turnedR > 0) {
				turnedR = -turnedR;
			}
			velocity.y = -speed*0.75f;
			velocity.x = -speed*0.75f;
			moving = true;
		}

		if (!moving)
		{
			velocity.y = 0;
			velocity.x = 0;
		}

		rb2d.velocity = velocity;
	}
}