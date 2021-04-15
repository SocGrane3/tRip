using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.Video;

public class Pantalla2 : MonoBehaviour, ITouchable
{
    private VideoPlayer videoPlayer; 
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = gameObject.GetComponentInChildren<VideoPlayer>();
        videoPlayer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        StartCoroutine(coFunc());
        videoPlayer.Play();
        Destroy(GameObject.FindGameObjectWithTag("Pantalla2").transform.gameObject.GetComponent<Outline>());
        
        
            
        
    }
    IEnumerator coFunc()
    {
        yield return new WaitForSeconds(3);
        GameManagerLvl0.pantalla2 = true;
    }
}
