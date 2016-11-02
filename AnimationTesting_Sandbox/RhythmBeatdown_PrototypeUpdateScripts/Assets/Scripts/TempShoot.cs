using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TempShoot : MonoBehaviour {

	public GameObject projectileH;
	public GameObject projectileM;
	public GameObject projectileL;
	public GameObject p1SpawnPointH;
	public GameObject p1SpawnPointM;
	public GameObject p1SpawnPointL;

	public BasicAttacks basic;

	public Rigidbody combo3SwapRB;

	private Combo Thundara = new Combo (new KeyCode[] { KeyCode.K, KeyCode.J, KeyCode.L });
	private Combo Fira = new Combo (new KeyCode[] { KeyCode.J, KeyCode.J, KeyCode.L });
	private Combo Blizzara = new Combo (new KeyCode[] { KeyCode.L, KeyCode.K, KeyCode.J });

	private bool combo1 = false;
	private bool combo2 = false;
	private bool combo3 = false;

	public float projectileHighUp = 15f;
	public float projectileMedUp = 6f;
	public float projectileLowUp = 3f;

	public float projectileSpeedHigh = 7f;
	public float projectileSpeedMed = 16f;
	public float projectileSpeedLow = 20f;


	public float comboForce = 450f;

	private bool currentBeat = true;
	private bool canFire = true;
	private int projectileCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("X360_B2"))
		{
			print("I pressed player 2 b button");
		}
		if (Input.GetButtonDown("X360_B"))
		{
			print("I pressed player 1 b button");
		}



		if (PlayMusic.onBeat) {

			currentBeat = true;


			if (Input.GetKeyDown (KeyCode.I)||Input.GetButtonDown("X360_B") && combo1 == true && projectileCounter < 1 ) 
		{
			projectileCounter = 1;
			GameObject projectileHandler;

			projectileHandler = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;


			tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
			tempRigidBody.AddForce (transform.forward * comboForce);


			combo1 = false;
		}	

			if (Input.GetKeyDown (KeyCode.I)||Input.GetButtonDown("X360_B") && combo2 == true && projectileCounter < 1 ) {
				projectileCounter = 1;
				GameObject projectileHandler;
				GameObject projectileHandler2;

				projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;
				projectileHandler2 = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;

				Rigidbody tempRigidBody;
				Rigidbody tempRigidBody2;

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileHighUp);

				tempRigidBody2 = projectileHandler2.GetComponent<Rigidbody> ();
				tempRigidBody2.AddForce (transform.forward * projectileSpeedMed);

				combo2 = false;
			}

			if (Input.GetKeyDown (KeyCode.I)||Input.GetButtonDown("X360_B") && combo3 == true && projectileCounter < 1 ) 
		{
			projectileCounter = 1;
			GameObject projectileHandler;

			projectileHandler = Instantiate (projectileL, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;

			Rigidbody tempRigidBody;

			tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
			tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileLowUp);

			combo3SwapRB = tempRigidBody;
			//tempRigidBody.transform.position = new Vector3 (0, p1SpawnPointH.transform.position.y, 1);

			StartCoroutine (SwapCombo ());

			combo3 = false;
		}
			
			if (Input.GetKeyDown (KeyCode.J)||Input.GetButtonDown("X360_Y") && projectileCounter < 1 ) {
				projectileCounter = 1;
				GameObject projectileHandler;

				projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;

				Rigidbody tempRigidBody;
				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedHigh, projectileHighUp);

				projectileHandler.name = "High";
				Lists.p1aprojectilelist.Add (projectileHandler);

				if (combo1 == true) 
				{
					combo1 = false;
				}

				if (combo2 == true) 
				{
					combo2 = false;
				}

				if (combo3 == true) 
				{
					combo3 = false;
				}


//			tempRigidBody.name = "P1_Bullet";
//			ProjectileLists.p1List.Add (tempRigidBody);
			}

			if (Input.GetKeyDown (KeyCode.K)||Input.GetButtonDown("X360_X") && projectileCounter < 1 ) {
				projectileCounter = 1;
				GameObject projectileHandler;

				projectileHandler = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;

				Rigidbody tempRigidBody;
				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedMed, projectileMedUp);

				projectileHandler.name = "Mid";
				Lists.p1bprojectilelist.Add (projectileHandler);

				if (combo1 == true) 
				{
					combo1 = false;
				}

				if (combo2 == true) 
				{
					combo2 = false;
				}

				if (combo3 == true) 
				{
					combo3 = false;
				}

//			tempRigidBody.name = "P1_Bullet";
//			ProjectileLists.p1List.Add (tempRigidBody);
			}

			if (Input.GetKeyDown (KeyCode.L) ||Input.GetButtonDown("X360_A") && projectileCounter < 1 ) {
				projectileCounter = 1;
				GameObject projectileHandler;

				projectileHandler = Instantiate (projectileL, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;

				Rigidbody tempRigidBody;
				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedLow, projectileLowUp);

				projectileHandler.name = "Low";
				Lists.p1cprojectilelist.Add (projectileHandler);

				if (combo1 == true) 
				{
					combo1 = false;
				}

				if (combo2 == true) 
				{
					combo2 = false;
				}

				if (combo3 == true) 
				{
					combo3 = false;
				}


				print (Lists.p1aprojectilelist.Count);
				foreach (GameObject obj in Lists.p1aprojectilelist) {
					print (obj.name);
				}

//			tempRigidBody.name = "P1_Bullet";
//			ProjectileLists.p1List.Add (tempRigidBody);
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

		if (Thundara.check ()) 
		{
			combo1 = true;

		}

		if (Fira.check ()) 
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
		combo3SwapRB.transform.position = new Vector3 (0, p1SpawnPointH.transform.position.y, 1);
	
	
	}
}
