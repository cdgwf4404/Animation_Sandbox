using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 18;

    public float turnSpeed = 60;

    private Rigidbody rig;

	// Use this for initialization
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {

//        float dPadX = Input.GetAxis("X360_DPadX");
//
//        float dPadY = Input.GetAxis("X360_DPadY");
//
        float triggerAxis = Input.GetAxis("X360_Triggers");
		float triggerAxis2 = Input.GetAxis ("X360_Triggers2");
//		
//        if (dPadX != 0)
//        {
//            print("DPad Horizontal Value: " + dPadX);
//        }
//        if (dPadY != 0)
//        {
//            print("DPad Vertical Value: " + dPadY);
//        }
        if (triggerAxis != 0)
        {
            print("Trigger Value: " + triggerAxis);
        }
		if (triggerAxis2 != 0)
		{
			print("Trigger Value: " + triggerAxis2);
		}
        if (Input.GetButtonDown("X360_LBumper"))
        {
            print("Left Bumper");
        }
		if (Input.GetButtonDown("X360_LBumper2"))
		{
			print("P2 Left Bumper");
		}
        if (Input.GetButtonDown("X360_RBumper"))
        {
            print("Right Bumper");
        }
		if (Input.GetButtonDown("X360_RBumper2"))
		{
			print("P2 Right Bumper");
		}
        if (Input.GetButtonDown("X360_A"))
        {
            print("A Button");
        }
		if (Input.GetButtonDown("X360_A2"))
		{
			print("P2 A Button");
		}
        if (Input.GetButtonDown("X360_B"))
        {
            print("B Button");
		} 
		if (Input.GetButtonDown("X360_B2"))
		{
			print("P2 B Button");
		}
        if (Input.GetButtonDown("X360_X"))
        {
            print("X Button");
        }
		if (Input.GetButtonDown("X360_X2"))
		{
			print("P2 X Button");
		}
        if (Input.GetButtonDown("X360_Y"))
        {
            print("Y Button");
        }
		if (Input.GetButtonDown("X360_Y2"))
		{
			print("P2 Y Button");
		}
        if (Input.GetButtonDown("X360_Back"))
        {
            print("Back Button");
        }
		if (Input.GetButtonDown("X360_Back2"))
		{
			print("P2 Back Button");
		}
        if (Input.GetButtonDown("X360_Start"))
        {
            print("Start Button");
        }
		if (Input.GetButtonDown("X360_Start2"))
		{
			print("P2 Start Button");
		}
        if (Input.GetButtonDown("X360_LStick_Click"))
        {
            print("Clicked Left Stick");
		} 
		if (Input.GetButtonDown("X360_LStick_Click2"))
		{
			print("P2 Clicked Left Stick");
		}
//        if (Input.GetButtonDown("X360_RStick_Click"))
//        {
//            print("Clicked Right Stick");
//        }

        float hAxis = Input.GetAxis("Horizontal");
       // float vAxis = Input.GetAxis("Vertical");

//        float rStickX = Input.GetAxis("X360_RStickX");

        Vector3 movement = transform.TransformDirection(new Vector3(hAxis, 0, 0) * speed * Time.deltaTime);

        rig.MovePosition(transform.position + movement);

//        Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

//        transform.Rotate(new Vector3(0, rStickX, 0), turnSpeed * Time.deltaTime);
	}
}
