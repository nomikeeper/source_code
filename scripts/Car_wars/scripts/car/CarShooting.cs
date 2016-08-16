using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarShooting : MonoBehaviour {

    // public variables
    public int c_playerNumber = 1;
    public Transform c_FireTransfrom;
    public Rigidbody c_bombRb;
    public Rigidbody c_miniGun;
    public float c_LaunchForce = 200f;
    public int c_MaxBombAmmo = 8;
    public Text ammo;
    public Transform[] holes;
	public float c_range = 50f;
	public float c_nextFireTime = 2f;

    // private variables
    private string c_FireButton;
    private string c_miniGunFire;
    private bool c_isBombFired;
    private int c_CurrentBombAmmo;
	// Use this for initialization
    void Awake()
    {
        c_isBombFired = false;
        c_CurrentBombAmmo = 5;
    }
	void Start () {
        c_FireButton = "Fire" + c_playerNumber;
        c_miniGunFire = "MiniGun" + c_playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
        ammo.text = c_CurrentBombAmmo.ToString();
        fireBomb();
        fireMiniGun();
        if (Input.GetKeyUp("x"))
        {
            GetAmmo();
        }
	}
    private void Fire() 
    {
        c_isBombFired = true;

        Rigidbody bombInstance = Instantiate(c_bombRb, c_FireTransfrom.position, c_FireTransfrom.rotation) as Rigidbody;

        bombInstance.velocity = c_LaunchForce * c_FireTransfrom.forward;
    }
    private void fireBomb()
    {
        if (Input.GetButtonDown(c_FireButton))
        {
            c_isBombFired = false;
        }
        else if (Input.GetButton(c_FireButton) && !c_isBombFired)
        {

        }
        else if (Input.GetButtonUp(c_FireButton) && !c_isBombFired)
        {
            if (c_CurrentBombAmmo > 0)
            {
                Fire();
                c_CurrentBombAmmo -= 1;
            }
            else { Debug.Log("No Ammo"); }
        }
    }
    private void fireMiniGun()
    {
		if (Input.GetButtonDown(c_miniGunFire) && Time.time > c_nextFireTime)
        {
			for (int i = 0; i < holes.Length; i++)
			{
				RaycastHit hit;
				Vector3 HoleOrigin = holes[i].position;

				if (Physics.Raycast (HoleOrigin, holes[i].forward, out hit, c_range)) 
				{
					CarHealth tarHealth = hit.collider.gameObject.GetComponent<CarHealth> ();

					if (tarHealth) {
						tarHealth.TakeDamage (2.5f);
					}

					if (hit.rigidbody) {
						hit.rigidbody.AddForce (-hit.normal * 100f);
					}
				}
			}
        }
    }
    public void SetAmmo()
    {
        c_CurrentBombAmmo = 5;
	}
	public void GetAmmo()
	{
		c_CurrentBombAmmo += 2;
	}
}
