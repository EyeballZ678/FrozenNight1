using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfSpawner : MonoBehaviour
{
    public GameObject Wolf;
    public float WolfTimer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Wolf.SetActive(false);
        StartCoroutine(Sequence());
    }
    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(WolfTimer);
        Wolf.SetActive(true);
    }

}
