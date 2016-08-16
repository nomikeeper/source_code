using UnityEngine;
using System.Collections;

public class FruitGenerate : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject[] fruit;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateFruit", 1f,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void CreateFruit()
	{
		Instantiate (fruit [Random.Range (0,2)], new Vector3 (Random.Range (-4f,4f), spawnPoint.position.y, spawnPoint.position.z), Quaternion.identity);
	}
}
