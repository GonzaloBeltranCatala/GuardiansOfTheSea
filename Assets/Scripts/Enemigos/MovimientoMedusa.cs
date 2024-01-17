using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMedusa : MonoBehaviour
{
    public float velocidad = 5f, distanciaLimite = 6f, distanciaMinima = 1f, velocidadDesvanecimiento = 0.2f, opacidadInicial = 1f;
    private Vector3 direccion = Vector3.left;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool estaDesvaneciendose = false;
    private Collider2D medusaCollider;

    public Sprite spriteDefault, spriteAlternativo;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        medusaCollider = GetComponent<Collider2D>();
        CambiarSprite(spriteDefault);
    }

    void Update()
    {
        if (!estaDesvaneciendose)
        {
            transform.position += direccion * velocidad * Time.deltaTime;
            if (Mathf.Abs(transform.position.x) >= distanciaLimite) CambiarDireccion();
            spriteRenderer.flipX = (direccion.x > 0);
        }
        else
        {
            Color color = spriteRenderer.color;
            color.a -= velocidadDesvanecimiento * Time.deltaTime;
            spriteRenderer.color = color;

            if (color.a <= 0) Destroy(gameObject);
        }
    }

    // Colisiones con la medusa
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Submarino")) DestruirMedusa();
        else if (col.CompareTag("Bala")) ApaciguarMedusa();
    }

    // Funcion para cuando la medusa se choca con el submarino
    void DestruirMedusa()
    {
        Destroy(gameObject);
    }

    // Funcion para cuando golpeas a la medusa con una bala
    void ApaciguarMedusa()
    {
        CambiarSprite(spriteAlternativo);
        estaDesvaneciendose = true;
        velocidad *= 0.5f;
        medusaCollider.enabled = false;
    }

    // Cambia el sprite a la medusa feliz
    void CambiarSprite(Sprite nuevoSprite)
    {
        spriteRenderer.sprite = nuevoSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, opacidadInicial);
        animator.Play("Triste", 0, 0f);
    }

    // Gira a la medusa cuando llega a su limite
    void CambiarDireccion() { direccion = -direccion; }
}