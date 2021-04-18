﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{

    Rigidbody rigidbody;
    public float jumpStrength = 2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.drag = 0;
            rigidbody.AddForce(Camera.main.transform.forward * 100 * jumpStrength);
            
        }

        rigidbody.drag = 0;
    }
}
