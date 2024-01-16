using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntuacion : MonoBehaviour
{

public Disparo scriptDisparo;

//public Cronometro scriptCrono;

public int puntos;



void Start()
{
scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();

//scriptCrono = GameObject.Find("Submarino").GetComponent<Cronometro>();

}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
        
            puntos = scriptDisparo.municion;   

            puntos = puntos + 5;

            scriptDisparo.municion = 0;

            //scriptCrono.timeLeft = scriptCrono.timeLeft + puntos;

        }

    }
}
