using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 0.5f;
    public float distanciaMinima = 1f;

    private Vector3 direccion = Vector3.left;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 direccion = objetivo.position - transform.position;
        direccion.Normalize();

        transform.position += direccion * velocidad * Time.deltaTime;

        spriteRenderer.flipX = (direccion.x > 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Submarino"))
        {
            StunSubmarino();
        }
        else if (other.CompareTag("Bala"))
        {
            DestruirSubmarino();
        }
    }

    void StunSubmarino()
    {
        // falta el stun
        Destroy(gameObject);
    }

    void DestruirSubmarino()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }

        Destroy(gameObject);
    }
}
