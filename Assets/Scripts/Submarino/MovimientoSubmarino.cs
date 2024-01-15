using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSubmarino : MonoBehaviour
{


    public float velocidad;

    private SpriteRenderer spriteRenderer;

    public float profundidadMax;


    private void Awake()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);


        if (inputVector.magnitude > 1) {
            
            inputVector.Normalize(); 
        
        }

        Vector3 movementVector = inputVector * velocidad * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementVector.x, -8, 8), Mathf.Clamp(transform.position.y + movementVector.y, profundidadMax, - 2.5f), 0);


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
