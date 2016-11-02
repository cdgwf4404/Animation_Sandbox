using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour {
	private int counter;
	public AudioSource musicClip;
	public AudioClip soundBite;
	private float beat;
	private float displayLength = 0.1f;//0.1
	private Vector3 initialDisplay;
	private Vector3 fullDisplay;
	public GameObject displayCube;
	public float expandLerpTimeScale = 2;//2
	public float returnLerpTimeScale = 1;//1
	public static bool onBeat= false;
	private Color green = Color.green;
	private Color red = Color.red;
	private double sampleCalc;
	public GameObject spotlight;

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

	public AudioSource newSong;
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
		58.225f,
		58.387f,
		58.518f,
		58.711f,
		59.237f,
		59.388f,
		59.550f,
		59.702f,
		60.835f,
		60.997f,
		61.128f,
		61.321f,
		61.847f,
		61.998f,
		62.160f,
		62.312f,
		63.455f,
		63.617f,
		63.748f,
		63.941f,
		64.467f,
		64.618f,
		64.780f,
		64.932f,
		66.116f,
		66.288f,
		66.434f,
		66.606f,
		66.748f,
		66.935f,
		67.082f,
		67.229f,
		67.390f,
		67.557f,
		//Ba Da Da’s
		68.842f,
		68.968f,
		69.110f,
		69.459f,
		69.636f,
		69.752f,
		70.152f,
		70.278f,
		70.420f,
		70.769f,
		70.946f,
		71.062f,
		71.462f,
		71.588f,
		71.730f,
		72.079f,
		72.256f,
		72.372f,
		//More notes Needed
		// Left Off Here I60 through L 65
		74.128f,
		74.254f,
		74.396f,
		74.745f,
		74.922f,
		75.038f,
		75.428f,
		75.554f,
		75.696f,
		76.045f,
		76.222f,
		76.338f,
		76.722f,
		76.848f,
		76.990f,
		77.339f,
		77.516f,
		77.632f,
		78.027f,
		78.153f,
		78.295f,
		78.644f,
		78.821f,
		78.937f,
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
		100.263f,
		100.425f,
		100.556f,
		100.749f,
		101.275f,
		101.426f,
		101.588f,
		101.740f,
		102.873f,
		103.035f,
		103.166f,
		103.359f,
		103.885f,
		104.036f,
		104.198f,
		104.350f,
		105.493f,
		105.655f,
		105.786f,
		105.979f,
		106.505f,
		106.656f,
		106.818f,
		106.970f,
		108.154f,
		108.326f,
		108.472f,
		108.644f,
		108.786f,
		108.973f,
		109.120f,
		109.267f,
		109.428f,
		109.595f,
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
		160.754f,
		160.916f,
		161.047f,
		161.240f,
		161.766f,
		161.917f,
		162.079f,
		162.231f,
		163.364f,
		163.526f,
		163.657f,
		163.850f,
		164.376f,
		164.527f,
		164.689f,
		164.841f,
		165.984f,
		166.146f,
		166.277f,
		166.470f,
		167.147f,
		167.309f,
		167.461f,
		168.645f,
		168.817f,
		168.963f,
		169.135f,
		169.277f,
		169.464f,
		169.611f,
		169.758f,
		169.919f,
		170.086f,
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
		200.132f,
		200.294f,
		200.425f,
		200.618f,
		201.144f,
		201.295f,
		201.457f,
		201.609f,
		202.742f,
		202.904f,
		203.035f,
		203.228f,
		203.754f,
		203.905f,
		204.067f,
		204.219f,
		205.362f,
		205.524f,
		205.655f,
		205.848f,
		206.374f,
		206.525f,
		206.687f,
		206.839f,
		208.023f,
		208.195f,
		208.341f,
		208.513f,
		208.655f,
		208.842f,
		208.989f,
		209.136f,
		209.297f,
		209.464f,
		//Continue to End
	};
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
		StartCoroutine ("Lighting");
	}


	//This needs to be in a separate script and subscribed to AudioProcessor script
//	IEnumerator Lighting(){
//		for (counter = 1; counter < 1000; counter++) {
//			double sampleBeat = ((counter * beat) - 0.243) * soundBite.frequency;
//			while (musicClip.timeSamples < sampleBeat)
//				yield return 0; // wait till the desired sample
//			if (spotlight.active == true)
//				spotlight.SetActive (false);
//			else
//				spotlight.SetActive (true);
//		}
//	}

	IEnumerator ActivateDisplay(){
		if (newSong.isPlaying == false) {
			newSong.Play ();
			timeSinceStart = Time.time;
		}	

		for (counter = 0; counter < 1000; counter++) {
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
			sampleCalc = (palladioList[counter] - (displayLength / 2)) * soundBite.frequency;
			//sampleCalc = (((counter * beat) - 0.243) - (displayLength / 2)) * soundBite.frequency;
			while (musicClip.timeSamples < sampleCalc)
				yield return 0; // wait till the desired sample
			onBeat = true;
			displayCube.transform.localScale = Vector3.Lerp (fullDisplay, initialDisplay, Time.deltaTime * returnLerpTimeScale);
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.green;
			yield return new WaitForSeconds (displayLength);
			onBeat = false;
			displayCube.transform.localScale = Vector3.Lerp (initialDisplay, fullDisplay, Time.deltaTime * expandLerpTimeScale);
		} 

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



}
