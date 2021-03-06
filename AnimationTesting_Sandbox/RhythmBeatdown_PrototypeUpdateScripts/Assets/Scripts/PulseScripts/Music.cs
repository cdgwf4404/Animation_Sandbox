﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Music : MonoBehaviour {
	private int counter;
	public AudioSource musicClip;
	public AudioClip soundBite;
	private float beat;
	private float displayLength = 0.25f;//0.1
	private Vector3 initialDisplay;
	private Vector3 fullDisplay;
	public GameObject displayCube;
	public float expandLerpTimeScale = 2;//2
	public float returnLerpTimeScale = 1;//1
	public static bool onBeat= false;
	private Color green = Color.green;
	private Color red = Color.red;
	private double sampleCalc;

	private GameObject coyoteIcon;
	private Vector3 coyNrmScl;
	private Vector3 coyBeatScl;
	private bool setupDelay = false;
	public float waitTime = 0.02f;
	public static float soloTimer = 0;
	private float timeSinceStart = 0;
	private bool soloModeOneStart = false;

	public delegate void soloModeStart();
	public static event soloModeStart OnStart;
	public int quarterBeatsnum;
	public static bool turnOff= false;

	private float[] palladioList = new float[] {
		0.283f,
		0.94f,
		1.597f,
		2.254f,
		2.911f,
		3.568f,
		4.225f,
		4.882f,
		5.539f,
		5.736f,
		5.898f,
		6.029f,
		6.222f,
		6.748f,
		6.899f,
		7.061f,
		7.213f,
		8.346f,
		8.508f,
		8.639f,
		8.832f,
		9.358f,
		9.509f,
		9.671f,
		9.823f,
		10.966f,
		11.128f,
		11.259f,
		11.452f,
		11.978f,
		12.129f,
		12.291f,
		12.443f,
		13.627f,
		13.799f,
		13.945f,
		14.117f,
		14.259f,
		14.446f,
		14.593f,
		14.740f,
		14.901f,
		15.068f,
		16.252f,
		16.414f,
		16.545f,
		16.738f,
		17.264f,
		17.415f,
		17.577f,
		17.729f,
		18.862f,
		19.024f,
		19.155f,
		19.348f,
		19.874f,
		20.025f,
		20.187f,
		20.339f,
		21.482f,
		21.644f,
		21.775f,
		21.968f,
		22.494f,
		22.645f,
		22.807f,
		22.959f,
		24.143f,
		24.315f,
		24.461f,
		24.633f,
		24.775f,
		24.962f,
		25.109f,
		25.256f,
		25.417f,
		25.584f,
		26.788f,
		26.910f,
		27.051f,
		27.269f,
		27.527f,
		27.916f,
		28.078f,
		28.260f,
		29.363f,
		29.485f,
		29.626f,
		29.844f,
		30.102f,
		30.491f,
		30.653f,
		30.835f,
		31.998f,
		32.195f,
		32.352f,
		32.529f,
		32.863f,
		33.177f,
		34.649f,
		34.846f,
		35.003f,
		35.180f,
		35.514f,
		35.828f,
		37.334f,
		37.531f,
		37.688f,
		37.865f,
		38.199f,
		38.513f,
		39.899f,
		40.096f,
		40.253f,
		40.430f,
		40.764f,
		41.078f,
		42.382f,
		43.050f,
		43.768f,
		45.003f,
		45.175f,
		45.321f,
		45.493f,
		45.650f,
		45.807f,
		45.969f,
		46.146f,
		46.292f,
		46.434f,
		46.621f,
		46.783f,
		46.975f,
		47.132f,
		47.309f,
		47.441f,
		47.668f,
		47.830f,
		47.961f,
		48.154f,
		48.680f,
		48.831f,
		48.993f,
		49.145f,
		50.278f,
		50.440f,
		50.571f,
		50.764f,
		51.290f,
		51.441f,
		51.603f,
		51.755f,
		52.898f,
		53.060f,
		53.191f,
		53.384f,
		53.910f,
		54.061f,
		54.223f,
		54.375f,
		55.559f,
		55.731f,
		55.877f,
		56.049f,
		56.191f,
		56.378f,
		56.525f,
		56.672f,
		56.833f,
		57.000f,
		//Fill Here
		89.762f,
		89.924f,
		90.055f,
		90.248f,
		90.774f,
		90.925f,
		91.087f,
		91.239f,
		92.372f,
		92.534f,
		92.665f,
		92.858f,
		93.384f,
		93.535f,
		93.697f,
		93.849f,
		94.992f,
		95.154f,
		95.285f,
		95.478f,
		96.004f,
		96.155f,
		96.317f,
		96.469f,
		97.653f,
		97.825f,
		97.971f,
		98.143f,
		98.285f,
		98.472f,
		98.619f,
		98.766f,
		98.927f,
		99.094f,
		//FIll Here
		150.198f,
		150.360f,
		150.491f,
		150.684f,
		151.210f,
		151.361f,
		151.523f,
		151.675f,
		152.808f,
		152.970f,
		153.101f,
		153.294f,
		153.820f,
		153.971f,
		154.133f,
		154.285f,
		155.428f,
		155.590f,
		155.721f,
		155.914f,
		156.440f,
		156.591f,
		156.753f,
		156.905f,
		158.089f,
		158.261f,
		158.407f,
		158.579f,
		158.721f,
		158.908f,
		159.055f,
		159.202f,
		159.363f,
		159.530f,
		//Fill Here
		189.667f,
		189.829f,
		189.960f,
		190.153f,
		190.679f,
		190.830f,
		190.992f,
		191.144f,
		192.277f,
		192.439f,
		192.570f,
		192.763f,
		193.289f,
		193.440f,
		193.602f,
		193.754f,
		194.897f,
		195.059f,
		195.190f,
		195.383f,
		195.909f,
		196.060f,
		196.222f,
		196.374f,
		197.558f,
		197.730f,
		197.876f,
		198.048f,
		198.190f,
		198.377f,
		198.524f,
		198.671f,
		198.832f,
		198.999f,
		//Continue to End

	};



	public AudioSource newSong;

	// Use this for initialization
	void Start () {
		counter = 1;
		beat = 0.6570490196f;
		initialDisplay = displayCube.transform.localScale;
		fullDisplay = new Vector3(2.5f, 2.5f, 2.5f);

		coyoteIcon = GameObject.Find ("Coyote_Icon");
		coyNrmScl = coyoteIcon.transform.localScale;
		coyBeatScl = new Vector3 (1.2f, 1.2f, 1.2f);
		StartActivateDisplay ();
		StartCoroutine(checkQuarterBeats ());
	}

	void StartActivateDisplay()
	{
		StartCoroutine ("ActivateDisplay");
	}



	IEnumerator beatsSpeed()
	{
		if(Time.time >= 69f+timeSinceStart && turnOff ==false)//69seconds into the song for the first solomode
		{
			soloModeOneStart = true;
			SoloModeButtons.SoloMode = true;
			print ("69seconds plus" + timeSinceStart);
			if (OnStart != null) {
				print ("quarter");
				OnStart ();
			}
		}

		if(Time.time >=90 + timeSinceStart)
		{
			//turnOff = true;
			yield return new WaitForSeconds (0);
		}
		if (Time.time >= 79f + timeSinceStart)
		{
			yield return new WaitForSeconds (beat/4f);
			StartCoroutine (checkQuarterBeats ());
		}else
		{
			yield return new WaitForSeconds (beat/2f);
			StartCoroutine(halfSpeed ());
		}




	}

	IEnumerator checkQuarterBeats()
	{
		yield return new WaitForSeconds (beat / 4f);
		StartCoroutine (beatsSpeed ());
	}
	IEnumerator halfSpeed()
	{
		yield return new WaitForSeconds (beat / 2f);
		StartCoroutine (beatsSpeed ());
	}


	IEnumerator ActivateDisplay(){
		//		print ("Coroutine Started");
		//		print ("onbeat");
		//		if (setupDelay == false) {
		//			StartCoroutine (delay ());
		//			setupDelay = true;
		//		}
		//
		if (newSong.isPlaying == false) {
			newSong.Play ();
			timeSinceStart = Time.time;
		}


		//print (timeSinceStart);
		//print (SoloModeButtons.SoloMode);
		//if(Time.time >= 5f+timeSinceStart)
		//{
		//soloModeOneStart = true;
		//SoloModeButtons.SoloMode = true;
		//print ("110seconds plus" + timeSinceStart);
		//if (OnStart != null) {
		//	print ("subscribed");
		//	OnStart ();
		//}
		//}


		for (counter = 0; counter > 1000; counter++) {
			//double sampleCalc = ((counter * beat) - (displayLength/2) )* soundBite.frequency;
			double sampleCalc = ((palladioList[counter]) - (displayLength/2) )* soundBite.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			displayCube.transform.localScale = Vector3.Lerp(fullDisplay, initialDisplay, Time.deltaTime * returnLerpTimeScale);
			yield return new WaitForSeconds (displayLength);
			displayCube.transform.localScale = Vector3.Lerp(initialDisplay, fullDisplay, Time.deltaTime * expandLerpTimeScale);
		} 

		//			sampleCalc = ((counter * beat) - (displayLength / 2)) * soundBite.frequency;
		//			displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
		//			onBeat = false;
		//			print ("offbeat");
		//			while (musicClip.timeSamples < sampleCalc) yield return 0;
		//			onBeat = true;
		//			displayCube.GetComponent<MeshRenderer> ().material.color = Color.green;
		//			coyoteIcon.transform.localScale = Vector3.Lerp (coyNrmScl, coyBeatScl, Time.deltaTime * returnLerpTimeScale);
		//
		//			yield return new WaitForSeconds (displayLength);
		//			displayCube.transform.localScale = Vector3.Lerp(initialDisplay, fullDisplay, Time.deltaTime * expandLerpTimeScale);


		//			displayCube.transform.localScale = Vector3.one;
		//			coyoteIcon.transform.localScale = coyNrmScl;
		//		onBeat = true;
		//		yield return new WaitForSeconds (beat);
		//			displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
		//			displayCube.transform.localScale = Vector3.one * 2f;
		//		print ("offbeat");
		//		onBeat = false;
		//		StartCoroutine (OffBeat ());
	}

	IEnumerator OffBeat()
	{

		yield return new WaitForSeconds (beat);
		//print (Time.time);
		StartCoroutine (ActivateDisplay ());
	}



	IEnumerator delay()
	{

		yield return new WaitForSeconds (waitTime);



	}
	/*for (counter = 1; counter < 500; counter++){
			double sampleCalc = counter * beat * soundBite.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			onBeat = true;
			print("on beat");
			displayCube.transform.localScale = Vector3.Lerp(fullDisplay, initialDisplay, Time.deltaTime * returnLerpTimeScale);
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.green;
			yield return new WaitForSeconds (displayLength);
			onBeat = false;
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
			displayCube.transform.localScale = Vector3.Lerp(initialDisplay, fullDisplay, Time.deltaTime * expandLerpTimeScale);

		}*/


	// Update is called once per frame
	void Update () {


	}
}
