using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionEnemigo : MonoBehaviour
{
    public GameObject enemigo;

    private Vector3 posicion;

    private int numEnemigo = 1;

    private void Awake()
    {
        for (int i = 0; i < numEnemigo; i++)
        {
            // X(izquierda derecha) Y(arriba abajo) 
            posicion = new Vector3(Random.Range(-10, 10), Random.Range(-6, -40), 0);

            Instantiate(enemigo, posicion, Quaternion.identity);
        }
    }
}
