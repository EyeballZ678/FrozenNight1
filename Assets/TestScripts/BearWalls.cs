using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearWalls : MonoBehaviour
{
    public GameObject BearWall1;
    public GameObject BearWall2;
    public float BearBreaksWall = 10f;
    public AudioSource source;
    public AudioClip Bear;
    public AudioClip WallBreaking;
    // Start is called before the first frame update
    void Start()
    {
        BearWall1.SetActive(true);
        BearWall2.SetActive(true);
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        {
            if (BearWall1 == true)
            {
                yield return new WaitForSeconds(BearBreaksWall);
                BearWall1.SetActive(false);
                BearWall2.SetActive(false);
                source.clip = Bear;
                source.Play();
            }

        }
    }
}