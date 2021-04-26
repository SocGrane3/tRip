using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour, ITouchable
{

    public bool carryObject;
    public Transform hand;
    public float throwForce;
    public GameObject dog;

    public void Selector()
    {
        throw new System.NotImplementedException();
    }

    public void onClick()
    {
        Debug.Log("ball detect man");

        dog.GetComponent<GosPickBall>().carryObject = false;

        carryObject = true;
        if (carryObject)
        {
            
            this.transform.SetParent(hand);
            this.gameObject.transform.position = hand.position;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Perro doggy = dog.GetComponent<Perro>();

        if (carryObject)
        {
            if (Input.GetMouseButton(0) && throwForce < 700)
            {
                throwForce += 3;
            }

            if (Input.GetMouseButtonUp(0))
            {
                hand.DetachChildren();
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce);
                carryObject = false;
                doggy.pilotaCatch = false;
                throwForce = 0;
            }
        }

        if(transform.position.x > 50 ||
            transform.position.x < -50 ||
            transform.position.y > 50 ||
            transform.position.y < -50)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
