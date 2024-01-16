using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTienda : MonoBehaviour
{
    public GameObject shopMenu;
    public TextMeshProUGUI shopHint;
    public bool isPaused;

    public Cronometro scriptCrono;
    public Puntuacion scriptPuntos;

    void Start()
    {
        scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();
        scriptPuntos = GameObject.Find("Submarino").GetComponent<Puntuacion>();
        shopMenu.SetActive(false);
        shopHint.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Continue()
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BuyOxygen()
    {
        if (scriptPuntos.puntos >= 10)
        {
            scriptCrono.timeLeft = scriptCrono.timeLeft + 10;
            scriptPuntos.puntos = scriptPuntos.puntos - 10;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (scriptPuntos.abrirTienda)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
            shopHint.SetActive(true);
        } else
        {
            shopHint.SetActive(false);
        }
    }
}
