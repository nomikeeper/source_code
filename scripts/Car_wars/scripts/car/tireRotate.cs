using UnityEngine;
using System.Collections;

public class tireRotate : MonoBehaviour {

    public float c_MaxRotateSpeed = 8f;

    private float c_CurrentRotateSpeed;
    private float c_AccSpeed = 2f;
    public Movement move;
	// Use this for initialization
    void Awake()
    {     
        move = GetComponentInParent<Movement>();
    }
	void Start () {
        c_CurrentRotateSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void FixedUpdate()
    {
        if (move.CheckMovement())
        {
            Accelrate();
            if (move.direction == "forward")
            {
                transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime * c_CurrentRotateSpeed);
            }
            else
            {
                transform.Rotate(new Vector3(-90, 0, 0) * Time.deltaTime * c_CurrentRotateSpeed);
            }
        }
        else 
        {
            c_CurrentRotateSpeed = 0;
        }
    }

    private void Accelrate()
    {
        c_CurrentRotateSpeed += c_AccSpeed;
        if (c_CurrentRotateSpeed > c_MaxRotateSpeed)
        {
            c_CurrentRotateSpeed = c_MaxRotateSpeed;
        }
    }
    
   
}
