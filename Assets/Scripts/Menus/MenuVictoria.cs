using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{
    public GameObject victoryMenu;
    public bool isWinner;

    void Start()
    {
        victoryMenu.SetActive(false);
        isWinner = false;
    }

    public void Victoria()
    {
        Time.timeScale = 0f;
        victoryMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GuardiansOfTheSea");
        isWinner = false;
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        isWinner = false;
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
