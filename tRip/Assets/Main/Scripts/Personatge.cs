using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personatge : MonoBehaviour
{
    public int numScena;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (this.gameObject.transform.position.y < -10) nextScene();
    }

    public void nextScene()
    {
        Debug.Log("change scene num" + numScena);
        SceneManager.LoadScene(numScena);
    }
}
