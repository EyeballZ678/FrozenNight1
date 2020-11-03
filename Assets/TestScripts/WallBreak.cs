using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    public GameObject WallBreaks;
    public float WhenWallBreaks = 10f;

    // Start is called before the first frame update
    void Start()
    {
        WallBreaks.SetActive(true);
        StartCoroutine(Sequence());
    }



    IEnumerator Sequence()
    {
        {
            if (WallBreaks == true)
            {
                yield return new WaitForSeconds(WhenWallBreaks);
                WallBreaks.SetActive(false);
            }

        }
    }
}

