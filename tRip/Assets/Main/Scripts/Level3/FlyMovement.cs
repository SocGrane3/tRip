using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{

    protected Rigidbody rigidbody;

    


    void FixedUpdate()
    {


         
       rigidbody.velocity = Vector3.Project(rigidbody.velocity, Camera.main.transform.forward);
     


        //   transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
      //  rigidbody.AddForce(Camera.main.transform.forward, ForceMode.Impulse);
        // rigidbody.velocity = Camera.main.transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Camera.main.transform.forward, Color.white,1000);
        
    }
}
