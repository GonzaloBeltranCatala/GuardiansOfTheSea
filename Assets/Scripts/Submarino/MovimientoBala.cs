using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBala : MonoBehaviour
{
    public float velocidad;

    private Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        transform.Rotate(0f, 0f, 180f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidad * Time.deltaTime, Space.World);

        if (!render.isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Medusa") || collision.CompareTag("Tiburon") || collision.CompareTag("Estrella"))
        {
            DestruirBala();
        }
    }

    void DestruirBala()
    {
        Destroy(gameObject);
    }
}
