using UnityEngine;
using System.Collections;

public class Move4 : MonoBehaviour
{

	private bool playerBool = true;
	private Rigidbody rb;
	private bool isGrounded = true;
	private bool jumping = false;
	private bool crouching = false;
	private float jumpForce = 25f;
	private float speed = 12f;
	private int jumpCount = 0;
	private float inputX;
	private float inputY;
	private Vector3 targetPosition;
	public static bool rightForward = true;
	private Fighter fighter;
	void Awake ()
	{
		rb = this.GetComponent<Rigidbody> ();
		fighter = this.gameObject.GetComponent<Fighter> ();
	}

	void OnEnable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			playerBool = true;
			InputManager.P1_Move += Move;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			playerBool = false;
			InputManager.P2_Move += Move;
		}
	}

	void OnDisable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			InputManager.P1_Move -= Move;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			InputManager.P2_Move -= Move;

		}
	}

	void Move (float inputX, float inputY)
	{
		jumping = inputY > 0.7f;
		if (inputX < 0.1f && inputX > -0.1f && inputY < -0.8f)
		{
			crouching = true;
		}
		else if(inputY > -0.8f)
		{
			crouching = false;
		}


		if (inputX > 0.1f || inputX < -0.1f)
		{
			if (isGrounded && !crouching && !jumping && !fighter.blocking)
			{
				print ("Moving");
				print (crouching);
				float velocity = Mathf.Clamp (inputX * speed, -10f, 10f);
				
				rb.velocity = new Vector3 (velocity, 0, 0);
			}
		}
		if (jumping && isGrounded && !fighter.blocking)
		{
			if (jumpCount < 1)
			{
				isGrounded = false; 
				jumpCount++;

				float jumpVelocity = Mathf.Clamp (inputX * speed, -15f, 15f);

				rb.velocity = Vector3.zero;
				rb.AddForce (jumpVelocity, jumpForce, 0, ForceMode.Impulse);
					
			}
		}

		if (this.gameObject.tag == "Player_One")
		{
			Transform target = GameObject.Find ("Player_Two").transform;
			targetPosition = new Vector3 (target.position.x, this.transform.position.y, 0);
			this.transform.LookAt (targetPosition);

		}
		else
		{
			Transform target = GameObject.Find ("Player_One").transform;
			targetPosition = new Vector3 (target.position.x, this.transform.position.y, 0);
			this.transform.LookAt (targetPosition);
		}

	}

	

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			isGrounded = true;
			jumping = false;
			jumpCount = 0;
			print ("Grounded");
		}
	}
}
