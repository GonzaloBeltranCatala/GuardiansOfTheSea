using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlesConsola : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ToPC()
    {
        SceneManager.LoadScene("Controles(PC)");
    }

    void Update()
    {
        
    }
}
