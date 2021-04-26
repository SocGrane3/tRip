using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObject : MonoBehaviour
{

    private  GameObject ultimoObjeto = null;
    private GameObject _seleccion;
    private GameObject objeto;
    private Image puntero;
    [SerializeField] private float distance;
    private void Start()
    {
        puntero = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit tocado;
        if(Physics.Raycast(rayo, out tocado, distance))
        {
            objeto = tocado.transform.gameObject;
            if (objeto.GetComponent<ITouchable>() != null)
            {
                ultimoObjeto = tocado.transform.gameObject;
                puntero.color = Color.magenta;
                ultimoObjeto.GetComponent<Outline>().enabled = true;
                if (Input.GetMouseButtonUp(0))
                {
                    objeto.GetComponent<ITouchable>().onClick();
                    
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    objeto.GetComponent<ITouchable>().onClick();
                }
                
            }
            else
            {
                puntero.color = Color.white;
                if(ultimoObjeto != null)
                {
                    ultimoObjeto.GetComponent<Outline>().enabled = false;
                }
                
            }
        }
        else {
            if(ultimoObjeto != null) ultimoObjeto.GetComponent<Outline>().enabled = false;
            puntero.color = Color.white;
        }
    }
}
