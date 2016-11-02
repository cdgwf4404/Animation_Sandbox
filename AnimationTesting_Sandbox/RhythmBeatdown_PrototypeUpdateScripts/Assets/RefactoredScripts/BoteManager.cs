using UnityEngine;
using System.Collections;

public class BoteManager : MonoBehaviour {

	public static bool onBote = false;

	void OnEnable()
	{
		AudioProcessor.OnBote += BoteEvent;
	}

	void OnDisable()
	{
		AudioProcessor.OnBote -= BoteEvent;
	}

	void BoteEvent()
	{
		onBote = !onBote;
		//print (onBote);
	}
}
