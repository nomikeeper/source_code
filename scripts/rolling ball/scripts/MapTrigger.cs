using UnityEngine;
using System.Collections;

public class MapTrigger : MonoBehaviour {

	public Transform point;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			mapGenerator m_Gen = GameObject.Find ("Map generator").GetComponent<mapGenerator> ();
			if (m_Gen) {
				m_Gen.CreatePrefab (point);
			}
		}
	}
}
