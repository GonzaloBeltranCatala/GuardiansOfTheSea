using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionMedusa : MonoBehaviour
{
    public GameObject medusa;
    private int numMedusas = 15;

    void Start()
    {
        AparecerEnemigos();
    }

    public void AparecerEnemigos()
    {
        for (int i = 0; i < numMedusas; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-4, 4), Random.Range(-6, -60), 0);
            Instantiate(medusa, posicion, Quaternion.identity);
        }

        enabled = false;
    }
}