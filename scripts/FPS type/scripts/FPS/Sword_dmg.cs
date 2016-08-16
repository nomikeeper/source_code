using UnityEngine;
using System.Collections;

public class Sword_dmg : MonoBehaviour {

	public float dmg = 50f;

	private bool attacking;
	// Use this for initialization
	void Start () {
		attacking = false;
	}
	void Update()
	{
	}

	public void Check(bool attack)
	{
		attacking = attack;
		Debug.Log ("Shiet" + attack);
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy") && attacking == true) {
			Health hp = other.gameObject.GetComponent<Health> ();
			hp.TakeDamage (dmg, new Vector3(0f,0f,0f));
		}
	}
}
