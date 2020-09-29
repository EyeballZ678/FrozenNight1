using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 1f;
	float mouseX;
	float mouseY;

  //  public float jumpSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Input.GetAxis("Horizontal") * Speed, 0, 0);
        transform.Translate( 0, 0, Input.GetAxis("Vertical") * Speed);
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");


    //    if (Input.GetKeyDown(KeyCode.Space))
    //        transform.Translate(0, jumpSpeed, 0);{
    //    }
	}
}
