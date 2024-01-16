using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTiburon : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 0.5f;
    public float distanciaMinima = 1f;
    public float velocidadDesvanecimiento = 0.2f;
    public float opacidadInicial = 1f;

    private Vector3 direccion = Vector3.left;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    public Sprite spriteDefault;
    public Sprite spriteAlternativo;

    private bool estaDesvaneciendose = false;

    private Collider2D tiburonCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tiburonCollider = GetComponent<Collider2D>();
        CambiarSprite(spriteDefault);
    }

    void Update()
    {
        if (!estaDesvaneciendose)
        {
            Vector3 direccion = objetivo.position - transform.position;
            direccion.Normalize();
            transform.position += direccion * velocidad * Time.deltaTime;

            spriteRenderer.flipX = (direccion.x > 0);
        }
        else
        {
            Color color = spriteRenderer.color;
            color.a -= velocidadDesvanecimiento * Time.deltaTime;
            spriteRenderer.color = color;

            if (color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Submarino"))
        {
            DestruirTiburon();
        }
        else if (collision.CompareTag("Bala"))
        {
            ApaciguarTiburon();
        }
    }

    void DestruirTiburon()
    {
        AparicionTiburon aparicionEnemigo = FindObjectOfType<AparicionTiburon>();
        if (aparicionEnemigo != null)
        {
            aparicionEnemigo.AparecerEnemigos();
        }
        Destroy(gameObject);
    }

    void ApaciguarTiburon()
    {
        CambiarSprite(spriteAlternativo);
        estaDesvaneciendose = true;
        velocidad *= 0.5f;
        tiburonCollider.enabled = false;
    }

    void CambiarSprite(Sprite nuevoSprite)
    {
        GetComponent<SpriteRenderer>().sprite = nuevoSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, opacidadInicial);
        animator.Play("Triste", 0, 0f);
    }
}
