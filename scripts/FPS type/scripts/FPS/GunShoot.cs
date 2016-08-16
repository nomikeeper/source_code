using UnityEngine;
using System.Collections;

public class GunShoot : MonoBehaviour {

	public float FireRate = .25f;
	public float FireRange = 50f;
	public float FireDmg = 50f;
	public Transform gunEnd;

	//private Variables
	private Camera FpsCam;
	private LineRenderer lineRenderer;
	private WaitForSeconds shotLength = new WaitForSeconds (.07f);
	private float nextFireTime;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		FpsCam = GetComponentInParent <Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 RayOrigin = FpsCam.ViewportToWorldPoint(new Vector3(.5f,.5f,0));

		if (Input.GetButtonDown ("Fire1") && Time.time > nextFireTime) {
			nextFireTime = Time.time + FireRate;

			if (Physics.Raycast (RayOrigin, FpsCam.transform.forward,out hit, FireRange)) 
			{
				Health enemyHealth = hit.collider.gameObject.GetComponent<Health> ();
				if (enemyHealth) {
					enemyHealth.TakeDamage (FireDmg, hit.point);
				}

				if (hit.rigidbody) {
					hit.rigidbody.AddForce (-hit.normal * 100f);
				}
				lineRenderer.SetPosition (0, gunEnd.position);
				lineRenderer.SetPosition (1, hit.point);
			}
			StartCoroutine (ShotEffect());
		}

	}

	private IEnumerator ShotEffect()
	{
		lineRenderer.enabled = true;
		yield return shotLength;
		lineRenderer.enabled = false;
	}
}
