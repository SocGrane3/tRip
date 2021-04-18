using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    public GameObject plataforma;
    public bool spawn;
    public float tiempoAparicion = 1.0f;
    public float lastPlatformX;
    public float rangeInit, rangeFin;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlatformWave());
        lastPlatformX = 45;
    }

    public void SpawnPlatform(float x, float x2)
    {
       
            GameObject g = Instantiate(plataforma) as GameObject;
            float random = Random.Range(x, x2);
            g.transform.position = new Vector3(random, 0, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlatformWave()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(tiempoAparicion);
            SpawnPlatform(-30, -10 );
            SpawnPlatform(10, 30 );
        }

        
    }
}
