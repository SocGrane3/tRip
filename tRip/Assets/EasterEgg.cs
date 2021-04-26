using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEgg : MonoBehaviour
{
    public float targetTime = 3.0f;
    public float time = 30.0f;


    public Text drugs;
  
    public Text win;
    public Text dieoralive;
    public Text timer;
  
    public Text cambiarEscenaPrincipal;

    bool saved = false;
    // Start is called before the first frame update
    void Start()
    {
        win.enabled = false;
        dieoralive.enabled = false;
        cambiarEscenaPrincipal.enabled = false;
     }

    // Update is called once per frame
    void Update()
    {

        if (!saved)
        {
            time -= Time.deltaTime;
            timer.text = "" + time;
            if (time <= 1.0f)
            {
                timerEnded(2);
            }
        }
        else
        {
            time = 0;
        }

        MenuPrincipal();
        

    }

    private void OnTriggerStay(Collider other)
    {
      
        targetTime -= Time.deltaTime;
        win.enabled = true;
        if (targetTime <= 1.0f)
        {
            timerEnded(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        win.enabled = false;
    }

    void timerEnded(int lw)
    {
        if(lw == 1)
        {
            
            dieoralive.text = "saved by the hospital";
            dieoralive.enabled = true;
            saved= true;
            cambiarEscenaPrincipal.enabled = true;
        }
        else
        {
           
            dieoralive.enabled = true;
            cambiarEscenaPrincipal.enabled = true;
        }
      
    }



    public void MenuPrincipal() {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
       
    }



}
