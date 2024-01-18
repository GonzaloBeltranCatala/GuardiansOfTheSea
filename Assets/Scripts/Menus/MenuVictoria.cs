using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuVictoria : MonoBehaviour
{
    public Puntuacion scriptPuntuacion;
    public GameObject victoryMenu;
    public bool isWinner;
    public TextMeshProUGUI animalesSalvados;

    void Start()
    {
        victoryMenu.SetActive(false);
        isWinner = false;
    }

    public void Victoria()
    {
        Time.timeScale = 0f;
        animalesSalvados.text = "" + scriptPuntuacion.monstruosSalvados;
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
