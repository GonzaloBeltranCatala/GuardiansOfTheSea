using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTiburon : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 0.5f, distanciaMinima = 1f, velocidadDesvanecimiento = 0.2f, opacidadInicial = 1f;
    private Vector3 direccion = Vector3.left;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite spriteDefault, spriteAlternativo;
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
            Vector3 dir = objetivo.position - transform.position;
            dir.Normalize();

            transform.position += dir * velocidad * Time.deltaTime;

            spriteRenderer.flipX = (dir.x > 0);

        }
        else
        {
            Color color = spriteRenderer.color;
            color.a -= velocidadDesvanecimiento * Time.deltaTime;
            spriteRenderer.color = color;

            if (color.a <= 0) Destroy(gameObject);
        }
    }

    // Colisiones con el tiburon
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Submarino")) DestruirTiburon();
        else if (col.CompareTag("Bala")) ApaciguarTiburon();
    }

    // Funcion para cuando el tiburon se choca con el submarino
    void DestruirTiburon()
    {
        estaDesvaneciendose = true;
        velocidad *= 0.5f;
        tiburonCollider.enabled = false;
        //Destroy(gameObject);
    }

    // Funcion para cuando golpeas al tiburon con una bala
    void ApaciguarTiburon()
    {
        CambiarSprite(spriteAlternativo);
        estaDesvaneciendose = true;
        velocidad *= 0.5f;
        tiburonCollider.enabled = false;
    }

    // Cambia el sprite al tiburon feliz
    void CambiarSprite(Sprite nuevoSprite)
    {
        spriteRenderer.sprite = nuevoSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, opacidadInicial);
        animator.Play("Triste", 0, 0f);
    }
}