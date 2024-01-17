using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{


    public float timeLeft;

    public bool cronometro = false;

    public TextMeshProUGUI cronometroTxt;


    void Start()
    {
        cronometro = true;
    }

    void Update()
    {

        if(cronometro){


            if(timeLeft > 0){

            timeLeft -= Time.deltaTime;
            updateCrono(timeLeft);

            }
        
            else{

            timeLeft = 0;

            cronometro = false;

            //pantalla "has perdido"
            print("has perdido");

            SceneManager.LoadScene("GuardiansOfTheSea");

            }

        }
    

    }

    void updateCrono(float currentTime){

        currentTime += 1;

        float minutos = Mathf.FloorToInt(currentTime / 60);

        float segundos = Mathf.FloorToInt(currentTime % 60);

        cronometroTxt.text = string.Format("{0:00} : {1:00}", minutos,segundos);

       

    }
}
