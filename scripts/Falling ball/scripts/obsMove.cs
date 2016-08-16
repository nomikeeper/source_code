using UnityEngine;
using System.Collections;

public class obsMove : ObsMovement {

	[System.NonSerialized]
	public float movingSpeed = 0.5f;

	public string direction;
	// Use this for initialization

	void Start () {
		setDirection ();
		SetMovingSpeed ();
        FlyUpSpeed = 0.2f;
		GroundAnim = GetComponent<Animator> ();
		bm = GameObject.Find ("Ball").GetComponent<ballMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (bm.GetState () != true) {
			gameOver ();
		}
        checkDirection ();


		if(bm.GetState () != true) {
			stopMoving ();
		}

		if (transform.position.y > 6) {
			Destroy (gameObject);
		}

        if (Input.GetKey("x"))
        {
            gameOver();
        }
	}

	void FixedUpdate()
	{
		FlyUp ();
		move ();
	}
	public void move()
	{
		if (direction == "right") {
			transform.Translate (Vector2.right * movingSpeed * Time.deltaTime);
		} 
		else {
			transform.Translate (-Vector2.right * movingSpeed  * Time.deltaTime);
		}
	}
	public void checkDirection()
	{
		if (transform.position.x >= 2.5f) {
			direction = "left";
		} 
		else if(transform.position.x <= -2.5f){
			direction = "right";
		}
	}
	void setDirection()
	{
		float num = Random.Range (-1f, 1f);
		if (num >= 0) {
			direction = "right";
		} 
		else {
			direction = "left";
		}
	}
	void SetMovingSpeed()
	{
		movingSpeed = Random.Range (0.8f, 1.8f);
	}
	public float getMoveSpeed()
	{
		return movingSpeed;
	}
    public override void gameOver()
    {
		GroundAnim.SetBool ("gameOver", true);
    }

	private void stopMoving()
	{
		while (movingSpeed > 0 || FlyUpSpeed > 0) {
				movingSpeed -= .6f * Time.fixedDeltaTime;
				FlyUpSpeed -= .1f * Time.deltaTime;
				SpeedChecker ();
		}	
	}
	private void SpeedChecker()
	{
		if (movingSpeed < 0) {
			movingSpeed = 0;
		}
		if (FlyUpSpeed < 0) {
			FlyUpSpeed = 0;
		}
	}
}
