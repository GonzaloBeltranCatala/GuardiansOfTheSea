using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTienda : MonoBehaviour
{
    public GameObject shopMenu;
    public bool isPaused;

    public Cronometro scriptCrono;
    public Puntuacion scriptPuntos;
    public Disparo scriptDisparo;


    public TextMeshProUGUI puntosText;


    public int puntos;

    void Start()
    {
        scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();
        scriptPuntos = GameObject.Find("Submarino").GetComponent<Puntuacion>();
        scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();

        shopMenu.SetActive(false);
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
        if (puntos >= 10)
        {
            scriptCrono.timeLeft = scriptCrono.timeLeft + 10;
            puntos = puntos - 10;

            puntosText.text = "Puntos: " + puntos;
        }
    }

    void Update()
    {
        if (scriptPuntos.abrirTienda)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                puntos = puntos + scriptDisparo.municion * 5;

                puntosText.text = "Puntos: " + puntos;

                scriptDisparo.municion = 0;

                scriptDisparo.municionText.text = "x" + scriptDisparo.municion;

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
