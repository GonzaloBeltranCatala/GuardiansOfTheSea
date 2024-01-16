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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Submarino") || (collision.CompareTag("Bala")))
        {
            DestruirEnemigo();
        }
    }

    void DestruirEnemigo()
    {
        AparicionTiburon aparicionEnemigo = FindObjectOfType<AparicionTiburon>();
        if (aparicionEnemigo != null)
        {
            aparicionEnemigo.AparecerEnemigos();
        }
        Destroy(gameObject);
    }
}
