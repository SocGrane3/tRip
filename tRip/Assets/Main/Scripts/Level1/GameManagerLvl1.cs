using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLvl1 : MonoBehaviour
{
    public GameObject isla, gos, fallEfect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gos.transform.position.y < 35)
        {
            for (int i = 0; i < isla.transform.GetChildCount(); i++)
            {
                if (isla.transform.GetChild(i).GetComponent<Rigidbody>() != null) {
                    isla.transform.GetChild(i).GetComponent<Rigidbody>().useGravity = true;
                    isla.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                }
            }

            fallEfect.SetActive(true);

            GetComponent<AudioSource>().Play();
        }
    }
}
