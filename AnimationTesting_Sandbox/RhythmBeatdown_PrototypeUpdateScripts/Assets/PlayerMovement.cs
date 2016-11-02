using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Animator animator;

	//private bool Jump = false;
//	private bool crouchBool = false;
//	private bool blockBool = false;
	private bool dead = false;
	private float buttonCooler = 0.1f;
	private int buttonCount = 0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		animator.SetFloat("Speed", Input.GetAxis("Horizontal"));

	if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetBool("Jump", true);
			StartCoroutine(COInAir ());
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
	
			animator.SetBool ("Crouch", true);

		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {

			animator.SetBool("Crouch", false);

		}

		if (Input.GetKey (KeyCode.Comma)) {
		
			animator.SetBool ("Block", true);

		} else if (Input.GetKeyUp (KeyCode.Comma)) {
		
			animator.SetBool("Block", false);
		
		}

		if (Input.GetKeyDown (KeyCode.Period)) {
		
			animator.SetTrigger("Punch");
	
		}

		if (Input.GetKeyDown (KeyCode.Slash)) {
		
			animator.SetTrigger("Kick");
		
		}

		if (Input.GetKeyDown (KeyCode.L)) {
		
			animator.SetTrigger("HeavyAttack");

		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {

			if (buttonCooler > 0 && buttonCount == 1/*Number of Taps you want Minus One*/) {
				//Has double tapped
				animator.SetBool ("DashForward", true);
				StartCoroutine (COInAir ());
			} else {
				buttonCooler = 0.5f; 
				buttonCount += 1;
			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (buttonCooler > 0 && buttonCount == 1/*Number of Taps you want Minus One*/) {
				//Has double tapped
				animator.SetBool ("DashBackward", true);
				StartCoroutine (COInAir ());
			} else {
				buttonCooler = 0.5f; 
				buttonCount += 1;
			}
		}

		if ( buttonCooler > 0 )
		{
			
			buttonCooler -= 1 * Time.deltaTime ;
			
		}else{
			buttonCount = 0 ;
		}
	}



	IEnumerator COInAir()
	{
		yield return new WaitForSeconds(0.5f);
		//Jump = false;
		animator.SetBool("Jump", false);
		animator.SetBool ("DashForward", false);
		animator.SetBool ("DashBackward", false);
	}
}
