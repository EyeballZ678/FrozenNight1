using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInstructions : MonoBehaviour {

    public GameObject uiObject;
    public int logCount = 0;
    public int maxLogs = 4;
    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (uiObject != null)
            {
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");
            }
            if (Input.GetKeyDown(KeyCode.F) && logCount < maxLogs) { 
                logCount += 1;
            }
        }
    }
    IEnumerator WaitForSec()
    {
        GameObject logText = uiObject;
        uiObject = null;
        yield return new WaitForSeconds(2);
        Destroy(logText);
    }

	public void RemoveLog()
	{
		logCount--;
	}
}

