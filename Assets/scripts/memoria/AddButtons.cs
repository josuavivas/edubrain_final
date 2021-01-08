using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddButtons : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Transform puzzlefield;
    [SerializeField]
    private GameObject btn;
    public int num,niv,indicador;

    
    
    void Awake()
    {
        
        GameController num = GetComponent<GameController>();
        niv= num.nivel;
        

        if(niv ==1)
        {
            indicador=6;
        }
        else
        {
            indicador = 18;
        }
        
        for(int i = 0; i < indicador; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzlefield,false);
        }
    }
}
