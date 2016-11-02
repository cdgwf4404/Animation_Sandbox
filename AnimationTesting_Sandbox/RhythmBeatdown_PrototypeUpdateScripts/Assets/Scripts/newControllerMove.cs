using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class newControllerMove : MonoBehaviour {

	private float speed = 25.0f;
	public float gravity = 40f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	private bool canCrouch = true;
	public float jumpHeight = 4.0f;
	private bool grounded = true;
	private Rigidbody rb;
	private float crouchLerpTimeScale = 2f;
	private Vector3 normalDisplay;
	private Vector3 crouchDisplay;
	private bool isCrouching;
	private bool currentCrouch;


	void Awake () {
		rb = this.GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		rb.useGravity = false;

		normalDisplay = this.transform.localScale;
		crouchDisplay = new Vector3(1,2,1);
	}

	void FixedUpdate () {
		
		if (grounded) {
			
			// Calculate how fast we should be moving
			Vector3 targetVelocity = new Vector3(0,0,Input.GetAxis("Horizontal"));
			targetVelocity = transform.TransformDirection(targetVelocity);

			targetVelocity *=speed;

			// Apply a force that attempts to reach our target velocity
			Vector3 velocity = rb.velocity;
			//print (velocity);
			//print (targetVelocity);
			Vector3 velocityChange = (targetVelocity - velocity);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			rb.AddForce(velocityChange, ForceMode.VelocityChange);
			//print (velocityChange);

			// Jump
			if (canJump && Input.GetAxis("Vertical") >= 0.8f) {
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				canCrouch = false;
			}
			if (canCrouch && Input.GetAxis ("Vertical") <= -0.8f) {
				StartCoroutine (crouch ());
				currentCrouch = true;

				//canCrouch = false;
				//new Vector3 (this.transform.localScale.x, 2f, this.transform.localScale.z);
				//need to check for release or if held down the crouch will auto resume
			} else {
				this.transform.localPosition = new Vector3(this.transform.localPosition.x,2.5f,this.transform.localPosition.z) ;
				this.transform.localScale = new Vector3 (this.transform.localScale.x, 3f, this.transform.localScale.z);
				//this.transform.localPosition = new Vector3(this.transform.localPosition.x, 1.6f, this.transform.localPosition.z) ;
				//this.transform.localScale = normalDisplay;
			}
		}

		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3 (0, -gravity * rb.mass, 0));
		grounded = false;
	}

	void OnCollisionStay (Collision col) {
		if(col.gameObject.tag == "ground")
			grounded = true; 
	}

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

	IEnumerator crouch(){

		canCrouch = true;
		this.transform.localPosition = new Vector3(this.transform.localPosition.x, 2f,this.transform.localPosition.z);
		this.transform.localScale = new Vector3 (this.transform.localScale.x, 2f, this.transform.localScale.z);
		//this.transform.localPosition = new Vector3 (this.transform.localPosition.x, .53f, this.transform.localPosition.z);
		//this.transform.localScale = Vector3.Lerp(normalDisplay, crouchDisplay, Time.fixedDeltaTime*40);

		yield return new WaitForSeconds (2f);
		StartCoroutine (crouchCooldown ());

	}

	IEnumerator crouchCooldown()
	{
		canCrouch = false;
		yield return new WaitForSeconds (2f);

		StartCoroutine (crouchCooldownRestore ());
	}

	IEnumerator crouchCooldownRestore()
	{
		canCrouch = true;
		yield return new WaitForSeconds (2f);

		
	}

}