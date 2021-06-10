using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Estados { Inicio, Pantalla1, Pantalla2, CanTakePill }
public class GameManagerLvl0 : MonoBehaviour
{
    [SerializeField]public static bool pantalla1, pantalla2, canTakePill;
    GameObject[] gameObjects;
    private GameObject pantalla1Object, pantalla2Object;
    private AudioSource audioSource;
    [SerializeField] private Animator animator;
    private GameObject pill;
    public static Estados misEstados;

    // Start is called before the first frame update
    void Start()
    {
        Estados misEstados;
        misEstados = Estados.Inicio;
        gameObjects = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject g in gameObjects)
        {
            g.AddComponent<Outline>();
            g.GetComponent<Outline>().OutlineColor = Color.magenta;
            g.GetComponent<Outline>().enabled = false;

        }
        pantalla1 = false;
        pantalla2 = false;
        canTakePill = false;
        pantalla2Object = GameObject.FindGameObjectWithTag("Pantalla2");
        pantalla1Object = GameObject.FindGameObjectWithTag("Pantalla1");
        pill = GameObject.FindGameObjectWithTag("tripp").transform.gameObject;
        audioSource = GameObject.FindGameObjectWithTag("Audio").transform.gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        switch (misEstados)
        {
            case Estados.Inicio:
                if (pantalla1Object.transform.gameObject.GetComponent<Pantalla>() == null)
                {
                    pantalla2Object.transform.gameObject.AddComponent<Pantalla>();
                }
                break;

            case Estados.Pantalla1:
                Destroy(GameObject.FindGameObjectWithTag("Pantalla1").transform.gameObject.GetComponent<Outline>());
                Destroy(GameObject.Find("Imagen1").transform.gameObject.GetComponent<Outline>());
                if (pantalla2Object.transform.gameObject.GetComponent<Pantalla2>() == null)
                {
                    pantalla2Object.transform.gameObject.AddComponent<Pantalla2>();
                }
                break;
            case Estados.Pantalla2:
                Destroy(GameObject.FindGameObjectWithTag("Pantalla2").transform.gameObject.GetComponent<Outline>());
                
                if (audioSource.isPlaying)
                {

                }
                else
                {
                    StartCoroutine(coFunc());
                    audioSource.Play();

                }
                break;
            case Estados.CanTakePill:
                if (pill.GetComponent<TakeTrip>() == null)
                {
                    pill.AddComponent<TakeTrip>();

                }
                break;


        }
       /* if (pantalla1)
        {
            if(pantalla2Object.transform.gameObject.GetComponent<Pantalla2>() == null)
            {
                pantalla2Object.transform.gameObject.AddComponent<Pantalla2>();
            }
            
            
        }
        if (pantalla2)
        {
            
            if (audioSource.isPlaying)
            {
                
            }
            else
            {
                StartCoroutine(coFunc());
                audioSource.Play();
                
            }
        }

        if (canTakePill)
        {
            
            if (pill.GetComponent<TakeTrip>() == null)
            {
                pill.AddComponent<TakeTrip>();
                
            }
        }*/
        
    }
    IEnumerator coFunc()
    {
        yield return new WaitForSeconds(3);
        audioSource.clip = null;
        misEstados = Estados.CanTakePill;
    }
}
