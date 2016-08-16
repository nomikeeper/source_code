using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CarHealth : MonoBehaviour {

	public float c_StartingHealth = 100f;
	public Slider c_Slider;
	public Image c_FillImage;
	public Color c_FullHealthColor = Color.green;
	public Color c_zeroHealthColor = Color.red;
	// Use this for initialization

	private float c_CurrentHealth;
	private bool c_isDead;


	private void OnEnable(){
		c_CurrentHealth = c_StartingHealth;
		c_isDead = false;

		SetHealthUI ();
	}

	public void TakeDamage(float damage)
	{
		c_CurrentHealth -= damage;

		SetHealthUI ();

		if (c_CurrentHealth < 0f && !c_isDead) {
			OnDeath ();
		}
	}

	private void SetHealthUI()
	{
		c_Slider.value = c_CurrentHealth;

		c_FillImage.color = Color.Lerp (c_zeroHealthColor,c_FullHealthColor, c_CurrentHealth/c_StartingHealth);
	}

	private void OnDeath()
	{
		c_isDead = true;
		gameObject.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
