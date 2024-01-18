using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public Puntuacion scriptPuntos;
    public MenuVictoria scriptVictoria;
    public MenuDerrota scriptDerrota;
    public bool isPaused;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        scriptPuntos = GameObject.Find("Submarino").GetComponent<Puntuacion>();
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
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }

    //Funcionalidad menu
    private void Update()
    {
        if (!scriptPuntos.abrirTienda)
        {
            if (!scriptVictoria.isWinner)
            {
                if (!scriptDerrota.isLoser)
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        if (!isPaused)
                        {
                            Pause();
                            print("Otra vez no");
                        }
                        else
                        {
                            Continue();
                        }
                    }
                }
            }
        }
    }
}