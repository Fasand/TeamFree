using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

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

		if (Input.GetKey("up"))
		{
			velocity.y = speed;
		}
		else if (Input.GetKey("down"))
		{
			velocity.y = speed * -1;
		}

		else if (Input.GetKey("right"))
		{
			velocity.x = speed;
		}
		else if (Input.GetKey("left"))
		{
			velocity.x = speed * -1;
		}
		else
		{
			velocity.y = 0;
			velocity.x = 0;
		}


		rb2d.velocity = velocity;

	}
}