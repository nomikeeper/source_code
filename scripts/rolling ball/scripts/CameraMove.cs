using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform ball;
	private float max_depth = 5f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (ball) {
			Vector3 playerPos = ball.position;
			playerPos.z = transform.position.z;
			playerPos.y = transform.position.y;
			if(playerPos.y <= -4.5f)
			{
				playerPos.y = -4.5f;
			}
			transform.position = playerPos;
		}
	}
}
