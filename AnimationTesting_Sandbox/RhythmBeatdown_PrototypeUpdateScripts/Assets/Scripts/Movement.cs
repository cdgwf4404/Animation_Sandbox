using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private bool isCrouching = false;
	private bool isGrounded = true;
	private bool isJumping = false;
	public float speed = 1.2f;

	// Use this for initialization
	void Start () {

		//StartCoroutine (MovementLoop ());

	}

	// Update is called once per frame
	void Update () {


		/*if (this.transform.position.y <= -1f)
			{
				grounded = true;
				jumping = false;
			}
			*/


		if (Input.GetKey (KeyCode.A)) 
		{

			this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity + Vector3.left * speed;

			//Move Back 
		}

		else if (Input.GetKeyUp (KeyCode.A)) 
		{

			this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity - this.GetComponent<Rigidbody> ().velocity;



		}



		if (Input.GetKey (KeyCode.D)) 
		{

			this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity + Vector3.right * speed;

			//Move Forward
		} 



		else if (Input.GetKeyUp (KeyCode.D)) 
		{

			this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody>().velocity - this.GetComponent<Rigidbody>().velocity;


		}


		if (Input.GetKeyDown (KeyCode.W) && isGrounded && !isCrouching) 
		{
			if (isJumping== false) {
				isJumping = true;
				print (isJumping);
				print ("I can jump");
				this.GetComponent<Rigidbody> ().AddForce (0f, 215f, 0f);
				isGrounded = false;
			}

		}


		//Jump to avoid bottom


		if (Input.GetKeyDown (KeyCode.S) && isGrounded && !isJumping) 
		{
			isCrouching = true;


			this.transform.localPosition = new Vector3(this.transform.localPosition.x, -2,this.transform.localPosition.z);
			this.transform.localScale = new Vector3 (this.transform.localScale.x, 2f, this.transform.localScale.z);
			print("Duck");

			//Duck
		} 
		else if (Input.GetKeyUp (KeyCode.S) && isCrouching) 
		{

			isCrouching = false;
			this.transform.localPosition = new Vector3(this.transform.localPosition.x,-1f,this.transform.localPosition.z) ;
			this.transform.localScale = new Vector3 (this.transform.localScale.x, 3f, this.transform.localScale.z);
			//release Duck
		}
	}




	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ground") 
		{
			isGrounded = true;
			isJumping = false;
		}
	}
}
