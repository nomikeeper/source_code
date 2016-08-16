using UnityEngine;
using System.Collections;

public class miniBullet : MonoBehaviour {

    public LayerMask c_CarMask;
    public float damage = 1.5f;
    public float c_MaxLifeTime = 2f;
	// Use this for initialization
	void Start () {
	
	}

    private void OnTriggerEnter(Collider other) 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, c_CarMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;


            CarHealth targetHealth = targetRigidbody.GetComponent<CarHealth>();

            if (!targetHealth)
                continue;

            targetHealth.TakeDamage(damage);
        }

        Destroy(gameObject, c_MaxLifeTime);
    }
}
