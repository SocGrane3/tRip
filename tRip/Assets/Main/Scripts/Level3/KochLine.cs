using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class KochLine : KochGenerator
{
    LineRenderer lineRenderer;
    [Range(0,1)]
    public float lerpAmount;
    Vector3[] lerpPosition;
    public float generateMultiplier;

    public int branchs;
    public bool moreBranches= true;

    [SerializeField]
    int index = 0;
    float timeLeft;
    float timer = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.positionCount = position.Length;
        lineRenderer.SetPositions(position);



        createBranch();
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Rotate(0, 0,  +0.1f);


        if (generationCount != 0)
        {
            for (int i = 0; i < position.Length; i++)
            {
                lerpPosition[i] = Vector3.Lerp(position[i], targetPosition[i], lerpAmount);
            }
            if (useBezierCurves)
            {
                bezierPosition = BezierCurve(lerpPosition, bezierVertexCount);
                lineRenderer.positionCount = bezierPosition.Length;
                lineRenderer.SetPositions(bezierPosition);
            }
            else
            {
                lineRenderer.positionCount = lerpPosition.Length;
                lineRenderer.SetPositions(lerpPosition);
            }
           
        }

       






        if (Input.GetKeyUp(KeyCode.O))
        {
            KochGenerate(targetPosition, true, generateMultiplier);
            lerpPosition = new Vector3[position.Length];
            lineRenderer.positionCount = position.Length;
            lineRenderer.SetPositions(position);
            lerpAmount = 0;
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            KochGenerate(targetPosition, false, generateMultiplier);
            lerpPosition = new Vector3[position.Length];
            lineRenderer.positionCount = position.Length;
            lineRenderer.SetPositions(position);
            lerpAmount = 0;
        }


        
        if(index < branchs)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                index++;
                createBranch();
                timeLeft = timer;
            }
        }



        
    }


    protected void createBranch()
    {
        int yesorno = Random.Range(0, 1);
        if(yesorno == 1)
        {
            KochGenerate(targetPosition, true, generateMultiplier);
        }
        else
        {
            KochGenerate(targetPosition, true, generateMultiplier);
        }
           
            lerpPosition = new Vector3[position.Length];
            lineRenderer.positionCount = position.Length;
            lineRenderer.SetPositions(position);
            lerpAmount = Random.Range(0.0f,1.0f);
    }
}
