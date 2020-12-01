using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int Health;
    public int DamageValue;
    public Animator Anim;
    public int DoorCloseTime;
    public bool Colliding;
    public Fireplace fireplace;
    bool Blizzard;

    // Start is called before the first frame update
    void Start()
    {
   //     Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Colliding && Input.GetKeyDown(KeyCode.F))
        {

            Health -= DamageValue;
            Debug.Log("Ow");
            if (Health < 1)
            {
                if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Open"))
                {
                    Anim.SetTrigger("Slam");
                    Debug.Log("Close");
                    if (Blizzard)
                    {
                        Invoke("ForceOpen", DoorCloseTime);
                    }
                }
                else
                {
                    Anim.SetTrigger("ForceOpen");
                    fireplace.NoFire();
                    Debug.Log("open");
                }

                //               Invoke("ForceOpen", DoorOpenTime);
                //                Health += 1;

            }
        }

    }
    public void SetBlizzard(bool enable)
    {
        Blizzard = enable;
        if (Blizzard)
        {
            ForceOpen();
        }
    }

    // Update is called once per frame
    public void ForceOpen()
    {
        Anim.SetTrigger("ForceOpen");
        Health = 1;
        fireplace.NoFire();
    }

    private void OnCollisionEnter(Collision other)
    {
        //        print("Hello"+other.gameObject.name); //to see if it was working
        if (other.gameObject.CompareTag("Player"))
        {
            Colliding = true;

        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Colliding = false;
        }
    }

}
