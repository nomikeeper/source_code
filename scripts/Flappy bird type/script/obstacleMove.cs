using UnityEngine;
using System.Collections;

public class obstacleMove : MonoBehaviour {
	public float obstacleSpeed = 5f;
	// Use this for initialization
	void Start () {
		/*spawnPoint = GameObject.FindGameObjectWithTag ("Spawn");
		transform.position = spawnPoint.transform.position;*/
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= transform.right * obstacleSpeed * Time.deltaTime; 

		if (transform.position.x < -16.5f) 
		{
			Destroy (gameObject);
		}
	}
}
