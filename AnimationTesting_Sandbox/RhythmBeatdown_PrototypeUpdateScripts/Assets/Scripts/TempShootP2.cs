using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TempShootP2 : MonoBehaviour {

	public GameObject projectile2H;
	public GameObject projectile2M;
	public GameObject projectile2L;
	public GameObject p2SpawnPointH;
	public GameObject p2SpawnPointM;
	public GameObject p2SpawnPointL;

	private Combo Thundara = new Combo (new KeyCode[] { KeyCode.Keypad2, KeyCode.Keypad1, KeyCode.Keypad3 });
	private Combo Fira = new Combo (new KeyCode[] { KeyCode.Keypad1, KeyCode.Keypad1, KeyCode.Keypad3 });
	private Combo Blizzara = new Combo (new KeyCode[] { KeyCode.Keypad3, KeyCode.Keypad2, KeyCode.Keypad1 });

	private bool combo1 = false;
	private bool combo2 = false;
	private bool combo3 = false;

	public Rigidbody combo3SwapRB;

	public float projectileHighUp = 15f;
	public float projectileMedUp = 6f;
	public float projectileLowUp = 5f;

	public float projectileSpeedHigh = 7f;
	public float projectileSpeedMed = 19f;
	public float projectileSpeedLow = 24f;
	public float comboForce = 450f;


	private bool currentBeat = true;
	private bool canFire = true;
	private int projectileCounter = 0;

	public static List <GameObject> p2Projectiles;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(PlayMusic.onBeat)
		{
			currentBeat = true;


		if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetButtonDown ("X360_B2") && combo1 == true && projectileCounter < 1) {
			projectileCounter = 1;

			GameObject projectileHandler;

			projectileHandler = Instantiate (projectile2M, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;


			tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
			tempRigidBody.AddForce (transform.forward * comboForce);


			combo1 = false;
		}	

		if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetButtonDown ("X360_B2") && combo2 == true && projectileCounter < 1) {
			projectileCounter = 1;
			GameObject projectileHandler;
			GameObject projectileHandler2;

			projectileHandler = Instantiate (projectile2H, p2SpawnPointH.transform.position, p2SpawnPointH.transform.rotation) as GameObject;
			projectileHandler2 = Instantiate (projectile2M, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;
			Rigidbody tempRigidBody2;

			tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileHighUp);

			tempRigidBody2 = projectileHandler2.GetComponent<Rigidbody> ();
			tempRigidBody2.AddForce (transform.forward * projectileSpeedMed);

			combo2 = false;
		}

		if (Input.GetKeyDown (KeyCode.Keypad5) || Input.GetButtonDown ("X360_B2") && combo2 == true && projectileCounter < 1) {
			projectileCounter = 1;

			GameObject projectileHandler;

			projectileHandler = Instantiate (projectile2L, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;

			tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileLowUp);

			combo3SwapRB = tempRigidBody;
			//tempRigidBody.transform.position = new Vector3 (0, p1SpawnPointH.transform.position.y, 1);

			StartCoroutine (SwapCombo ());

			combo3 = false;
		}
			
		if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetButtonDown ("X360_A2") && projectileCounter < 1) {
			projectileCounter = 1;
			
			GameObject projectile2Handler;
			
			projectile2Handler = Instantiate (projectile2L, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;
			
			Rigidbody tempRigidBody;
			tempRigidBody = projectile2Handler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (-projectileSpeedLow, projectileLowUp);

			projectile2Handler.name = "Low2";
			Lists.p2cprojectilelist.Add (projectile2Handler);

//			tempRigidBody.name = "P2_Bullet";
//			ProjectileLists.p2List.Add (tempRigidBody);

			if (combo1 == true) {
				combo1 = false;
			}

			if (combo2 == true) {
				combo2 = false;
			}

			if (combo3 == true) {
				combo3 = false;
			}

		}

		if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetButtonDown ("X360_X2") && projectileCounter < 1) {
			projectileCounter = 1;

			GameObject projectile2Handler;

			projectile2Handler = Instantiate (projectile2M, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;
			tempRigidBody = projectile2Handler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (-projectileSpeedMed, projectileMedUp);

			projectile2Handler.name = "Mid2";
			Lists.p2cprojectilelist.Add (projectile2Handler);

//			tempRigidBody.name = "P2_Bullet";
//			ProjectileLists.p2List.Add (tempRigidBody);

			if (combo1 == true) {
				combo1 = false;
			}

			if (combo2 == true) {
				combo2 = false;
			}

			if (combo3 == true) {
				combo3 = false;
			}

		}

		if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetButtonDown ("X360_Y2") && projectileCounter < 1) {
			projectileCounter = 1;
			GameObject projectile2Handler;

			projectile2Handler = Instantiate (projectile2H, p2SpawnPointH.transform.position, p2SpawnPointH.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;
			tempRigidBody = projectile2Handler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (-projectileSpeedHigh, projectileHighUp);

			projectile2Handler.name = "High2";
			Lists.p2cprojectilelist.Add (projectile2Handler);

			if (combo1 == true) {
				combo1 = false;
			}

			if (combo2 == true) {
				combo2 = false;
			}

			if (combo3 == true) {
				combo3 = false;
			}

//			tempRigidBody.name = "P2_Bullet";
//			ProjectileLists.p2List.Add (tempRigidBody);

		}
		} else {
			currentBeat = false;
			projectileCounter = 0;
			if (currentBeat == false && canFire == false) 
			{
				print("canfire");
				canFire = true;
			}
		}
			
		if (Fira.check ()) 
		{
			combo1 = true;

		}

		if (Thundara.check ()) 
		{
			combo2 = true;

		}

		if (Blizzara.check ()) 
		{
			combo3 = true;

		}

	}

	IEnumerator SwapCombo(){

		yield return new WaitForSeconds (1f);
		combo3SwapRB.transform.position = new Vector3 (0, p2SpawnPointH.transform.position.y, 1);


	}

}
