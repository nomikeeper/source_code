using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneControl : MonoBehaviour {

	// public variables
	public int score = 0;
	public float jump = 25f;
	public float drop = 5f;
	public float max_height = 4.5f;
	public Text TotalScore;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		TotalScore.text = score.ToString ();
		PlayerPrefs.SetString ("totalScore", TotalScore.text);
		//transform.position -= transform.up * Time.deltaTime * drop;
		if (transform.position.y > max_height) {
			transform.position = new Vector2 (transform.position.x, max_height);
		}
		else if (Input.GetButton ("Jump")) {
			rb.AddForce (Vector2.up * 50);
			//transform.Translate(Vector3.up * jump * Time.deltaTime, Space.World);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Obstacle")) {
			Destroy (gameObject);
			SceneManager.LoadScene (1);
		} 
		else if (other.gameObject.CompareTag ("Score")) 
		{
			score++;
		}
	}
}
