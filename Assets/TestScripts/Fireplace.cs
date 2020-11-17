using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour {

	public float logsOnFire;
	public InteractInstructions logs;
	public float timePerLog = 60.0f;
	public float rateToWarm = 1.0f;
	public float rateToCool = -0.5f;
	public float fireTemperature = 30.0f;
	public float minTemperature = -2.0f;
	public GameObject ClumpofSnow;
	public GameObject Firebox;

	private void Start()
	{

	}

	void OnTriggerStay(Collider player)
	{
		if (player.gameObject.tag == "Player")
		{
			if (Input.GetKeyDown(KeyCode.F) && logs.logCount > 0) { 
				logs.RemoveLog ();
				logsOnFire += 1.0f;
			}
		}
	}

	void Update()
	{
		fireBox();
		if (logsOnFire > 0.0f) {
			logsOnFire -= Time.deltaTime / timePerLog;
		}
	}

	public float Warm(float temperature)
	{
		if (logsOnFire > 0.0f)
		{
			temperature += Time.deltaTime * rateToWarm;
		}
		else 
		{
			temperature += Time.deltaTime * rateToCool;
		}
		return Mathf.Clamp(temperature, minTemperature, fireTemperature);
		// return Mathf.Lerp (temperature, logsOnFire > 0.0f ? fireTemperature : minTemperature, Time.deltaTime * rateToWarm);
	}

	public void NoFire() 
	{
		logsOnFire = 0;
	}
	void fireBox()
	{
		if (logsOnFire >= 0.1f)
		{
			Firebox.SetActive(false);
		}
		else
		{
			Firebox.SetActive(true);
		}
	}
}
