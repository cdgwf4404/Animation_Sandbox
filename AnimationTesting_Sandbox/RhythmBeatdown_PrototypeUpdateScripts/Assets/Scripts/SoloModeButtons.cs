using UnityEngine;
using System.Collections;

public class SoloModeButtons : MonoBehaviour {


	public GameObject[] buttonPrefabs;
	public GameObject[] InputZones;
	public GameObject[] EndLocations;
	public GameObject[] SpawnLocations;
	public GameObject solomodeBar;
	public GameObject[] solomodeUIobjects;

	public Sprite[] darkSprites;
	private Sprite[] currentSprites;

	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	private bool readychange;
	private int randNum;

	public static bool SoloMode = false;
	private float quarterNotes = 0.647f/4f;
	public static bool x360_A_Down = false;
	public static bool x360_B_Down = false;
	public static bool x360_X_Down = false;
	public static bool x360_Y_Down = false;

	// Use this for initialization
	void Awake () {

		PlayMusic.OnStart += canSpawn;
		print ("I'm subscribed to canSpawn");
		currentSprites = new Sprite[4];
		currentSprites [0] = InputZones [0].GetComponent<SpriteRenderer> ().sprite;
		currentSprites [1] = InputZones [1].GetComponent<SpriteRenderer> ().sprite;
		currentSprites [2] = InputZones [2].GetComponent<SpriteRenderer> ().sprite;
		currentSprites [3] = InputZones [3].GetComponent<SpriteRenderer> ().sprite;

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("X360_A")) {
			InputZones [0].GetComponent<SpriteRenderer> ().sprite = darkSprites [0];
			//randNum = 0;

			x360_A_Down = true;

		} else if (Input.GetButtonUp ("X360_A")) 
		{
			InputZones [0].GetComponent<SpriteRenderer> ().sprite = currentSprites [0];
			x360_A_Down = false;
		}
		if (Input.GetButtonDown ("X360_B")) {
			x360_B_Down = true;
			InputZones [1].GetComponent<SpriteRenderer> ().sprite = darkSprites [1];
			//randNum = 1;
		} else if (Input.GetButtonUp ("X360_B")) 
		{
			x360_B_Down = false;
			InputZones [1].GetComponent<SpriteRenderer> ().sprite = currentSprites [1];

		}
		if (Input.GetButtonDown ("X360_X")) {
			x360_X_Down = true;
			InputZones [2].GetComponent<SpriteRenderer> ().sprite = darkSprites [2];
			//randNum = 2;
		} else if (Input.GetButtonUp ("X360_X")) {
			x360_X_Down = false;
			InputZones [2].GetComponent<SpriteRenderer> ().sprite = currentSprites [2];
		}
		if (Input.GetButtonDown ("X360_Y")) {
			x360_X_Down = true;
			InputZones [3].GetComponent<SpriteRenderer> ().sprite = darkSprites [3];
			//randNum = 3;
		} else if (Input.GetButtonUp ("X360_Y")) {
			x360_X_Down = false;
			InputZones [3].GetComponent<SpriteRenderer> ().sprite = currentSprites [3];
		}
		if (PlayMusic.turnOff == true) {
			//solomodeBar.gameObject.SetActive (false);
			//SoloMode = false;
		}


	
	}

	void canSpawn()
	{
		if (SoloMode == true) 
		{
			solomodeBar.SetActive (true);
			for (int i = 0; i < solomodeUIobjects.Length; i++) {
				solomodeUIobjects [i].gameObject.SetActive (true);
			}
			randNum = Random.Range (0, 4);
			print ("randomnumber" + randNum);
			
			StartCoroutine (spawnButtons (randNum, 10f));


			print ("i'm mr.Meseeks, Look at me!");
			
		}
	}



	IEnumerator spawnButtons(int randNums,float time)
	{
		
		//this needs a random num generator


		GameObject buttonObject;

		buttonObject = Instantiate (buttonPrefabs[randNums], SpawnLocations[randNums].transform.position, SpawnLocations[randNums].transform.rotation) as GameObject;
		//float elapsedTime = 0;

		for (float t =0;t<=1; t +=Time.deltaTime/time) {	
			
			buttonObject.transform.position = Vector3.Lerp (buttonObject.transform.position, EndLocations [randNums].transform.position, t);
			yield return new WaitForSeconds (0);


		}
	
	}


}
