using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionTiburon : MonoBehaviour
{
    public GameObject enemigo;
    private int numEnemigo = 1;

    private void Awake()
    {
        AparecerEnemigos();
    }

    public void AparecerEnemigos()
    {
        if (enemigo != null && !Object.ReferenceEquals(enemigo, null))
        {
            for (int i = 0; i < numEnemigo; i++)
            {
                Vector3 posicion = new Vector3(Random.Range(-5, 5), Random.Range(-10, -30), 0);
                Instantiate(enemigo, posicion, Quaternion.identity);
            }
        }
    }
}