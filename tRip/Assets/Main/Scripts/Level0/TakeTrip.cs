using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeTrip : MonoBehaviour, ITouchable
{
    private Animator animator;

    

    bool cambiarEscena  = false;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        i++;
        
        if (cambiarEscena)
        {
            Debug.Log("Changed");
            SceneManager.LoadScene("Level1");    
        }
        animator.SetBool("CanFLy", true);
    }

    public void activarCambioEscena()
    {
         cambiarEscena = true;
    }
}
