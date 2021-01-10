using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.cokitos.com/patrones-numericos/play/


public class MenuPrincipal : MonoBehaviour
{
    public GameObject menu_inicio; 
    public GameObject menu_principal;

    public void IniciarJuego0()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu_inicio.SetActive(false);
        menu_principal.SetActive(true);
    }

    public void IniciarJuego1()
    {
        SceneManager.LoadScene("Scene4");
    }
    
    public void IniciarJuego2()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void IniciarJuego3()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void IniciarJuego4()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void VolverInicio()
    {
        
        menu_inicio.SetActive(true);
        menu_principal.SetActive(false);
    }

    public void SalirJuego()
    {
        
       Application.Quit();
    }
}
