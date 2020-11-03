using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolfy : MonoBehaviour
{
    private Vector3 start;
    public float speed = 1f;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        target = start;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform.position;
 //           transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = start;
        }
    }
}
