using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ballMovement : MonoBehaviour {

	public float ballMs = 1f;
	public Text scoreTxt;
    public GameManager gm;
    public ObsGenerate obsG;

	private bool playerState;
    private float Horizontal;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		playerState = true;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Horizontal = Input.GetAxis ("Horizontal");
        /*Horizontal = Input.acceleration.x;
        if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);
			if (touch.position.x < Screen.width / 2) {
				Horizontal = -1;
			} else if (touch.position.x > Screen.width / 2) {
				Horizontal = 1;
			}
		} else {
			Horizontal = 0;
		}*/
        float dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0, dist)).x;

        float miet = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
        transform.position = new Vector3(miet,transform.position.y,transform.position.z);
        //scoreTxt.text = score.ToString();
	}

	void FixedUpdate()
	{
		move ();
	}

	void move()
	{
        Vector2 move = Vector2.right  * Time.deltaTime * ballMs * Horizontal ;
		rb.position += move;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Boundary")) {
			die ();
		}
		else if(other.gameObject.CompareTag("glass"))
		{
			die ();
		}
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("obstacle")) {
			obsMove moveM = coll.gameObject.GetComponent<obsMove> ();
			if (moveM) {
				moveM.checkDirection ();
				if (moveM.direction == "right") {
					transform.Translate (Vector2.right * moveM.movingSpeed * Time.fixedDeltaTime);
				} 
				else {
					transform.Translate (-Vector2.right * moveM.movingSpeed  * Time.fixedDeltaTime);
				}
			}

		}
	}

	public bool GetState()
	{
		return playerState;
	}
	void die()
	{
		playerState = false;
        obsG.setPlayerState();
        gm.gameOver();
        Destroy(gameObject);
    }
    
}
