using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private Transform puzzlefield;
    [SerializeField]
    private GameObject btn;


     void Awake()
    {

        for(int i = 0; i < 50; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzlefield,false);
        }
    }
}
