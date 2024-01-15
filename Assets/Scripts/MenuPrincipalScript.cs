using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GuardiansOfTheSea");
    }

    public void Options()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
