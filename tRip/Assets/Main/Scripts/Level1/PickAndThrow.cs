using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour
{

    public bool carryObject, isThrowable;
    public Transform hand;
    public GameObject item;
    public float throwForce;
    public GameObject dog;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Perro doggy = dog.GetComponent<Perro>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray directionRay = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, directionRay.direction, Color.red, 2f, false);
            if (Physics.Raycast(directionRay, out hit, 2f))
            {
                if (hit.collider.tag == "Selectable")
                {

                    Debug.Log("dog detect");

                    if (doggy.pilotaCatch)
                    {
                        dog.GetComponent<GosPickBall>().carryObject = false;

                        carryObject = true;
                        isThrowable = true;
                        if (carryObject)
                        {
                            item = dog.GetComponent<GosPickBall>().item;
                            item.transform.SetParent(hand);
                            item.gameObject.transform.position = hand.position;
                            item.GetComponent<Rigidbody>().isKinematic = true;
                            item.GetComponent<Rigidbody>().useGravity = false;
                        }
                    }
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            carryObject = false;
            isThrowable = false;
        }

        if (!carryObject && item != null)
        {
            hand.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            doggy.pilotaCatch = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (isThrowable)
            {
                hand.DetachChildren();
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().AddRelativeForce(hand.forward * throwForce);
                doggy.pilotaCatch = false;
            }
        }
    }
}
