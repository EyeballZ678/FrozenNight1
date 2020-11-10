using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerhealth : MonoBehaviour {
    public float CurrentHealth;
    public float MaxHealth;
	public float Temperature = 1.0f;
	public Slider healthbar;
	public float rateToWarm = 1.0f;
	public float rateToCool = -0.5f;
	public float maxTemperature = 30.0f;
	public float minTemperature = -2.0f;
	public TextMeshProUGUI text;
	private int Inside = 0;

	// Use this for initialization
	void Start () 
	{
		MaxHealth = 20f;
		// Resets health to what the current "MaxHealth" is set to whenever the game loads
		CurrentHealth = MaxHealth;

		healthbar.value = CalculateHealth();
	}

	void Update () 
	{
		//if (Input.GetKeyDown(KeyCode.P)) 
		//	HealDamage (6);
		if (Inside==0) 
		{
			Temperature = minTemperature;
		}
		if (Temperature < 0.0f)
		{
			DealDamage(Time.deltaTime / 4.0f);
		}
		if (Temperature > 5.0f)
		{
			HealDamage(Time.deltaTime / 2.0f);
		}
		text.text = string.Format("Temperature: {0:N0}", Temperature);

	}
	public void enterRoom() 
	{
		Inside++;
	}
	public void exitRoom() 
	{
		Inside--;
	}
	public void setTemperature(float roomTemperature) 
	{
		if (roomTemperature < Temperature)
		{
			Temperature += Time.deltaTime * rateToCool;
			//DealDamage(Time.deltaTime / 4.0f);
		}
		else 
		{
			Temperature += Time.deltaTime * rateToWarm;
			//HealDamage(Time.deltaTime / 2.0f);
		}
		Temperature = Mathf.Clamp(Temperature, minTemperature, maxTemperature);
	}
	public void DealDamage(float damageValue)
	{
		// Deduct the damage dealt to player's health
		CurrentHealth -= damageValue;
		healthbar.value = CalculateHealth();
		// if the player loses all health they will die
		if (CurrentHealth <= 0) 
			Die();
	}
	public void HealDamage(float damageValue)
	{
		CurrentHealth += damageValue;
		healthbar.value = CalculateHealth ();
	}

	float CalculateHealth()
	{
		return CurrentHealth / MaxHealth;
	}

	void Die()
	{
		CurrentHealth = 0;
		Debug.Log("Player Dead.");
	}

    void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Snowclump")
		{
			maxTemperature = 0f;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag=="Snowclump")
		{
			maxTemperature = 30f;
		}
	}
}
