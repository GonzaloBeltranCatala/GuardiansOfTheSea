using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSubmarino : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float velocidad;
    // Update is called once per frame
    void Update()
    {

        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);


        if (inputVector.magnitude > 1) { inputVector.Normalize(); }

        Vector3 movementVector = inputVector * velocidad * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movementVector.x, -9, 9), Mathf.Clamp(transform.position.y + movementVector.y, -4, 4), 0);

    }
}
