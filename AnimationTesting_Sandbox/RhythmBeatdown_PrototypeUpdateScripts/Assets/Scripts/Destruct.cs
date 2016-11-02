using UnityEngine;
using System.Collections;

public class Destruct : MonoBehaviour {

	public Sprite[] missSprites;
	private int spriteNum;
	// Use this for initialization
	void Start () {
		StartCoroutine (disableTimer ());
		StartCoroutine (waitUntilMiss ());
		Destroy (this.gameObject, 50f);
		if (this.gameObject.tag == "A_Button") {
			spriteNum = 0;
		}
		if (this.gameObject.tag == "B_Button") {
			spriteNum = 1;
		}
		if (this.gameObject.tag == "X_Button") {
			spriteNum = 2;
		}
		if (this.gameObject.tag == "Y_Button") {
			spriteNum = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		print (SoloModeButtons.x360_A_Down);
	}

	IEnumerator disableTimer()
	{
		yield return new WaitForSeconds (3);
		this.gameObject.SetActive (false);
	}

	IEnumerator waitUntilMiss()
	{
	
		yield return new WaitForSeconds (1.25f);
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = missSprites [spriteNum];
	
	}

	void OnTriggerEnter(Collider col)
	{
		print("collision");
		if (col.gameObject.tag == "TriggerZones") 
		{
			if (SoloModeButtons.x360_A_Down == true)// && this.gameObject.tag =="A_Button")
				this.gameObject.SetActive (false);

			if (SoloModeButtons.x360_B_Down== true)//  && this.gameObject.tag =="B_Button")
				this.gameObject.SetActive (false);
			if (SoloModeButtons.x360_X_Down== true)//  && this.gameObject.tag =="X_Button")
				this.gameObject.SetActive (false);
			if (SoloModeButtons.x360_Y_Down== true)//  && this.gameObject.tag =="Y_Button")
				this.gameObject.SetActive (false);
			//check for static bool from x y a and b inputs, and check which button object this is and if they are the same destroy
			
		}
		
	}
}
