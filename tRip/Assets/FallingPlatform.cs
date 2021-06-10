using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    bool isFalling = false;
    float velocidadCaida = 0;
    float tiempoEspera = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            tiempoEspera -= Time.deltaTime;
            if(tiempoEspera <= 0)
            {
                velocidadCaida += Time.deltaTime / 10;
                transform.position = new Vector3(transform.position.x, transform.position.y - velocidadCaida, transform.position.z);
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            isFalling = true;
            Destroy(gameObject, 13);
        }
    }
}
