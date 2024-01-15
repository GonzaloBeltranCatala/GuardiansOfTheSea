using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionEnemigo1 : MonoBehaviour
{
    public GameObject enemigo2;

    private Vector3 posicion;

    private int numEnemigo2 = 3;

    private void Awake()
    {
        for (int i = 0; i < numEnemigo2; i++)
        {
            // X(izquierda derecha) Y(arriba abajo) 
            posicion = new Vector3(Random.Range(-1, 1), Random.Range(-6, -40), 0);

            Instantiate(enemigo2, posicion, Quaternion.identity);
        }
    }
}
