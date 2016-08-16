using UnityEngine;
using System.Collections;

public class mapGenerator : MonoBehaviour {

	public Transform cam;
	public GameObject[] map;

	private Transform spawn;
	private int prevNum;
	// Use this for initialization
	void Start () {
		prevNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 SpawnPosCal = new Vector3(15f,0,0);
		cam.position += SpawnPosCal;
		spawn = cam;
		if (Input.GetKeyDown ("x")) {
			GameObject terrain = Instantiate(map,new Vector3(spawn.position.x,spawn.position.y,spawn.position.z),Quaternion.identity) as GameObject;
		}
		sit = true;
		Debug.Log("Instantiated");
		*/
	}
	public void CreatePrefab(Transform pos)
	{
		/*Vector3 spawnPoint = new Vector3(20.5f,0,0);
		spawn = pos;*/
		float point = pos.position.x;
		point += 30f;
		prevNum = RandomNum (prevNum);
		GameObject mapGen = Instantiate (map[prevNum],new Vector3(point,-4.35f,0), Quaternion.identity) as GameObject;
	}
	int RandomNum(int some)
	{
		System.Random rand = new System.Random (); 
		if (some != null) {
			int inst;
			do {
				inst = rand.Next (0, map.Length);	
			} while(some == inst);
			return inst;
		} 
		else {
			return rand.Next (0, map.Length);
		}
	}
}
