using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo2 : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaLimite = 5f;
    public float distanciaMinima = 1f;

    private Vector3 direccion = Vector3.left;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
        if (Mathf.Abs(transform.position.x) >= distanciaLimite)
        {
            CambiarDireccion();
        }
        spriteRenderer.flipX = (direccion.x > 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Submarino"))
        {
            StunSubmarino();
        }
        else if (other.CompareTag("Proyectil"))
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
        Destroy(gameObject);
    }

    void CambiarDireccion()
    {
        direccion = new Vector3(Random.Range(-1f, 1f), 0f, 0f).normalized;
    }
}
