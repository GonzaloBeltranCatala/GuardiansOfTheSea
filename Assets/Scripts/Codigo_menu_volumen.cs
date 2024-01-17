using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Codigo_menu_volumen : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); //PARA QUE SE MANTENGA GUARDADO EL VALOR DEL VOLUMEN CADA VEZ QUE SE SALGA Y ENTRE DEL JUEGO
        AudioListener.volume = slider.value; //SACAMOS EL VOLUMEN DEL JUEGO PARA QUE TENGA EL VALOR DEL SLIDER
        RevisarMute(); //PARA QUE SALGA AVISO DE QUE ESTÁ MUTEADO EL SONIDO
    }

    public void ChangeSlider(float valor)
    {
        slider.value = valor;
        PlayerPrefs.SetFloat("volumenAudio", slider.value); //LE PONEMOS UN VALOR AL VOLUMEN
        AudioListener.volume = slider.value; //EL VALOR
        RevisarMute();
    }

    public void RevisarMute() 
    {
        if (slider.value == 0) 
        {
            imagenMute.enabled = true;
        }
        else 
        {
            imagenMute.enabled = false;
        }
    }
}
