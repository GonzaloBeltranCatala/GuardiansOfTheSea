using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlesPC : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToConsole()
    {
        SceneManager.LoadScene("Controles(Consola)");
    }

    void Update()
    {
        
    }
}
