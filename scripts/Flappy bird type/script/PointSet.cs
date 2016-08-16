using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointSet : MonoBehaviour {

	public Text Score;
	// Use this for initialization
	void Start () {
		Score.text = PlayerPrefs.GetString ("totalScore");
		PlayerPrefs.DeleteKey ("totalScore");
	}
}
