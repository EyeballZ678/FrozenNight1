using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room : MonoBehaviour {

	public Playerhealth Player;
	public Fireplace fireplace;
//	public TextMeshProUGUI text;
	float currentTemperature;

	void Start()
	{
		currentTemperature = -2.0f;
	}
    void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			Player.enterRoom();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Player.exitRoom();
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
