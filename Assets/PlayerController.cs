﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrid
{
    int[,] cells = new int[64, 64];

    PlayerGrid()
    {
        
    }

    
}

public class Hackenkreuz {
	int x;
	int y;

	int top;
	int bottom;
	int left;
	int right;

	public Hackenkreuz() {
	}
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float rotation_speed;

    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(1.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frames
	void Update () {
        float v_ax = Input.GetAxis("Vertical");
        float h_ax = Input.GetAxis("Horizontal");

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Quaternion rotation = rb.rotation;
        Matrix4x4 rot_matrix = Matrix4x4.Rotate(rotation);

        rb.velocity = rot_matrix.MultiplyVector(new Vector3(0.0f, speed*v_ax, 0.0f));
        rb.angularVelocity = new Vector3(0.0f, rotation_speed*h_ax, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        EblominoController ec = other.gameObject.transform.parent.gameObject.GetComponent<EblominoController>();

        

        other.gameObject.transform.SetParent(transform);
        Vector3 ea = other.gameObject.transform.localEulerAngles;
        ea.z = 0.0f;
        other.gameObject.transform.localEulerAngles = ea;

        Vector3 pos = other.gameObject.transform.localPosition;
        pos.x = Mathf.Floor(pos.x+0.5f);
        pos.y = Mathf.Floor(pos.y+0.5f);
        other.gameObject.transform.localPosition = pos;
    }
}