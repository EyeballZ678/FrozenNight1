using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Room : MonoBehaviour {

	public Playerhealth Player;
	public Fireplace fireplace;
//	public GameObject Theplayer;
//	public TextMeshProUGUI text;
	float currentTemperature;

	void Start()
	{
		currentTemperature = 0f;
	}
    void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			Player.enterRoom();
			Player.GetComponent<FirstPersonController>().Setspeed(5f);
			Player.GetComponent<FirstPersonController>().m_UseShivering = false;

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Player.exitRoom();
			Player.GetComponent<FirstPersonController>().Setspeed(2.5f);
		    Player.GetComponent<FirstPersonController>().m_UseShivering = true;

		}

	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.CompareTag("Player")) 
		{
			if (fireplace != null) 
			{
				currentTemperature = fireplace.Warm(currentTemperature);
				Player.setTemperature(currentTemperature);
			}
			else 	
			{
				Player.setTemperature(-2.0f);
			}
		}

	}
}
