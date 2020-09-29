using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Material Fixed;

    public Material Broken;

    private Renderer Visual;

    public Fireplace FirePlace;

    public InteractInstructions logs;

    public Renderer Plank;

    // Start is called before the first frame update
    void Start()
    {
        Visual = GetComponent<Renderer>();
        FixWindow();
        Plank.enabled = false;

    }
    void BrakeWindow() 
    {
        Visual.material = Broken;
        FirePlace.NoFire();
        Plank.enabled = false;
    }
    void FixWindow() 
    {
        Visual.material = Fixed;
        Invoke("BrakeWindow", Random.Range(15.0f, 30.0f));
        Plank.enabled = true;

    }

    void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F) && logs.logCount > 0)
            {
                FixWindow();
                logs.RemoveLog();
         
            }
        }
    }


}
