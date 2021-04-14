using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour
{

    public bool carryObject;
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
                        if (carryObject)
                        {
                            item = dog.GetComponent<GosPickBall>().item;

                            Debug.Log("pilota1: " + item.transform.localPosition+ "\n hand1: " + hand.position);

                            item.transform.SetParent(hand);
                            item.gameObject.transform.position = hand.position;

                            Debug.Log("pilota2: " + item.transform.localPosition + "\n hand2: " + hand.position);

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
        }

        if (!carryObject && item != null)
        {
            hand.DetachChildren();
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            item = null;
            doggy.pilotaCatch = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (carryObject)
            {
                hand.DetachChildren();
                item.GetComponent<Rigidbody>().isKinematic = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * throwForce);
                carryObject = false;
                item = null;
                doggy.pilotaCatch = false;
            }
        }
    }
}
