using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTienda : MonoBehaviour
{
    public GameObject shopMenu;
    public bool isOpen;

    public MenuInGame scriptMenuInGame;
    public Cronometro scriptCrono;
    public Puntuacion scriptPuntos;
    public Disparo scriptDisparo;
    public MovimientoSubmarino scriptMovimiento;
    public AparicionBasura scriptBasura;
    public MenuVictoria scriptVictoria;
    public MenuDerrota scriptDerrota;


    public TextMeshProUGUI puntosText;

    public GameObject botonCasco;

    public GameObject capMax;


    public int puntos;

    void Start()
    {
        scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();
        scriptPuntos = GameObject.Find("Submarino").GetComponent<Puntuacion>();
        scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();
        scriptMovimiento = GameObject.Find("Submarino").GetComponent<MovimientoSubmarino>();
        scriptBasura = GameObject.Find("Spawn").GetComponent<AparicionBasura>();


        shopMenu.SetActive(false);
        isOpen = false;
    }

    public void Pause()
    {
        shopMenu.SetActive(true);
        Time.timeScale = 0f;
        isOpen = true;
    }
    public void Continue()
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1f;
        isOpen = false;
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

         if (puntos >= 60){

            if (scriptMovimiento.profundidad == -19.4f)
        {
            scriptMovimiento.profundidad = -36.3f;

            puntos = puntos - 60;

            puntosText.text = "Puntos: " + puntos;

        }

        else if (scriptMovimiento.profundidad == -36.3f)
        {
            scriptMovimiento.profundidad = -53f;

            puntos = puntos - 60;

            puntosText.text = "Puntos: " + puntos;


        }
        else if (scriptMovimiento.profundidad == -53f)
        {
            scriptMovimiento.profundidad = -60f;

            puntos = puntos - 60;

            puntosText.text = "Puntos: " + puntos;

            print("maxima capacidad");

                botonCasco.SetActive(false);

                capMax.SetActive(true);
            }
        

         }
        

        
    }

    void Update()
    {
        if (scriptPuntos.abrirTienda)
        {
            if (!scriptMenuInGame.isPaused)
            {
                if (!scriptVictoria.isWinner)
                {
                    if (!scriptDerrota.isLoser)
                    {
                        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0)) || Input.GetKeyDown(KeyCode.JoystickButton3))
                        {

                            //recrea la basura
                            scriptBasura.NoBasura();

                            scriptBasura.CrearBasura();


                            //convierte municion en puntos
                            puntos = puntos + scriptDisparo.municion * 5;

                            puntosText.text = "Puntos: " + puntos;

                            scriptDisparo.municion = 0;

                            scriptDisparo.municionText.text = "x " + scriptDisparo.municion;


                            if (!isOpen)
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
        }
    }
}
