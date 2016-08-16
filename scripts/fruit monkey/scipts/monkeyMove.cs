using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class monkeyMove : MonoBehaviour {

	//public variables
	public float m_speed = 5f;
	public float m_jump = 20f;
	public float m_fall = 9.81f;
	public Text score;
	//private variables
	private float MoveHorizontal;
	private int m_TotalPoint = 0;
	private Rigidbody2D monkey_rb;
	private bool m_isGrounded;
	// Use this for initialization
	void Awake()
	{
		monkey_rb = GetComponent<Rigidbody2D> ();
	}
	void Start () {
		m_isGrounded = false;
		m_TotalPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		MoveHorizontal = Input.GetAxis ("Horizontal");
		//MoveHorizontal = Input.acceleration.x;
		if (Input.GetButtonDown("Jump") && m_isGrounded) 
		{
			monkey_rb.AddForce (Vector2.up * m_jump);
		}
		score.text = m_TotalPoint.ToString ();

	}

	void FixedUpdate()
	{
		move ();

		/*if (!m_isGrounded) 
		{
			transform.Translate (-Vector2.up * m_fall * Time.deltaTime, Space.World);
		}*/
	}

	private void move()
	{
		Vector2 movement = transform.right * MoveHorizontal * m_speed * Time.deltaTime; 

		monkey_rb.position +=movement;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("ground")) {
		
			m_isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("ground")) {

			m_isGrounded = false;
		}
	}

	public void GetPoint(int point)
	{
		m_TotalPoint += point;
	}



}
