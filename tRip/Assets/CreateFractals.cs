using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateFractals : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] fractals;
    [SerializeField]
    public static int indexFractals = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(indexFractals);
        fractals[indexFractals].SetActive(true);
        if(indexFractals == 6)
        {
            Debug.Log("ae");
            SceneManager.LoadScene("FinalScene");
        }
    }

}
