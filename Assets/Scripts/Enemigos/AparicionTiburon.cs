using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionTiburon : MonoBehaviour
{
    public GameObject tiburon;
    private int numTiburon = 3;

    /*private void Awake()
    {
        AparecerEnemigos();
    }

    public void AparecerEnemigos()
    {
        if (tiburon != null && !Object.ReferenceEquals(tiburon, null))
        {
            for (int i = 0; i < numTiburon; i++)
            {
                Vector3 posicion = new Vector3(Random.Range(-5, 5), Random.Range(-10, -30), 0);
                Instantiate(tiburon, posicion, Quaternion.identity);
            }
        }
    }*/

    private void Awake()
    {
        for (int i = 0; i < numTiburon; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-6, 6), Random.Range(-15, -60), 0);
            Instantiate(tiburon, posicion, Quaternion.identity);
        }
    }
}