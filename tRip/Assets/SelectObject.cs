using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material materialDeSeleccion;
    private Material materialPorDefecto;
    [SerializeField] private  GameObject ultimoObjeto = null;
    private GameObject _seleccion;
    // Update is called once per frame
    void Update()
    {
        
        var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit tocado;
        if(Physics.Raycast(rayo, out tocado))
        {
            
            if (tocado.collider.tag == selectableTag)
            {
                ultimoObjeto = tocado.transform.gameObject;
                Debug.Log(tocado.transform.gameObject.GetComponent<Outline>().enabled);
                this.GetComponent<Image>().color = Color.magenta;
                ultimoObjeto.GetComponent<Outline>().enabled = true;
                Debug.Log(tocado.transform.gameObject.GetComponent<Outline>().enabled);
            }
            else
            {
                this.GetComponent<Image>().color = Color.white;
                if(ultimoObjeto != null)
                {
                    ultimoObjeto.GetComponent<Outline>().enabled = false;
                }
                
            }
        }
    }
}
