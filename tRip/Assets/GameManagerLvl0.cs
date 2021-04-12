using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLvl0 : MonoBehaviour
{
    GameObject[] gameObjects;
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
