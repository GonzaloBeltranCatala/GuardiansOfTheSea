using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionMedusa : MonoBehaviour
{
    public GameObject medusa;
    private int numMedusas = 4;

    private void Awake()
    {
        AparecerEnemigos();
    }

    public void AparecerEnemigos()
    {
        if (medusa != null && !Object.ReferenceEquals(medusa, null))
        {
            for (int i = 0; i < numMedusas; i++)
            {
                Vector3 posicion = new Vector3(Random.Range(-1, 1), Random.Range(-6, -30), 0);
                Instantiate(medusa, posicion, Quaternion.identity);
            }
        }
    }
}