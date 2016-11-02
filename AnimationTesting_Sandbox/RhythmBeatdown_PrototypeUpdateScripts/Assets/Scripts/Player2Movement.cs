using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {
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
			
			
		if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				
				this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity + Vector3.left * speed;
				
				//Move Back 
			}
			
		else if (Input.GetKeyUp (KeyCode.LeftArrow)) 
			{
				
				this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity - this.GetComponent<Rigidbody> ().velocity;
				
				
				
			}
			
			
			
		if (Input.GetKey (KeyCode.RightArrow)) 
			{
				
				this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity + Vector3.right * speed;
				
				//Move Forward
			} 
			
			
			
		else if (Input.GetKeyUp (KeyCode.RightArrow)) 
			{
				
				this.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody>().velocity - this.GetComponent<Rigidbody>().velocity;
				
				
			}
			
			
		if (Input.GetKeyDown (KeyCode.UpArrow) && isGrounded && !isCrouching) 
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
			
			
		if (Input.GetKeyDown (KeyCode.DownArrow) && isGrounded && !isJumping) 
			{
				isCrouching = true;
					
					
				this.transform.localPosition = new Vector3(this.transform.localPosition.x, -2,this.transform.localPosition.z);
				this.transform.localScale = new Vector3 (this.transform.localScale.x, 2f, this.transform.localScale.z);
				print("Duck");
						
				//Duck
			} 
		else if (Input.GetKeyUp (KeyCode.DownArrow) && isCrouching) 
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
		
		
		/*IEnumerator MovementLoop()
	{
		
		if (Input.GetKeyDown (KeyCode.A)) {
			
			print ("I'm pressing A");
			StartCoroutine (RestartLoop());
		} else if(Input.GetKeyUp (KeyCode.A)) {

			print ("I let go of A");
			StartCoroutine (RestartLoop());
		} else 
		{
			yield return new WaitForEndOfFrame();

			StartCoroutine (RestartLoop ());

		}

		
	}

	IEnumerator MoveCharacters()
	{
		print ("I'm moving the object");
		yield return new WaitForSeconds (0);
		StartCoroutine (MovementLoop ());
	}

	IEnumerator	RestartLoop()
	{
		
		yield return new WaitForSeconds(0);
		StartCoroutine (MovementLoop ());

	}
	*/
	}
