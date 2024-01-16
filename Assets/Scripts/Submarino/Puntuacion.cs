using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntuacion : MonoBehaviour
{

public Disparo scriptDisparo;

//public Cronometro scriptCrono;

public int puntos;
public bool abrirTienda;



    void Start()
    {
        scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();
        abrirTienda = false;

//scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
            abrirTienda = true;

            puntos = scriptDisparo.municion * 5;

            scriptDisparo.municion = 0;

            print("Tu puntuación es: " + puntos);
            //scriptCrono.timeLeft = scriptCrono.timeLeft + puntos;

        } else
        {
            abrirTienda = false;
        }

    }
}
