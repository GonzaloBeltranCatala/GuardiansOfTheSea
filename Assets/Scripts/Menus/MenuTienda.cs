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
    public MovimientoSubmarino scriptMovimiento;


    public TextMeshProUGUI puntosText;


    public int puntos;

    void Start()
    {
        scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();
        scriptPuntos = GameObject.Find("Submarino").GetComponent<Puntuacion>();
        scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();
        scriptMovimiento = GameObject.Find("Submarino").GetComponent<MovimientoSubmarino>();

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

    public void BuyProfundidad()
    {
        if (scriptMovimiento.profundidad == -19.4f)
        {
            scriptMovimiento.profundidad = -36.3f;

            puntos = puntos - 10;

            puntosText.text = "Puntos: " + puntos;

        }

        else if (scriptMovimiento.profundidad == -36.3f)
        {
            scriptMovimiento.profundidad = -53f;

            puntos = puntos - 10;

            puntosText.text = "Puntos: " + puntos;


        }
        else if (scriptMovimiento.profundidad == -53f)
        {
            scriptMovimiento.profundidad = -60f;

            puntos = puntos - 10;

            puntosText.text = "Puntos: " + puntos;


        }else if (scriptMovimiento.profundidad == -60f)
        {
            print("maxima capacidad");
        }

        
    }

    void Update()
    {
        if (scriptPuntos.abrirTienda)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //convierte municion en puntos
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
