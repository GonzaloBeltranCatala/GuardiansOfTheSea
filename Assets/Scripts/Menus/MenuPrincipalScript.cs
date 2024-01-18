using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalScript : MonoBehaviour
{
    public GameObject Cinematica1;
    public GameObject Cinematica2;
    public GameObject Cinematica3;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Cinematica1.SetActive(false);
        Cinematica2.SetActive(false);
        Cinematica3.SetActive(false);
    }

    public void StartGame()
    {
        StartCoroutine(Sequence());
    }

    public void Options()
    {
        SceneManager.LoadScene("Opciones");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controles(PC)");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator Sequence()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        Cinematica1.SetActive(true);

        yield return new WaitForSeconds(3);

        Cinematica2.SetActive(true);

        yield return new WaitForSeconds(3);

        Cinematica3.SetActive(true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("GuardiansOfTheSea");
    }
}
