using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GosPickBall : MonoBehaviour
{

    public bool carryObject;
    public Transform boca;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray directionRay = new Ray(transform.position, transform.forward);
        Debug.DrawLine(transform.position, transform.forward, Color.red, 10000000);
        if (Physics.Raycast(directionRay, out hit, 2f))
        {

            if (hit.collider.CompareTag("Selectable"))
            {

                Debug.Log("ball detect");

                carryObject = true;
                if (carryObject)
                {
                    gameObject.GetComponent<Perro>().pilotaCatch = true;
                    item = hit.collider.gameObject;
                    item.transform.SetParent(boca);
                    item.gameObject.transform.position = boca.position;
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }
    }
}
