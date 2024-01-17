using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparicionEstrella : MonoBehaviour
{
    public GameObject estrella;
    private int numEstrellas = 4;

    private void Awake()
    {
        for (int i = 0; i < numEstrellas; i++)
        {
            Vector3 posicion = new Vector3(Random.Range(-4, 4), Random.Range(-6, -60), 0);
            Instantiate(estrella, posicion, Quaternion.identity);
        }
    }
}