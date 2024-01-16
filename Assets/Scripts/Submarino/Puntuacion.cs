using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntuacion : MonoBehaviour
{

public Disparo scriptDisparo;
public GameObject shopHint;

public int puntos;
public bool abrirTienda;



    void Start()
    {
        scriptDisparo = GameObject.Find("Submarino").GetComponent<Disparo>();
        abrirTienda = false;
        shopHint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
            shopHint.SetActive(true);

            abrirTienda = true;

            puntos = scriptDisparo.municion * 5;

            scriptDisparo.municion = 0;

            scriptDisparo.municionText.text = "x" + scriptDisparo.municion;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        abrirTienda = false;
        shopHint.SetActive(false);
    }
}
