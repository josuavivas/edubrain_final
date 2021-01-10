using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl4 : MonoBehaviour {
    [SerializeField]
    private Sprite bgImage;
   


    public List<Button> btns = new List<Button>();
    public List<Sprite> game_imgs = new List<Sprite>();
    

    public Sprite[] imgs;
    public int firs,rando,count_correct,imx,ind;
    public bool result;
    private int countg=0;
    private string fir, seco;
    private bool state_game,esta;
    
    public int nivel;

    public GameObject menu_fin;
    public Image spriter; 
    public GameObject menu_pausa;
    public GameObject btn_pausa1;

    public Text txt_tiempo;

    public float tiempo=10f;
    

    void Awake()
    {
        
        imgs = Resources.LoadAll<Sprite>("Sprites/visules/");
    }

    
    // Use this for initialization
    void Start()
    {
        getButtons();
        AddLIsteners();
        Shuffle(btns);
        show(nivel);
        rando=1;
        

        //btns[rando].image.sprite = imgs[imx];
        seco=btns[rando].name;
        
        
    }

    public void Update() 
    {
        
        tiempo -=Time.deltaTime;
        reloj(tiempo);
        
        if(esta==true)
        {
            estado();
        }
        if(nivel==6)
        {
            txt_tiempo.text = "Tiempo: 0";
        }
    }

    public void reloj(float tiem)
    {
        txt_tiempo.text = "Tiempo: "+tiem.ToString("f0");
        Time.timeScale= 1f;
        if(tiem<=0)
        {
            tiem=0;
            menu_fin.SetActive(true);
            menu_pausa.SetActive(false);
            txt_tiempo.text = "Tiempo: 0";
        }
    }
    
    public void estado()
    {
        state_game = !state_game;

        if(state_game)
        {
            Time.timeScale= 1f;
        }
        else
        {
           Time.timeScale= 0.0001f; 
        }
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu_pausa.SetActive(false);
        menu_fin.SetActive(false);
        btn_pausa1.gameObject.SetActive(true);
        esta=false;
    }


    public void PausarJuego()
    {
        menu_pausa.SetActive(true);
        btn_pausa1.gameObject.SetActive(false);
        menu_fin.SetActive(false);
        esta=true;
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("Scene4");
    }
    
    public void SalirJuego()
    {
        SceneManager.LoadScene("Menu");
    }


    void getButtons()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameButton");
        for(int i = 0; i < objs.Length; i++)
        {
            btns.Add(objs[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

        
    }

    public void AddLIsteners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => ClickButton());
        }

    }

    public void ClickButton()
    {
   
        fir = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("firs! " + fir);
        //fir = btns[firs].name;
        
        
        Debug.Log("seco! " + seco);
        //Debug.Log("fir! " + fir);
        countg++;

        Text txt = GameObject.FindGameObjectWithTag("Score").GetComponent <Text>() ;
        txt.text = "Intentos: " + countg; 
        
        result = fir.Equals(seco);

        if (result != true) {
            
           checkIfFinished(); 
        }
        else
        {
            count_correct ++;
            checkIfFinished();
        }

        
    }
    
    
    
    void checkIfFinished()
    {
        
        if (count_correct == 1)
        {
            Debug.Log("Game Finished");
            Debug.Log("Tardaste " + countg + " Intentos");
            btn_pausa1.gameObject.SetActive(false);
            

            nivel++;

            if(nivel==5)
            {
                menu_fin.SetActive(true);
                PlayerPrefs.SetInt("max",countg);
                  
            }
            PasarNivelJuego(nivel);
            
        }
    }

    // void AddImages()
    // {
    //     int count = btns.Count;
    //     int index = 0;

    //     for(int i = 0; i < count; i++)
    //     {
            
    //         game_imgs.Add(imgs[index]);
            
    //         index++;
    //     }

    // }

    public void show(int niv)
    { 
        //int contador = btns.Count;
        spriter = GameObject.Find("muestra").GetComponent<Image>();
        if(niv==1)
        {
            spriter.sprite = Resources.Load<Sprite>("Sprites/visules/3");
            //spriter.sprite=imgs.sprite.name("3");
            
            btns[0].GetComponentInChildren<Text>().text = "6";
            btns[1].GetComponentInChildren<Text>().text = "3";
            btns[2].GetComponentInChildren<Text>().text = "8";
            btns[3].GetComponentInChildren<Text>().text = "9";
            
        }
        else if(niv==2)
        {
            spriter.sprite = Resources.Load<Sprite>("Sprites/visules/6");

            btns[0].GetComponentInChildren<Text>().text = "0";
            btns[1].GetComponentInChildren<Text>().text = "6";
            btns[2].GetComponentInChildren<Text>().text = "8";
            btns[3].GetComponentInChildren<Text>().text = "9";
            
        }
        else if(niv==3)
        {
            spriter.sprite = Resources.Load<Sprite>("Sprites/visules/29");
            
            btns[0].GetComponentInChildren<Text>().text = "49";
            btns[1].GetComponentInChildren<Text>().text = "29";
            btns[2].GetComponentInChildren<Text>().text = "28";
            btns[3].GetComponentInChildren<Text>().text = "40";
            
        }
        else if(niv==4)
        {
            spriter.sprite = Resources.Load<Sprite>("Sprites/visules/74");
            
            btns[0].GetComponentInChildren<Text>().text = "71";
            btns[1].GetComponentInChildren<Text>().text = "74";
            btns[2].GetComponentInChildren<Text>().text = "14";
            btns[3].GetComponentInChildren<Text>().text = "24";
            
        }
        else if(niv==5)
        {
            spriter.sprite = Resources.Load<Sprite>("Sprites/visules/97");
            
            btns[0].GetComponentInChildren<Text>().text = "37";
            btns[1].GetComponentInChildren<Text>().text = "97";
            btns[2].GetComponentInChildren<Text>().text = "51";
            btns[3].GetComponentInChildren<Text>().text = "37"; 
        }
        
    }

    public void PasarNivelJuego(int nivel)
    {
        
        if(nivel==2)
        {
            SceneManager.LoadScene("Scene4_niv2");
        }
        else if(nivel==3)
        {
            SceneManager.LoadScene("Scene4_niv3");
        }
        else if(nivel==4)
        {
            SceneManager.LoadScene("Scene4_niv4");
        }
        else if(nivel==5)
        {
            SceneManager.LoadScene("Scene4_niv5");
        }
        else
        {
            menu_fin.SetActive(true);
        }
    }
    void Shuffle(List<Button> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            Button temp = list[i];
            int random = Random.Range(0, list.Count);
            list[i] = list[random];
            list[random] = temp;
            
        }
        
    }
}
