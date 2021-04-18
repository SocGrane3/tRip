using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyFractals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        CreateFractals.indexFractals +=1;
        if (CreateFractals.indexFractals == 6)
        {
            Debug.Log("ae");
            SceneManager.LoadScene("FinalScene");
        }

        Destroy(this.gameObject);

    }
}
