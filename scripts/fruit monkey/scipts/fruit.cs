using UnityEngine;
using System.Collections;

public class fruit : MonoBehaviour {

	public float f_fallSpeed = 3f;
	public int point = 1;
	private int f_SpeedMultiplier = 1;
	private Rigidbody2D f_rb;

	void Awake()
	{
		f_rb = GetComponent<Rigidbody2D> ();
	}
	void FixedUpdate()
	{
		Vector2 falling = -Vector2.up * f_fallSpeed * f_SpeedMultiplier * Time.deltaTime;
		f_rb.position += falling;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			monkeyMove mk = other.gameObject.GetComponent<monkeyMove> ();
			mk.GetPoint (point);
			Destroy (gameObject);
		} 
		else if (other.gameObject.CompareTag ("ground")) {
			Destroy (gameObject);
		}
	}
}
