using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int Health;
    public int DamageValue;
    public Animator Anim;
    public int DoorOpenTime;
    // Start is called before the first frame update
    void Start()
    {
   //     Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Slam()
    {
        Anim.SetTrigger("Slam");
        Health = 1;
    }

    private void OnCollisionEnter(Collision other)
    {
//        print("Hello"+other.gameObject.name); //to see if it was working
        if (other.gameObject.CompareTag("Player"))
        {

            Health -= DamageValue;
            if (Health == 0)
            {

                Anim.SetTrigger("ForceOpen");
                Invoke("Slam", DoorOpenTime);
//                Health += 1;
                
            }
        }
    }
}
