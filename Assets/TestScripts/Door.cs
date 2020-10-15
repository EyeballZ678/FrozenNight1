using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int Health;
    public int DamageValue;
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
//        print("Hello Door"); to see if it was working
        if (other.gameObject.CompareTag("Player"))
        {
            Health -= DamageValue;
            if (Health == 0)
            {

                Anim.SetTrigger("ForceOpen");
            }
        }
    }
}
