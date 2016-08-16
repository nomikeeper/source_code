using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System;

public class ballMovement : MonoBehaviour {

	public float b_speed = 10f;
	public float b_jump = 250f;
	public Text GUI_text;
	public float duration = 0.5f;

	private float multiplier;
	private float b_speedMult;
	private int Score = 0;
	private Rigidbody2D b_rb;
	private int addCheck;
	//private float movement;
	private bool b_isGrounded;
	private AudioSource src;
	private UnityAds ad;
	// Use this for initialization
	void Awake()
	{
		b_rb = GetComponent<Rigidbody2D> ();
		addCheck = PlayerPrefs.GetInt ("CheckCount", 0);
	}
	void Start () {
		b_isGrounded = false;
		Score = 0;
		b_speedMult = 1f;
		multiplier = 1;
		src = GetComponent<AudioSource> ();
		InvokeRepeating ("ScoreCount", 0.5f, (1f * multiplier));
		ad = GameObject.Find ("Advertisement").GetComponent<UnityAds> ();
	}
	
	// Update is called once per frame
	void Update () {
		//movement = Input.GetAxis ("Horizontal");
		setMultiplier ();
		if (  Input.touchCount != 0 && Input.GetTouch(0).phase== TouchPhase.Began && b_isGrounded || Input.GetButtonDown ("Jump") && b_isGrounded) 
		{
			src.Play ();
			b_rb.AddForce (Vector2.up * b_jump);
		}
		if (transform.position.y < -5.5f) {
			if (addCheck >= 2) {
				ad.ShowAd ();
				die ();
			} else
				die ();
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			SceneManager.LoadScene (2);
		}

		GUI_text.text = (Score).ToString ();
	}
	void FixedUpdate()
	{
		move ();
	}

	private void move()
	{
		Vector2 move = Vector2.right  * Time.deltaTime * b_speed * b_speedMult ;

		b_rb.position += move;
		 
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("sharp")) {
			if (addCheck >= 2) {
				ad.ShowAd ();
				die ();
			} else
				die ();

			/*Destroy (gameObject);
			menu_selection menu = GameObject.Find ("Main Camera").GetComponent<menu_selection> ();
			menu.LoadScene ("dead");*/
		}
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("ground")) {
			b_isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("ground")) {
			b_isGrounded = false;
		}
	}
	void setMultiplier()
	{
		int temp = 0;
		int.TryParse (GUI_text.text,out temp);
		if (temp >= 25 && temp < 40) {
			multiplier = 0.9f;
			b_speedMult = 1.2f;
			GameObject.Find ("graphic").GetComponent<ballRotation> ().Accelrator (1.5f);
		} else if (temp >= 40 && temp < 65) {
			multiplier = 0.8f;
			b_speedMult = 1.4f;
			GameObject.Find ("graphic").GetComponent<ballRotation> ().Accelrator (2f);
		} else if (temp >= 65 && temp < 80) {
			multiplier = 0.6f;
			b_speedMult = 1.6f;
			GameObject.Find ("graphic").GetComponent<ballRotation> ().Accelrator (2.5f);
		} else if (temp >= 80) {
			multiplier = 0.4f;
			b_speedMult = 1.8f;
			GameObject.Find ("graphic").GetComponent<ballRotation> ().Accelrator (2.5f);
		}
	}
	void ScoreCount()
	{
		Score += 1;
	}
	void die()
	{
		PlayerPrefs.SetInt ("totalScore", Score);
		Destroy (gameObject);
		addCheck += 1;
		if (addCheck >= 3) {addCheck = 0;}
		Debug.Log (addCheck);
		PlayerPrefs.SetInt ("CheckCount", addCheck);
		GameObject.Find ("Main Camera").GetComponent<menu_selection> ().LoadScene ("dead");
		
	}
}
