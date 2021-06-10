using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool juegoPausado = false;
    public GameObject menuPausaUI;
    private GameObject cursor;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.FindGameObjectWithTag("PlayerUI");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }
    public void Reanudar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        if (cursor != null)
        {
            Debug.Log("Cursor detectado");
            cursor.SetActive(true);
        }
        Cursor.lockState = CursorLockMode.Locked;
        juegoPausado = false;
        Debug.Log("Reanudado");


    }

    public void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (cursor != null)
        {
            Debug.Log("Cursor detectado");
            cursor.SetActive(false);
        }
        juegoPausado = true;
        Debug.Log("Pausado");
    }

    public void ReiniciarNivel()
    {
        Debug.Log("Reiniciciando nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Reanudar();
    }

    public void QuitarJuego()
    {
        Debug.Log("Quitando Juego...");
        Application.Quit();        
        juegoPausado = false;
    }

    public void CambiarNivel(int level)
    {   
        Debug.Log("Cambiando Nivel...");
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("MainScene");
                Reanudar();
                break;
            case 1:
                SceneManager.LoadScene("Level1");
                Reanudar();
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                Reanudar();
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                Reanudar();
                break;

        }

       
    }
}
