using UnityEngine;
using System.Collections;


public class Movement : MonoBehaviour {
    //public variables
    public int c_playerNumber = 1;
    public float c_playerSpeed = 12f;
    public float c_rotateSpeed = 180f;
    public string direction;

    //private variables
    private string c_moveAxisName;
    private string c_turnAxisName;
    private Rigidbody c_rigidbody; 
    private float c_moveInputValue;
    private float c_turnInputValue;
    private bool c_isMoving;
    private bool c_isGrounded;

    private void Awake(){
        c_rigidbody = GetComponent<Rigidbody>();
    }
    private void onEnable()
    {
        //turn off when car reset
        c_rigidbody.isKinematic = false;
        c_isGrounded = false;
        //reset move and turn values on reset
        c_moveInputValue = 0f;
        c_turnInputValue = 0f;
    }
    private void onDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving.
        c_rigidbody.isKinematic = true;
    }
	// Use this for initialization
	private void Start () {
        //The axis names are based on their player number
        c_moveAxisName = "Vertical" + c_playerNumber;
        c_turnAxisName = "Horizontal" + c_playerNumber;
	}
	
	// Update is called once per frame
	private void Update () {
	    //Store the value of both input boxes
        
        c_moveInputValue = Input.GetAxis(c_moveAxisName);
        c_turnInputValue = Input.GetAxis(c_turnAxisName);
	}
    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        if (c_isGrounded)
        {
            Move();
        }
        else if(c_isMoving)
        {
            if (direction == "forward")
            {
                Vector3 movement = transform.forward * 1f * c_playerSpeed * Time.deltaTime;
                c_rigidbody.MovePosition(c_rigidbody.position + movement);
            }
            else 
            { 
                Vector3 movement = transform.forward * -1f * c_playerSpeed * Time.deltaTime;
                c_rigidbody.MovePosition(c_rigidbody.position + movement);
            }
        }
        if (c_isMoving)
        {
            Turn();
        }
        
        
    }
    private void Move()
    {
        Vector3 movement = transform.forward * c_moveInputValue * c_playerSpeed * Time.deltaTime;
        c_rigidbody.MovePosition(c_rigidbody.position + movement);
    }
    private void Turn() 
    {
        float turn = c_turnInputValue * c_rotateSpeed * Time.deltaTime;
        if (direction == "backward")
        {
            turn = turn * -1;
        }
        Quaternion TurnRotation = Quaternion.Euler(0f,turn,0f);

        c_rigidbody.MoveRotation(c_rigidbody.rotation * TurnRotation); 
        
        
        
    }
    public bool CheckMovement()
    {
        if (c_moveInputValue > 0)
        {
            c_isMoving = true;
            direction = "forward";
        }
        else if (c_moveInputValue < 0)
        {
            c_isMoving = true;
            direction = "backward";
        }
        else
        {
            c_isMoving = false;
        }
        return c_isMoving;
    }
    public bool IsGrounded;

    void OnCollisionStay(Collision collisionInfo)
    {
        c_isGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
       c_isGrounded = false;
    }


}
