﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    LineRenderer lineRenderer;

    [SerializeField]
    private Texture[] textures;

    private int animationStep;

    private float fps = 30f;

    private float fpsCounter;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        fpsCounter += Time.deltaTime;
        if(fpsCounter >= 1f / fps)
        {
            animationStep++;


            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }
            lineRenderer.material.SetTexture("MainTex", textures[animationStep]);

            fpsCounter = 0;
        }
    }
}
