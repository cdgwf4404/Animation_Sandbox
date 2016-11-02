using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public string fighterName;

	protected Animator animator;
	private Rigidbody myBody;
	public FighterStates currentState = FighterStates.Idle;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Rigidbody body{
		get{ 
			return this.myBody;
		}
	}

	public bool attacking{
		get {
			return currentState == FighterStates.Attack;
		}

	}
	public bool gettingHit{
		get {
			return currentState == FighterStates.TakeHit;
		}

	}

	public bool blocking{
		get{ 
			return currentState == FighterStates.Block;
		}
	}
}
