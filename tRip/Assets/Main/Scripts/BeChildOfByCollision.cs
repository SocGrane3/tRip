using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeChildOfByCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = this.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }
}
