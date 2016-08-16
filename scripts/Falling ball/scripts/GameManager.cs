using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    public Text scoreTxt;
	public Text SessionScore;
	public Text BestScore;

	private float score = 0;
	private float counter = 0;
	private int scoreText = 0;
	private float multiplier = 1;
    private bool playerState;
	private Animator anim;
    private WaitForSeconds w8 = new WaitForSeconds(1f);
	// Use this for initialization
	void Start () {
        playerState = true;
        //StartCoroutine(ScoreNum(score));
		anim = GameObject.Find("EndGame").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerState && Input.touchCount != 0 || !playerState && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		if (playerState == true) {
			score = score + (Time.deltaTime * multiplier);
			counter = counter + (Time.deltaTime * multiplier);
			setScore ();
			SetMultiplier ();
		}

    }

/*    IEnumerator ScoreNum(int score)
    {
        while (playerState == true)
        {
            yield return w8;
			score = score + multiplier;
            scoreTxt.text = score.ToString();
        }
    }*/

    public void gameOver()
    {
		int HighScore = PlayerPrefs.GetInt ("BestScore", 0);
		if (scoreText > HighScore) {
			PlayerPrefs.SetInt ("BestScore", scoreText);
		}
		BestScore.text = PlayerPrefs.GetInt ("BestScore", 0).ToString();
		SessionScore.text = scoreTxt.text;
        playerState = false;
        anim.SetTrigger("isDead");
    }

	void setScore()
	{
		scoreText = Convert.ToInt32 (score);
		scoreTxt.text = scoreText.ToString();
	}
	void SetMultiplier()
	{
		if(counter >= 50)
		{
			multiplier = multiplier + .5f;
			counter = 0;
			Debug.Log (multiplier);
		}
	}
}
