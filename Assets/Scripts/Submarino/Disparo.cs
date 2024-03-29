using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Disparo : MonoBehaviour
{

    public GameObject prefab;

    public Transform insPoint;

    public TextMeshProUGUI municionText;

    public int municion = 0;

    public MenuInGame scriptPausa;
  
    void Start()
    {
        
    }

    void Update()
    { 

        if(scriptPausa.isPaused == false){

        if (Input.GetButtonDown("Jump") && municion > 0)
        {
                //que voy a instanciar,donde, no rota
                Instantiate(prefab, insPoint.position, Quaternion.identity);

            municion--;
            municionText.text = "x " + municion;
        }

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
