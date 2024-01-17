using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionBasura : MonoBehaviour
{
    public GameObject basura;

    private Vector3 posicion;

    private int numBasura = 20;

    private void Awake()
    {
        for (int i = 0; i < numBasura; i++)
        {
            // X(izquierda derecha) Y(arriba abajo) 
            posicion = new Vector3(Random.Range(-8, 8), Random.Range(-6, -60), 0);

            Instantiate(basura, posicion, Quaternion.identity);
        }
    }

}
