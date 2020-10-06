using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI Clock;
    int Hour = 22;
    int Minute = 0;

    // Start is called before the first frame update
    void Start()
    {
        //       Clock.text = "Hi";
        StartCoroutine("WaitForSec");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1.5f);
        Minute += 1;
        if (Minute==60)
        {
            Minute = 0;
            Hour += 1;
        }
        if (Hour==24)
        {
            Hour = 0;
        }
        //Clock.text = "" + Hour + ":" + Minute;
        Clock.text = string.Format("{0:D2}:{1:D2}", Hour, Minute);
        StartCoroutine("WaitForSec");
    }
}
