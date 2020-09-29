using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiDisplayForLogs : MonoBehaviour {

    public TextMeshProUGUI Log;
    public InteractInstructions logCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Log.text = "Logs Collected:" + logCount.logCount;
	}
}
