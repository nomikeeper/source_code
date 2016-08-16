using UnityEngine;
using System.Collections;

public class ballRotation : MonoBehaviour {

	public float b_rotateSpeed = 5f;
	private float accelrate;
	void Awake()
	{
		accelrate = 1;
	}
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, -90f) * accelrate *b_rotateSpeed * Time.deltaTime);
	}
	public void Accelrator(float speedUp)
	{
		accelrate = speedUp;
	}
}
