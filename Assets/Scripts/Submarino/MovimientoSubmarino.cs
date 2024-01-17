using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSubmarino : MonoBehaviour
{
    public float velocidad;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private bool congelado = false;

    public float profundidad;

    public MenuTienda scriptPuntos;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        if (congelado==false)
        {
            Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);


            if (inputVector.magnitude > 1)
            {

                inputVector.Normalize();

            }

            Vector3 movementVector = inputVector * velocidad * Time.deltaTime;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementVector.x, -9, 9), Mathf.Clamp(transform.position.y + movementVector.y, profundidad, 0), 0);


            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                spriteRenderer.flipX = true;

            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                spriteRenderer.flipX = false;
            }


        }
 

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiburon") || (collision.CompareTag("Medusa")))
        {
            animator.Play("Herido");



            StartCoroutine(Congelar());

            if (scriptPuntos.puntos > 0)
            {
                scriptPuntos.puntos = scriptPuntos.puntos - 3;

                if (scriptPuntos.puntos < 0)
                {
                    scriptPuntos.puntos = 0;
                }

                scriptPuntos.puntosText.text = "Puntos: " + scriptPuntos.puntos;
            }
           

        }
    }


    private IEnumerator Congelar()
    {

        congelado = true;

        yield return new WaitForSeconds(5);

        congelado = false;

    }
}
