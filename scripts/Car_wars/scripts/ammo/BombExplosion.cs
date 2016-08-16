using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {

	public LayerMask c_CarMask;
	public float c_MaxDamage = 100f;
	public float c_ExplosionForce = 1000f;
	public float c_ExplosionRadius = 5f;


    private float c_MaxLifeTime = 5f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, c_MaxLifeTime);
	}

	private void OnTriggerEnter (Collider other)
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, c_ExplosionRadius, c_CarMask);

		for (int i = 0; i < colliders.Length; i++) 
		{
			Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();

			if (!targetRigidbody)
				continue;

			targetRigidbody.AddExplosionForce (c_ExplosionForce, transform.position, c_ExplosionRadius);


			CarHealth targetHealth = targetRigidbody.GetComponent<CarHealth> ();

			if (!targetHealth)
				continue;

			float damage = CalculateDamage (targetRigidbody.position);

			targetHealth.TakeDamage (damage);
		}

		Destroy (gameObject);
	}

	private float CalculateDamage(Vector3 targetPosition)
	{
		Vector3 explosionToTarget = targetPosition - transform.position;

		float explosionDistance = explosionToTarget.magnitude;

		float relativeDistance = (c_ExplosionRadius - explosionDistance) / c_ExplosionRadius;

		float damage = relativeDistance * c_MaxDamage;

		damage = Mathf.Max (0f, damage);

		return damage;
	}
}

