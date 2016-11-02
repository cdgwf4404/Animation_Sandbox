using UnityEngine;
using System.Collections;

public class HitCollider : MonoBehaviour {

	private GameObject hitCol;
	public float damage;

	public Fighter owner;
	private Animator anim;
	// Use this for initialization
	void Start () {
		hitCol = this.gameObject;
	}
	
	void OnTriggerEnter(Collider col)
	{
		Fighter opponent = col.gameObject.GetComponent<Fighter> ();
		anim = col.gameObject.GetComponent<Animator> ();
		if (opponent != null && opponent != owner && owner.attacking)
		{
			if (!opponent.gettingHit && !opponent.blocking)
			{
				anim.SetTrigger ("TakeHit");
				print ("I hit " + opponent + " with " + hitCol);
			}
			else if (opponent.blocking)
			{
				anim.SetTrigger ("BlockHit");
			}
		}
	}


}
