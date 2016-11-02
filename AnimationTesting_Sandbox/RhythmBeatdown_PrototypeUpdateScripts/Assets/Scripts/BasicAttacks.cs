using UnityEngine;
using System.Collections;

public class BasicAttacks : MonoBehaviour {

	public GameObject projectileH;
	public GameObject projectileM;
	public GameObject projectileL;
	public GameObject p1SpawnPointH;
	public GameObject p1SpawnPointM;
	public GameObject p1SpawnPointL;
	public GameObject p2SpawnPointH;
	public GameObject p2SpawnPointM;
	public GameObject p2SpawnPointL;


	public float projectileForce = 300f;

	public void AttackHi_P1()
	{
		GameObject projectileHandler;

		projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;

		Rigidbody tempRigidBody;
		tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
		tempRigidBody.AddForce (transform.forward * projectileForce);
	}
}
