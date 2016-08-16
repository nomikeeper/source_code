using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public Animator anim;
	public float TimeWindow = 1f;

	private bool isattack;
	private Sword_dmg swd;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
		swd = GetComponentInChildren<Sword_dmg> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) 
		{
			anim.SetBool ("isAttack_01",  true);
			bool test = anim.GetBool ("isAttack_01");
			if (test) {
				swd.Check (test);
				anim.Play ("attack_02");
				anim.SetBool ("isAttack_02", false);
			}
			else {
				swd.Check (false);
			}

		}
	}
}
