using UnityEngine;
using System.Collections;

public class CharAnimation : MonoBehaviour {

	protected Animator anim;
	private bool playerBool;
	private bool jumping = false;
	private int jumpCount = 0;
	private bool crouching;
	private Fighter fighter;
	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator> ();
		fighter = this.GetComponent<Fighter> ();
		print (anim);
	}

	void OnEnable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			playerBool = true;
			InputManager.P1_Move += Walk;
			InputManager.P1_Move += Jump;
			InputManager.P1_Move += Crouch;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			playerBool = false;
			InputManager.P2_Move += Walk;
			InputManager.P2_Move += Jump;
			InputManager.P2_Move += Crouch;
		}
	}

	void OnDisable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			InputManager.P1_Move -= Walk;
			InputManager.P1_Move -= Jump;
			InputManager.P1_Move -= Crouch;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			InputManager.P2_Move -= Walk;
			InputManager.P2_Move -= Jump;
			InputManager.P2_Move -= Crouch;
		}
	}


	void Walk(float axisValH, float axisValV)
	{
		anim.SetFloat ("Speed", axisValH);
		float dirNum = 0;
		if (this.gameObject.tag == "Player_One")
		{
			Transform target = GameObject.Find ("Player_Two").transform;
			Vector3 heading = target.position - transform.position;
			dirNum = AngleDir (transform.forward, heading, transform.up);
		}
		if (dirNum == -1 && !jumping && !crouching)
		{
			anim.SetFloat ("Speed", axisValH);
		}
		else if(dirNum == 1 && !jumping && !crouching)
		{
			anim.SetFloat ("Speed", -axisValH);
		}
		//Check direction p1 is facing

		//Send proper anim axis value based on direction
		//***NEED TO DO SAME FOR P2***
//		if (dirNum == -1)
//		{
//			print("facing right");
//
//			//anim.SetBool ("Walk", true);
//		}
//		else if(dirNum == 1 && axisValH > 0.1f)
//		{
//			//anim.SetBool ("WalkBack", true);
//			//anim.SetFloat ("Speed", axisValH);
//		}

	}

	void Jump(float axisValH, float axisValV)
	{
		
		if (axisValV > 0.75f && !fighter.blocking)
		{
			if (jumpCount < 1)
			{
				jumping = true;
				anim.SetBool ("isJumping", true);
				jumpCount++;
			}
		}
		else
		{
			jumpCount = 0;
		}
	}

	void Crouch(float axisValH, float axisValV)
	{
		if (axisValV < -0.8f)
		{
			crouching = true;
			anim.SetBool ("Crouch", true);
		}
		else
		{
			crouching = false;
			anim.SetBool ("Crouch", false);
		}
	}

	float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
	{
		Vector3 perp = Vector3.Cross (fwd, targetDir);
		float dir = Vector3.Dot (perp, up);

		if (dir > 0f)
		{
			return 1f;
		}
		else if (dir < 0f)
		{
			return -1f;
		}
		else
		{
			return 0f;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "ground")
		{
			jumping = false;
			print ("hit ground");
			anim.SetBool ("isJumping", false);
		}
	}


}
