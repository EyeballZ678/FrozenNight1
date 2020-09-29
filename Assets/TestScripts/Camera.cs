using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 SmoothV;
    public float Sensitivity = 5.0f;
    public float Smoothing = 2.0f;

    GameObject Player;

	// Use this for initialization
	void Start ()
    {
        Player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        SmoothV.x = Mathf.Lerp(SmoothV.x, md.x, 1f / Smoothing);
        SmoothV.y = Mathf.Lerp(SmoothV.y, md.y, 1f / Smoothing);
        mouseLook += SmoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Player.transform.up);
	}
}
