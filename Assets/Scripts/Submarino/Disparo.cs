using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public GameObject prefab;

    public Transform insPoint;

    private int municion = 0;


  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire") && municion > 0)
        {
           
                //que voy a instanciar,donde, no rota
                Instantiate(prefab, insPoint.position, Quaternion.identity);

             
 
            municion--;

        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basura"))
        {
            print(municion);
            municion++;
            print(municion);
        }

    }
}
