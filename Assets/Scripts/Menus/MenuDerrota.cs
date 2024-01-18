using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDerrota : MonoBehaviour
{
    public GameObject defeatMenu;
    public bool isLoser;

    void Start()
    {
        defeatMenu.SetActive(false);
        isLoser = false;
    }

    public void Derrota()
    {
        Time.timeScale = 0f;
        defeatMenu.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("GuardiansOfTheSea");
        isLoser = false;
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        isLoser = false;
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
