using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaranja : MonoBehaviour
{
    public Transform objetivo;

    private float velocidad = 3.5f;

    private bool salvar = false;

    void Update(){

        if(salvar==true){

        Vector3 dir = objetivo.position - transform.position;
    
         dir.Normalize();

         transform.position += dir * velocidad * Time.deltaTime;

        }

 }
 
    
 void OnTriggerEnter2D(Collider2D collision){

   if (collision.CompareTag("Submarino"))
        {
            salvar = true;
        }

 }
    
}
