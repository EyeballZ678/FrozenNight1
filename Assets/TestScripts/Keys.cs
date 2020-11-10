using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public Transform[] keyLocations;
    public Transform keyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = keyLocations[Random.Range(0, keyLocations.Length)].position;
        Instantiate(keyPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
