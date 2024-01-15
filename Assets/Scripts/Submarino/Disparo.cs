using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Disparo : MonoBehaviour
{

    public GameObject prefab;

    public Transform insPoint;

    public TextMeshProUGUI municionText;

    private int municion = 0;


  
    void Start()
    {
        
    }

    
    void Update()
    {
            //jump en el input manager es el space
        if (Input.GetButtonDown("Jump") && municion > 0)
        {
           
                //que voy a instanciar,donde, no rota
                Instantiate(prefab, insPoint.position, Quaternion.identity);

             
 
            municion--;
            municionText.text = "x" + municion;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basura"))
        {
            municion++;
            municionText.text = "x" + municion;
        }

    }
}
