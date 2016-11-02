using UnityEngine;
using System.Collections;

public class StandardAttacks : MonoBehaviour
{

	public int attackCount = 0;
	public Animator anim;

	void Start ()
	{
		anim = this.GetComponent<Animator> ();
	}

	void OnEnable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			InputManager.P1_A += LowAttack;
			InputManager.P1_X += MedAttack;
			InputManager.P1_Y += HighAttack;
			InputManager.P1_B += Dodge;
			InputManager.P1_RangedA += RangedLowAttack;
			InputManager.P1_RangedX += RangedMedAttack;
			InputManager.P1_RangedY += RangedHighAttack;
			InputManager.P1_RBump += Block;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			InputManager.P2_A += LowAttack;
			InputManager.P2_X += MedAttack;
			InputManager.P2_Y += HighAttack;
			InputManager.P2_B += Dodge;
			InputManager.P2_RangedA += RangedLowAttack;
			InputManager.P2_RangedX += RangedMedAttack;
			InputManager.P2_RangedY += RangedHighAttack;
			InputManager.P2_RBump += Block;
		}
	}

	void OnDisable ()
	{
		if (this.gameObject.tag == "Player_One")
		{
			InputManager.P1_A -= LowAttack;
			InputManager.P1_X -= MedAttack;
			InputManager.P1_Y -= HighAttack;
			InputManager.P1_B -= Dodge;
			InputManager.P1_RangedA -= RangedLowAttack;
			InputManager.P1_RangedX -= RangedMedAttack;
			InputManager.P1_RangedY -= RangedHighAttack;
			InputManager.P1_RBump -= Block;
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			InputManager.P2_A -= LowAttack;
			InputManager.P2_X -= MedAttack;
			InputManager.P2_Y -= HighAttack;
			InputManager.P2_B -= Dodge;
			InputManager.P2_RangedA -= RangedLowAttack;
			InputManager.P2_RangedX -= RangedMedAttack;
			InputManager.P2_RangedY -= RangedHighAttack;
			InputManager.P2_RBump -= Block;
		}
	}

	void LowAttack ()
	{
		
		if (BoteManager.onBote == true && attackCount < 1)
		{
			//attackCount++;
			anim.SetTrigger ("LowAttack");
			print ("Low Attack");
		}
		else
		{
			attackCount = 0;
		}

	}

	void MedAttack ()
	{	
		if (BoteManager.onBote == true && attackCount < 1)
		{
			//attackCount++;
			anim.SetTrigger ("MedAttack");
			print ("Med Attack");
		}
		else
		{
			attackCount = 0;
		}
	}

	void HighAttack ()
	{
		if (BoteManager.onBote == true)
		{

			anim.SetTrigger ("HighAttack");
			print ("High Attack");
		}
		else
		{
			attackCount = 0;
		}
	}

	void Dodge ()
	{
		print ("Dodge");
	}

	//Ranged Attacks
	void RangedLowAttack ()
	{
		if (BoteManager.onBote == true && attackCount < 1)
		{
			//attackCount++;
			anim.SetTrigger ("RangedAttack");
			print ("Ranged Low Attack");
		}
		else
		{
			attackCount = 0;
		}

	}

	void RangedMedAttack ()
	{
		if (BoteManager.onBote == true && attackCount < 1)
		{
			//attackCount++;
			anim.SetTrigger ("RangedAttack");
			print ("Ranged Med Attack");
		}
		else
		{
			attackCount = 0;
		}
	}

	void RangedHighAttack ()
	{
		if (BoteManager.onBote == true && attackCount < 1)
		{
			//attackCount++;
			anim.SetTrigger ("RangedAttack");
			print ("Ranged High Attack");
		}
		else
		{
			attackCount = 0;
		}
	}

	void Block(bool block)
	{
		if (block)
		{
			anim.SetBool ("Block", true);
		}
		else
		{
			anim.SetBool ("Block", false);
		}
	}
}
