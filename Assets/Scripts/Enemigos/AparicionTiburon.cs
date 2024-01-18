using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionTiburon : MonoBehaviour
{
    public GameObject tiburon;
    private int numTiburones = 4;

    private void Awake()
    {
        CrearTiburon();
    }

    public void CrearTiburon()
    {
        for (int i = 0; i < numTiburones; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-10, -10), Random.Range(-15, -50), 0);
            Instantiate(tiburon, posicion, Quaternion.identity);
        }
    }
}