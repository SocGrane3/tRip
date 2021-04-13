using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personatge : MonoBehaviour
{
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        initialPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (this.gameObject.transform.position.y < -10) mort();
    }

    public void mort()
    {
        Debug.Log("Mort, position: "+this.gameObject.transform.position.y);
        this.gameObject.transform.position = initialPosition;
    }
}
