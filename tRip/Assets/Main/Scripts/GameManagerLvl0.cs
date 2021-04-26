using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLvl0 : MonoBehaviour
{
    [SerializeField]public static bool pantalla1, pantalla2, canTakePill;
    GameObject[] gameObjects;
    private GameObject pantalla1Object, pantalla2Object;
    private AudioSource audioSource;
    [SerializeField] private Animator animator;
    private GameObject pill;
    // Start is called before the first frame update
    void Start()
    {
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
        if (pantalla1)
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
        }
        
    }
    IEnumerator coFunc()
    {
        yield return new WaitForSeconds(3);
        audioSource.clip = null;
        canTakePill = true;
    }
}
