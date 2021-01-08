using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control_menu : MonoBehaviour
{
    public GameObject menu_pausa;
    public GameObject btn_pausa;

    public void IniciarJuego0()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu_pausa.SetActive(true);
    }

    public void PausarJuego()
    {
        menu_pausa.SetActive(true);
        btn_pausa.gameObject.SetActive(false);

    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Scene1");
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
