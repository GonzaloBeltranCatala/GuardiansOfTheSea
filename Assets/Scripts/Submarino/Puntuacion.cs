using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntuacion : MonoBehaviour
{


public GameObject shopHint;


public bool abrirTienda;



    void Start()
    {
      
        abrirTienda = false;
        shopHint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
            shopHint.SetActive(true);

            abrirTienda = true;

           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        abrirTienda = false;
        shopHint.SetActive(false);
    }
}
