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
        
        if (videoPlayer.isPlaying == false)
        {
            Debug.Log("Pene");
        }
    }
}
