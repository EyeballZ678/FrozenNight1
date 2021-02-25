using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Playerhealth : MonoBehaviour
{
	public float CurrentHealth;
	public float MaxHealth;
	public float Temperature = 1.0f;
	public Slider healthbar;
	public float rateToWarm = 1.0f;
	public float rateToCool = -0.5f;
	public float maxTemperature = 30.0f;
	public float minTemperature = -20.0f;
	public Renderer iceFilter;
	public TextMeshProUGUI text;
	private int Inside = 0;
	public float TempDamage = 0.0365f;
	int snowClumps = 0;
	public GameObject Player;

	// Use this for initialization
	void Start()
	{
		MaxHealth = 20f;
		// Resets health to what the current "MaxHealth" is set to whenever the game loads
		CurrentHealth = MaxHealth;
		healthbar.value = CalculateHealth();
	}

	void Update()
	{
		enterRoom();
		exitRoom();
		PlayerShivers();
		//if (Input.GetKeyDown(KeyCode.P)) 
		//	HealDamage (6);
		if (Inside == 0)
		{
			if (Temperature > -2f)
			{
				Temperature = -2f;
			}	
			setTemperature(minTemperature);
		}
		if (Temperature < 0.0f)
		{
			DealDamage(-Temperature * TempDamage * Time.deltaTime);
		}
		if (Temperature > 5.0f)
		{
			HealDamage(Time.deltaTime / 2.0f);
		}
		text.text = string.Format("Temperature: {0:N0}", Temperature);
		if (Inside == 0 || snowClumps > 0)
		{
			Player.GetComponent<FirstPersonController>().Setspeed(2.5f);
		}
		else
		{
			Player.GetComponent<FirstPersonController>().Setspeed(5f);
		}


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
		Material material = iceFilter.material;
		Color color = material.color;
		color.a = Temperature / minTemperature;
		material.color = color;
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
		healthbar.value = CalculateHealth();
	}

	float CalculateHealth()
	{
		return CurrentHealth / MaxHealth;
	}

	void Die()
	{
		CurrentHealth = 0;
	//	Debug.Log("Player Dead.");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Snowclump")
		{
			snowClumps++;
			maxTemperature = 0f;


		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Snowclump")
		{
			snowClumps--;
			maxTemperature = 3f;

		}
	}
	public void PlayerShivers()
	{
		if (Temperature <= 0)
		{
			Player.GetComponent<FirstPersonController>().m_UseShivering = true;
		}
		if (Temperature >= 0)
		{
			Player.GetComponent<FirstPersonController>().m_UseShivering = false;
		}
	}

}
