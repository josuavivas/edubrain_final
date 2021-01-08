using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control_menu1 : MonoBehaviour
{
    public GameObject menu_pausa;
    public GameObject btn_pausa;

    public void IniciarJuego0()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu_pausa.SetActive(true);
    }

    

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Scene2");
    }
    
    public void JugarJuego()
    {
        menu_pausa.SetActive(false);
        btn_pausa.gameObject.SetActive(true);
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("Menu");
    }
}
