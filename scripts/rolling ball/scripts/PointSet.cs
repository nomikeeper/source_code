using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointSet : MonoBehaviour {

	private int bestScore;
	private int totalScore;
	public Text Score;
	public Text BestScore;
	private int addCheck;
	// Use this for initialization
	void Start () {
		totalScore = PlayerPrefs.GetInt ("totalScore", 0);
		bestScore = PlayerPrefs.GetInt ("HighScore", 0);
		addCheck = PlayerPrefs.GetInt ("CheckCount", 0);
		CheckScore (totalScore, bestScore);
		Score.text = totalScore.ToString ();
		BestScore.text = bestScore.ToString ();
		PlayerPrefs.DeleteKey ("totalScore");
	}
	void CheckScore(int total, int best)
	{
		if (total > best) {
			best = total;
			PlayerPrefs.SetInt ("HighScore", best);
			bestScore = PlayerPrefs.GetInt ("HighScore");
		}
	}
}
