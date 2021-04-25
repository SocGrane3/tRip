using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAndThrow : MonoBehaviour, ITouchable
{

    public bool carryObject;
    public Animator rotationHand;
    public Animator hand;
    public float throwForce;
    public GameObject dog;
    public Transform handGuide;
    Vector3 scaleOriginal;

    public void Selector()
    {
        throw new System.NotImplementedException();
    }

    public void onClick()
    {
        Debug.Log("ball detect man");

        if (dog.GetComponent<GosPickBall>().carryObject){
            dog.GetComponent<GosPickBall>().carryObject = false;
            dog.GetComponent<Animator>().SetTrigger("soltar");
        }

        hand.SetTrigger("pick");
        this.transform.SetParent(handGuide);
        this.transform.localScale = handGuide.localScale;
        this.gameObject.transform.position = handGuide.position;
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<Rigidbody>().useGravity = false;

        Debug.Log("pick"+"\nparent: "+this.transform.parent+"kinematic: "+ this.GetComponent<Rigidbody>().isKinematic+"Gravety: "+ this.GetComponent<Rigidbody>().useGravity);

        carryObject = true;
    }  
    // Start is called before the first frame update
    void Start()
    {
        scaleOriginal = transform.localScale;
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
                rotationHand.SetBool("cargar", true);
            }else rotationHand.SetBool("cargar", false);

            if (Input.GetMouseButtonUp(0))
            {
                rotationHand.SetTrigger("soltar");
                hand.SetTrigger("throw");
                handGuide.DetachChildren();
                transform.localScale = scaleOriginal;
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
