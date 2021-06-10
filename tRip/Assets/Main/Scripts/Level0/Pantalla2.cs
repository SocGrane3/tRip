using System.Collections;
using System.Collections.Generic;

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
       
        
        
            
        
    }
    IEnumerator coFunc()
    {
        yield return new WaitForSeconds(3);
        GameManagerLvl0.misEstados = Estados.Pantalla2;
    }
}
