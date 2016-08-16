using UnityEngine;
using System.Collections;

public class glassBeh : MonoBehaviour {

	private ballMovement bm;
	// Use this for initialization
	void Start () {
		bm = GameObject.Find ("Ball").GetComponent<ballMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5.5f) {
			Destroy (gameObject);
		}
	}
}
