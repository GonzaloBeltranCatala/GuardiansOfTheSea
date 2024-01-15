using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionEnemigo1 : MonoBehaviour
{
    public GameObject enemigo2;
    private int numEnemigo2 = 4;

    private void Awake()
    {
        AparecerEnemigos();
    }

    public void AparecerEnemigos()
    {
        if (enemigo2 != null && !Object.ReferenceEquals(enemigo2, null))
        {
            for (int i = 0; i < numEnemigo2; i++)
            {
                Vector3 posicion = new Vector3(Random.Range(-1, 1), Random.Range(-6, -30), 0);
                Instantiate(enemigo2, posicion, Quaternion.identity);
            }
        }
    }
}