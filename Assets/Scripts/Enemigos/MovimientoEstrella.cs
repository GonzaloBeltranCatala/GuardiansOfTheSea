using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEstrella : MonoBehaviour
{
    public float velocidad = 0.5f, distanciaMinima = 1f, velocidadDesvanecimiento = 0.2f, opacidadInicial = 1f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Sprite spriteDefault, spriteAlternativo;
    private bool estaDesvaneciendose = false;
    private Collider2D estrellaCollider;

    public float velocidadAngular = 2f;  // Velocidad angular en radianes por segundo
    public float radio = 1f;  // Radio del círculo
    private float angulo = 0f;
    private Vector3 centro;

    private AudioSource estrellaSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        estrellaCollider = GetComponent<Collider2D>();
        centro = transform.position;
        estrellaSound = GetComponent<AudioSource>();
        CambiarSprite(spriteDefault);
    }

    void Update()
    {
        if (!estaDesvaneciendose)
        {
            angulo += velocidadAngular * Time.deltaTime;
            float x = centro.x + Mathf.Cos(angulo) * radio;
            float y = centro.y + Mathf.Sin(angulo) * radio;

            transform.position = new Vector3(x, y, 0f);

            Vector3 dirToCenter = centro - transform.position;
            float angle = Mathf.Atan2(dirToCenter.y, dirToCenter.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        else
        {
            Color color = spriteRenderer.color;
            color.a -= velocidadDesvanecimiento * Time.deltaTime;
            spriteRenderer.color = color;

            if (color.a <= 0) Destroy(gameObject);
        }
    }

    // Colisiones con la estrella
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Submarino")) DestruirEstrella();
        else if (col.CompareTag("Bala")) ApaciguarEstrella();
    }

    // Funcion para cuando la estrella se choca con el submarino
    void DestruirEstrella()
    {
        estaDesvaneciendose = true;
        velocidad *= 1f;
        estrellaCollider.enabled = false;
        //Destroy(gameObject);
    }

    // Funcion para cuando golpeas a la estrella con una bala
    void ApaciguarEstrella()
    {
        CambiarSprite(spriteAlternativo);
        estaDesvaneciendose = true;
        velocidad *= 0.5f;
        estrellaCollider.enabled = false;
        estrellaSound.Play();
    }

    // Cambia el sprite a la estrella feliz
    void CambiarSprite(Sprite nuevoSprite)
    {
        spriteRenderer.sprite = nuevoSprite;
        spriteRenderer.color = new Color(1f, 1f, 1f, opacidadInicial);
        animator.Play("Triste", 0, 0f);
    }
}