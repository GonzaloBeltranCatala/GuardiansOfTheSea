using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMedusa : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Submarino") || (collision.CompareTag("Bala")))
        {
            DestruirEnemigo();
        }
    }

    void DestruirEnemigo()
    {
        Destroy(gameObject);
    }

    // EL FALLO DE QUE LA MEDUSA SE QUEDE BLOQUEADA ESTA AQUI
    void CambiarDireccion()
    {
        direccion = new Vector3(Random.Range(-1f, 1f), 0f, 0f).normalized;
    }
}