using UnityEngine;
using System.Collections;

public class Combo : MonoBehaviour {

	public KeyCode[] keys;

	public int index;
	public float inBetweenTime;
	public float lastKeyPressTime;

	public Combo (KeyCode[] k)
	{
		index = 0;
		inBetweenTime = 15.0f;
		lastKeyPressTime = 0.0f;
		keys = k;

	}

	public bool check()
	{
		if (Time.time > lastKeyPressTime + inBetweenTime) 
		{
			index = 0;
			lastKeyPressTime = Time.time;
			return false;
		} 

		else 
		{

			if (index < keys.Length) 
			{

				if (Input.GetKeyDown (keys[index])) 
				{
					lastKeyPressTime = Time.time;
					index++;

					if (index >= keys.Length)
					{
						index = 0;
						return true;
					} 

					else 	
					{
						return false;
					}
				} 

				else 
				{
					return false;
				}
			} 

			else 
			{
				return false;
			}
		}
	}

}