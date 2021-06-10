using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour, IMovible
{
    public Transform player;
    public Transform camaraPlayer;
    bool hasPlayer;
    bool beingCarried;
    private bool touched;
    public Vector3 tamañoReal = new Vector3 (0.65f, 0.65f, 0.65f);

    // Start is called before the first frame update
    void Start()
    {
    }
    private void Update()
    {
        MoverObjeto();
    }


    public void MoverObjeto()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if(dist <= 2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetKeyDown(KeyCode.Mouse0))
        {
            tamañoReal = gameObject.transform.lossyScale;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = camaraPlayer;
            beingCarried = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = null;
            transform.localScale = tamañoReal;
            beingCarried = false;
            touched = false;
        }
        
    }
    }

