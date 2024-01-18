using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puntuacion : MonoBehaviour
{


    public GameObject shopHint;

    public MenuVictoria scriptVictoria;

    public bool abrirTienda;

    private bool ganar = false;



    void Start()
    {
      
        abrirTienda = false;
        shopHint.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barco"))
        {
            if(ganar == false){

                shopHint.SetActive(true);

                abrirTienda = true;
            }
            
            
             if(ganar == true){

                //pantalla "has ganado"

                scriptVictoria.Victoria();

            }
        }

        if(collision.CompareTag("Submarino2")){

                ganar = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        abrirTienda = false;
        shopHint.SetActive(false);
    }
}
