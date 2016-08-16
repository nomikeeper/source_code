using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObsGenerate : MonoBehaviour {

	public GameObject[] obss;
	public GameObject glass;
    public GameObject warningImg;
    public bool playerState;

	float minTime = 7f;
	float maxTime = 9.5f;
	float glassMinTime = 5f;
	float glassMaxTime = 8f;
	float spawnTime;
	float gSpawnTime;
	float glassTimer;
	float timer;
    int quickSave;
    int prevSave;
    WaitForSeconds w8 = new WaitForSeconds(2f);
	// Use this for initialization
	void Start () {
        playerState = true;
		setRandomTimeObs ("");
		setRandomTimeGlass ();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerState)
        { 
		    timer += Time.deltaTime;
		    glassTimer += Time.deltaTime;

            if (timer >= spawnTime) {
                genObject();
                if (prevSave == 0) {
                    setRandomTimeObs("edge");
                }
                else { 
                    setRandomTimeObs("");
                }
            }

		    if( glassTimer >= gSpawnTime)
		    {
			    genGlass ();
			    setRandomTimeGlass ();
		    }
        }
    }

	float genRandomFloat(string type)
	{
        if (type == "obs") {
            return Random.Range(-2f, 2f);
        }
        else if (type == "static")
        {
            return Random.Range(-2.5f, 2.5f);
        }
        else {
            return Random.Range(-2.4f, 2.4f);
        }
	}
	void genObject()
	{
		timer = 0;
        while(prevSave == quickSave)
        {
            quickSave = Random.Range(0, obss.Length);
        }
        Vector3 spawnPoint;
        GameObject obs = obss[quickSave];
        if (quickSave == 0)
        {
            spawnPoint = new Vector3(0f, -6f, 0f);
        }
        else if (quickSave == 2)
        {
            spawnPoint = new Vector3(genRandomFloat("static"), -6f, 0);
        }
        else
        {
            spawnPoint = new Vector3(genRandomFloat("obs"), -6f, 0);
        }
        prevSave = quickSave;
        
		Instantiate (obs, spawnPoint, Quaternion.identity);
	}
	void genGlass()
	{
		glassTimer = 0;
        Vector3 spawnPoint = new Vector3(genRandomFloat("glass"), 5.5f, 0);
        StartCoroutine(warn(spawnPoint));   
	}
	void setRandomTimeObs(string edge)
	{
        if (edge == "egde")
            spawnTime = Random.Range(9f, 11f);
        else
            spawnTime = Random.Range(minTime, maxTime);
	}
	void setRandomTimeGlass()
	{
		gSpawnTime = Random.Range (glassMinTime, glassMaxTime);
	}

    IEnumerator warn(Vector3 spawn)
    {
        Vector3 val = spawn + new Vector3(0,-1.5f,0);
        warningImg.transform.position = val;
        Instantiate(warningImg,val,Quaternion.identity);
        yield return w8;
        Instantiate(glass, spawn, Quaternion.identity);
    }

    public void setPlayerState()
    {
        playerState = false;
    }
}
