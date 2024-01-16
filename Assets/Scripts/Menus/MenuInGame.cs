using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public MenuTienda tienda;
    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Pausa y continuar
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Otros botones
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        isPaused = false;
    }
    public void Exit()
    {
        Application.Quit();
    }

    //Funcionalidad menu
    private void Update()
    {
        if (!tienda.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    Pause();
                }
                else
                {
                    Continue();
                }
            }
        }
    }
}