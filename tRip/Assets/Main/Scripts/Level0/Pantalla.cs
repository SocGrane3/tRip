using System.Collections;
using System.Collections.Generic;
using Unity.UNetWeaver;
using UnityEngine;
using UnityEngine.Video;

public class Pantalla : MonoBehaviour, ITouchable
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
        videoPlayer.Play();
        Destroy(GameObject.FindGameObjectWithTag("Pantalla1").transform.gameObject.GetComponent<Outline>());
        Destroy(this.transform.gameObject.GetComponent<Outline>());
        if ((ulong)videoPlayer.frame < videoPlayer.frameCount)
        {
            

        }
        else
        {
            GameManagerLvl0.pantalla1 = true;
        }
    }
}
