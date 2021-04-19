﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlatforms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Destroyed");
        Destroy(other.transform.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Destroyed");
        Destroy(collision.transform.gameObject);
    }
}
