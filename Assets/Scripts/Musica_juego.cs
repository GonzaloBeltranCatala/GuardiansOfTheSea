using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Musica_juego : MonoBehaviour
{
    private bool pausar;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!pausar)
            {
                mixer.SetFloat("LowPass", 500);
                Time.timeScale = 0;
                pausar = true;
            }

            else
            {
                mixer.SetFloat("LowPass", 22000);
                Time.timeScale = 1;
                pausar = false;
            }

        }
    }
}
