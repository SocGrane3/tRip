using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour, ITouchable
{

    public bool carryObject;
    public GameObject hand;
    public float throwForce;
    public GameObject dog;
    private Transform handGuide;

    public void Selector()
    {
        throw new System.NotImplementedException();
    }

    public void onClick()
    {
        Debug.Log("ball detect man");

        dog.GetComponent<GosPickBall>().carryObject = false;

        hand.GetComponentInParent<Animator>().SetTrigger("pick");
        this.transform.SetParent(handGuide);
        this.gameObject.transform.position = handGuide.position;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false;

        Debug.Log("pick"+"\nparent: "+this.transform.parent+"kinematic: "+ this.GetComponent<Rigidbody>().isKinematic+"Gravety: "+ this.GetComponent<Rigidbody>().useGravity);

        carryObject = true;
    }  
    // Start is called before the first frame update
    void Start()
    {
        handGuide = hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Perro doggy = dog.GetComponent<Perro>();

        if (carryObject)
        {

            Debug.Log("carryobject "+ carryObject+" touchCount: "+Input.touchCount);

            if (Input.GetMouseButton(0) && throwForce < 700)
            {
                throwForce += 3;
            }

            if (Input.GetMouseButtonUp(0))
            {

                hand.GetComponentInParent<Animator>().SetTrigger("throw");
                handGuide.DetachChildren();
                this.GetComponent<Rigidbody>().isKinematic = false;
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce);
                carryObject = false;
                doggy.pilotaCatch = false;
                throwForce = 0;

                Debug.Log("throw" + "\nparent: " + this.transform.parent + "kinematic: " + this.GetComponent<Rigidbody>().isKinematic + "Gravety: " + this.GetComponent<Rigidbody>().useGravity);
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
