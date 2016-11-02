using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour {

	public int crowdDamage = 2;
	public int crescendoIncrease = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.tag == "projectile") {
			
			if (col.gameObject.name == "High2" && this.gameObject.tag == "Player_One") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();

			} else if (col.gameObject.name == "High" && this.gameObject.tag == "Player_Two") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();

			} else if (col.gameObject.name == "Mid2" && this.gameObject.tag == "Player_One") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();

			} else if (col.gameObject.name == "Mid" && this.gameObject.tag == "Player_Two") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();

				//Destroy (gameObject, bulletlife);  
			} else if (col.gameObject.name == "Low2" && this.gameObject.tag == "Player_One") {
				Lists.p2aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();

			} else if (col.gameObject.name == "Low" && this.gameObject.tag == "Player_Two") {
				Lists.p1aprojectilelist.Remove (col.gameObject);
				Destroy (col.gameObject);
				Damage ();


			}


		}
		
	}
	
	void OnCollisionEnter(Collision other)
	{
//		
//		if (other.gameObject.tag == "projectile") {
//			
//			if (other.gameObject.name == "High2") {
//				Lists.p2aprojectilelist.Remove (other.gameObject);
//
//			} else if (other.gameObject.name == "High") {
//				Lists.p1aprojectilelist.Remove (other.gameObject);
//
//			} else if (other.gameObject.name == "Mid2") {
//				Lists.p2aprojectilelist.Remove (other.gameObject);
//
//			} else if (other.gameObject.name == "Mid") {
//				Lists.p1aprojectilelist.Remove (other.gameObject);
//
//				//Destroy (gameObject, bulletlife);  
//			} else if (other.gameObject.name == "Low2") {
//				Lists.p2aprojectilelist.Remove (other.gameObject);
//
//			} else if (other.gameObject.name == "Low") {
//				Lists.p1aprojectilelist.Remove (other.gameObject);
//
//
//			}
//			Damage ();
//			Destroy (other.gameObject);
//		}
	}
	
	void Damage()
	{
		if (this.gameObject.tag == "Player_Two") {

			CrowdMeter.currentCrowdState -= crowdDamage;
			Crescendo.crescendoVal1 += crescendoIncrease;

		} else if (this.gameObject.tag == "Player_One") {

			CrowdMeter.currentCrowdState += crowdDamage;
			Crescendo.crescendoVal2 += crescendoIncrease;
		}
	}
}