using UnityEngine;
using System.Collections;

public class ObsMovement : MonoBehaviour {


	public float FlyUpSpeed;
	public Animator GroundAnim;
	public ballMovement bm;
	// Use this for initialization
	void Start () {
		FlyUpSpeed = .2f;
		GroundAnim = GetComponent<Animator> ();
		bm = GameObject.Find ("Ball").GetComponent<ballMovement> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (bm.GetState () != true) {
			gameOver ();
		}

		FlyUp();

        if (Input.GetKey("x"))
        {
            gameOver();
        }
    }

    public virtual void FlyUp()
    {
        transform.Translate(Vector2.up * FlyUpSpeed * Time.deltaTime);
    }
    public void SetFlyUpSpeed(float args)
    {
        FlyUpSpeed = args;
    }
    public float GetSpeed()
    {
        return FlyUpSpeed;
    }
    public virtual void gameOver()
    {
		GroundAnim.SetTrigger ("gameOver");
    }
}
