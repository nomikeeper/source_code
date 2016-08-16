using UnityEngine;
using System.Collections;

public class mapClean : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("map")) {
			Destroy (other.gameObject);
		}
	}
}
