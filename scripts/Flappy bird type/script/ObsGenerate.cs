using UnityEngine;
using System.Collections;

public class ObsGenerate : MonoBehaviour {

	public GameObject obs;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateObstacle", 1f ,1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateObstacle()
	{
		Instantiate (obs, new Vector2(transform.position.x,Random.Range(-1.5f, 1.5f)), Quaternion.identity);
	}
}
