using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float MaxHealth = 100f;

	private float CurrentHealth;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (CurrentHealth <= 0) {
			Destroy (gameObject);
		}
			
	}

	public void TakeDamage( float dmg, Vector3 hitPoint)
	{
		CurrentHealth -= dmg;
		Debug.Log(CurrentHealth);
	}


}
